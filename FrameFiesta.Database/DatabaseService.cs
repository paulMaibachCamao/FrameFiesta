using FrameFiesta.Authentication;
using FrameFiesta.Contracts.Models;
using FrameFiesta.Utilities.ExtensionMethods.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FrameFiesta.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IRepository _repository;
        private readonly ICryptographyService _cryptographyService;

        public DatabaseService(IRepository repository, ICryptographyService cryptographyService)
        {
            _repository = repository;
            _cryptographyService = cryptographyService;
        }

        public async Task<User> Login(string userIdentification, string password)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            var query = from doc in collection.AsQueryable()
                        where doc.Users.Any(u => u.Name == userIdentification || u.Email == userIdentification)
                        select doc;

            var existingUser = query.FirstOrDefault()
                               ?.Users.FirstOrDefault(u => u.Name == userIdentification || u.Email == userIdentification);

            if (existingUser == null)
            {
                return null;
            }

            return _cryptographyService.Hash(password, existingUser.Salt) == existingUser.Password ? existingUser.ConvertUserDbToUser() : null;
        }

        public async Task<bool> DeleteUser(string userIdentification, string password)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            var query = from doc in collection.AsQueryable()
                        where doc.Users.Any(u => u.Name == userIdentification || u.Email == userIdentification)
                        select doc;

            var existingUser = query.FirstOrDefault()
                                ?.Users.FirstOrDefault(u => u.Name == userIdentification || u.Email == userIdentification);

            if (existingUser == null)
            {
                return false;
            }

            if (_cryptographyService.Hash(password, existingUser.Salt) == existingUser.Password)
            {
                var blogPosts = await GetAllBlogPosts().ConfigureAwait(false);

                foreach (var blogPost in blogPosts)
                {
                    foreach (var comment in blogPost.Comments)
                    {
                        if (existingUser.Comments.Any(x => x.ID == comment.Id))
                        {
                            var filterComment = Builders<FrameFiestaDocument>.Filter.And(
                                                Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                                                Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.BlogPosts, bp => bp.Id == blogPost.Id)
                            );

                            var updateComment = Builders<FrameFiestaDocument>.Update.PullFilter("BlogPosts.$.Comments", Builders<BlogComment>.Filter.Eq(c => c.CommentId, comment.Id));
                            await _repository.UpdateAsync(filterComment, updateComment, collection).ConfigureAwait(false);
                        }
                    }
                }

                var filter = Builders<FrameFiestaDocument>.Filter.And(
                             Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                             Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.Users, bp => bp.Id == existingUser.Id)
                );

                var update = Builders<FrameFiestaDocument>.Update.PullFilter("Users", Builders<UserDb>.Filter.Eq(c => c.Id, existingUser.Id));
                var result = await _repository.UpdateAsync(filter, update, collection).ConfigureAwait(false);

                return result;
            }

            return false;
        }

        public async Task<User> Register<T>(RegisterRequest registerRequest)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            var query = from doc in collection.AsQueryable()
                        where doc.Users.Any(u => u.Name == registerRequest.Name || u.Email == registerRequest.Email)
                        select doc;

            var existingUser = query.FirstOrDefault()
                                ?.Users.FirstOrDefault(u => u.Name == registerRequest.Name || u.Email == registerRequest.Email);

            if (existingUser != null)
            {
                return existingUser.ConvertUserDbToUser();
            }

            var newUser = new UserDb
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Salt = _cryptographyService.GenerateSalt(),
            };

            newUser.Password = _cryptographyService.Hash(registerRequest.Password, newUser.Salt);

            var collectionFrameFiesta = _repository.GetDatabase().GetCollection<FrameFiestaDocument>(_repository.GetDatabaseConfiguration().CollectionName);
            var filterFrameFiesta = Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities");
            var update = Builders<FrameFiestaDocument>.Update.Push(doc => doc.Users, newUser);
            var result = await _repository.UpdateAsync(filterFrameFiesta, update, collectionFrameFiesta).ConfigureAwait(false);

            return newUser.ConvertUserDbToUser();
        }

        public async Task<bool> IsCollectionEmptyAsync<T>(IMongoCollection<T> collection)
        {
            return (await collection.CountDocumentsAsync(Builders<T>.Filter.Empty).ConfigureAwait(false)) == 0;
        }

        public async Task<CommentFe> AddComment(string userIdentification, string password, string blogId, string commentText)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            var queryUser = from doc in collection.AsQueryable()
                            where doc.Users.Any(u => u.Name == userIdentification || u.Email == userIdentification)
                            select doc;

            var existingUser = queryUser.FirstOrDefault()
                                ?.Users.FirstOrDefault(u => u.Name == userIdentification || u.Email == userIdentification);

            if (existingUser == null || _cryptographyService.Hash(password, existingUser.Salt) != existingUser.Password)
            {
                return null;
            }

            var blog = (from doc in collection.AsQueryable()
                        where doc.BlogPosts.Any(b => b.Id == blogId)
                        select doc).FirstOrDefault()?.BlogPosts.FirstOrDefault(b => b.Id == blogId);

            if (blog == null)
            {
                return null;
            }

            var commentId = Guid.NewGuid().ToString();
            var blogComment = new BlogComment() { UserId = existingUser.Id, CommentId = commentId };
            blog.Comments.Add(blogComment);

            var userComment = new UserComment() { ID = commentId, Text = commentText };
            existingUser.Comments.Add(userComment);

            var filter = Builders<FrameFiestaDocument>.Filter.And(
                         Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                         Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.BlogPosts, bp => bp.Id == blogId));

            var update = Builders<FrameFiestaDocument>.Update.Set("BlogPosts.$", blog);
            await _repository.UpdateAsync(filter,update, collection).ConfigureAwait(false);

            var userFilter = Builders<FrameFiestaDocument>.Filter.And(
                             Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                             Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.Users, u => u.Id == existingUser.Id));

            var userUpdate = Builders<FrameFiestaDocument>.Update.Push("Users.$.Comments", userComment);
            await _repository.UpdateAsync(userFilter, userUpdate, collection).ConfigureAwait(false);

            var commentFe = new CommentFe
            {
                Id = commentId,
                Text = commentText,
                Date = DateTime.Now,
                Name = existingUser.Name
            };

            return commentFe;
        }

        public async Task<bool> DeleteComment(string userIdentification, string password, string blogId, string commentId)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            var queryUser = from doc in collection.AsQueryable()
                            where doc.Users.Any(u => u.Name == userIdentification || u.Email == userIdentification)
                            select doc;

            var existingUser = queryUser.FirstOrDefault()
                                ?.Users.FirstOrDefault(u => u.Name == userIdentification || u.Email == userIdentification);

            if (existingUser == null || _cryptographyService.Hash(password, existingUser.Salt) != existingUser.Password)
            {
                return false;
            }

            var blogExists = (from doc in collection.AsQueryable()
                              where doc.BlogPosts.Any(blog => blog.Id == blogId)
                              select doc).Any();

            if (!blogExists)
            {
                return false;
            }

            var filter = Builders<FrameFiestaDocument>.Filter.And(
                         Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                         Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.BlogPosts, bp => bp.Id == blogId)
            );

            var update = Builders<FrameFiestaDocument>.Update.PullFilter("BlogPosts.$.Comments", Builders<BlogComment>.Filter.Eq(c => c.CommentId, commentId));
            var resultBlogPost = await _repository.UpdateAsync(filter, update, collection).ConfigureAwait(false);

            var userFilter = Builders<FrameFiestaDocument>.Filter.And(
                             Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities"),
                             Builders<FrameFiestaDocument>.Filter.ElemMatch(doc => doc.Users, u => u.Id == existingUser.Id)
    );
            var userUpdate = Builders<FrameFiestaDocument>.Update.PullFilter("Users.$.Comments", Builders<UserComment>.Filter.Eq(c => c.ID, commentId));
            var resultUser = await _repository.UpdateAsync(userFilter, userUpdate, collection).ConfigureAwait(false);

            return resultBlogPost && resultUser;
        }

        public async Task<List<UserDb>> GetAllUsers()
        {
            var collection = _repository.GetCollection();
            var document = (await collection.Find(_ => true).ToListAsync().ConfigureAwait(false)).First();
            return document.Users;
        }

        public async Task PostDocumentIfCollectionIsEmpty(IMongoCollection<FrameFiestaDocument> collection)
        {
            if (await IsCollectionEmptyAsync(collection).ConfigureAwait(false))
            {
                var frameFiestaDocument = new FrameFiestaDocument() { Id = "Entities" };
                await _repository.PostAsync(frameFiestaDocument).ConfigureAwait(false);
            }
        }

        public async Task<BlogPostFe> AddBlogPost(BlogPostDb blogPost)
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);

            blogPost.Id = Guid.NewGuid().ToString();
            var filter = Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities");
            var update = Builders<FrameFiestaDocument>.Update.Push(doc => doc.BlogPosts, blogPost);
            var result = await collection.UpdateOneAsync(filter, update).ConfigureAwait(false);

            if (result.ModifiedCount == 1)
            {
                return new BlogPostFe
                {
                    Id = blogPost.Id,
                    Date = blogPost.Date,
                    Description = blogPost.Description,
                    Review = blogPost.Review,
                    RelatedMotionPicture = blogPost.RelatedMotionPicture,
                    Comments = new List<CommentFe>()
                };
            }

            return null;
        }

        public async Task<List<BlogPostFe>> GetAllBlogPosts()
        {
            var collection = _repository.GetCollection();
            await PostDocumentIfCollectionIsEmpty(collection).ConfigureAwait(false);
            var users = await GetAllUsers().ConfigureAwait(false);

            var documents = await collection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            var blogPosts = new List<BlogPostFe>();

            foreach (var document in documents)
            {
                foreach (var blogPost in document.BlogPosts)
                {
                    var motionPictureType = blogPost.RelatedMotionPicture.GetType();

                    if (typeof(Series).IsAssignableFrom(motionPictureType))
                    {
                        blogPost.RelatedMotionPicture = BsonSerializer.Deserialize<Series>(blogPost.RelatedMotionPicture.ToBsonDocument());
                    }
                    else if (typeof(Film).IsAssignableFrom(motionPictureType))
                    {
                        blogPost.RelatedMotionPicture = BsonSerializer.Deserialize<Film>(blogPost.RelatedMotionPicture.ToBsonDocument());
                    }

                    blogPosts.Add(blogPost.ToBlogPostFe(users));
                }
            }

            return blogPosts;
        }
    }
}