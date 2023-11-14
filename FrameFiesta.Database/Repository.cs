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

        public Repository(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
            var client = new MongoClient(_databaseConfiguration.ConnectionString);
            _database = client.GetDatabase(_databaseConfiguration.DataBaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public DatabaseConfiguration GetDatabaseConfiguration()
        {
            return _databaseConfiguration;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPostDb> Get(int id)
        {
            throw new NotImplementedException();
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

        public Task<bool> Post(BlogPostDb blog)
        {
            throw new NotImplementedException();
        }

        public async Task PostAsync(FrameFiestaDocument frameFiestaDocument)
        {
            var collection = _database.GetCollection<FrameFiestaDocument>(_databaseConfiguration.CollectionName);
            await collection.InsertOneAsync(frameFiestaDocument);
        }

        public Task<bool> Update(BlogPostDb blog)
        {
            throw new NotImplementedException();
        }
    }
}