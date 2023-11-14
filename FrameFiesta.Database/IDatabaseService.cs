using FrameFiesta.Contracts.Models;
using MongoDB.Driver;

namespace FrameFiesta.Database
{
    public interface IDatabaseService
    {
        Task<User> Login(string userIdentification, string password);

        Task<bool> Register<T>(RegisterRequest registerRequest);

        Task<bool> IsCollectionEmptyAsync<T>(IMongoCollection<T> collection);

        Task<CommentFe> AddComment(string userIdentification, string password, string blogId, string comment);

        Task<bool> DeleteComment(string userIdentification, string password, string blogId, string commentId);

        Task<BlogPostFe> AddBlogPost(string description, string review, MotionPicture motionPicture);

        Task<List<BlogPostFe>> GetAllBlogPosts();

        Task<List<UserDB>> GetAllUsers();
    }
}