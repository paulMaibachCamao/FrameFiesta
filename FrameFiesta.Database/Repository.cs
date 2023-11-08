using FrameFiesta.Authentication;
using FrameFiesta.Contracts.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace FrameFiesta.Database
{
    public class Repository : IRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;
        private readonly IMongoDatabase _database;
        private readonly ICryptographyService _cryptographyService;

        public Repository(DatabaseConfiguration databaseConfiguration, ICryptographyService cryptographyService)
        {
            _databaseConfiguration = databaseConfiguration;
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            _database = client.GetDatabase(_databaseConfiguration.DataBaseName);
            _cryptographyService = cryptographyService;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDB> Login(string userIdentification, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register<T>(RegisterRequest registerRequest)
        {
            var collection = _database.GetCollection<T>(_databaseConfiguration.CollectionName);

            var filter = Builders<T>.Filter.Or(
                Builders<T>.Filter.Eq("Name", registerRequest.Name),
                Builders<T>.Filter.Eq("Email", registerRequest.Email)
            );

            var existingUser = (await collection.FindAsync<T>(filter)).FirstOrDefault();

            if (existingUser != null)
            {
                return false;
            }

            var newUser = new UserDB
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Salt = _cryptographyService.GenerateSalt(),
            };

            newUser.Password = _cryptographyService.Hash(registerRequest.Password, newUser.Salt);

            var collectionFrameFiesta = _database.GetCollection<FrameFiestaDocument>(_databaseConfiguration.CollectionName);
            var filterFrameFiesta = Builders<FrameFiestaDocument>.Filter.Eq(doc => doc.Id, "Entities");
            var update = Builders<FrameFiestaDocument>.Update.Push(doc => doc.Users, newUser);
            var result = await collectionFrameFiesta.UpdateOneAsync(filterFrameFiesta, update);

            return result.ModifiedCount > 0;
        }

        public DatabaseConfiguration GetConfiguration()
        {
            return _databaseConfiguration;
        }

        public async Task<string> GetSalt(string userIdentification)
        {
            var collection = _database.GetCollection<FrameFiestaDocument>(_databaseConfiguration.CollectionName);

            var filter = Builders<FrameFiestaDocument>.Filter.ElemMatch(
                doc => doc.Users,
                user => user.Name == userIdentification || user.Email == userIdentification);

            var frameFiestaDocument = collection.Find(filter).FirstOrDefault();

            if (frameFiestaDocument != null)
            {
                var user = frameFiestaDocument.Users.Find(u => u.Name == userIdentification || u.Email == userIdentification);
                if (user != null)
                    return user.Salt;
            }

            return null;
        }

        public Task<bool> Post(BlogPost blog)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(BlogPost blog)
        {
            throw new NotImplementedException();
        }
    }
}