using FrameFiesta.Contracts.Models;
using MongoDB.Driver;

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

        public IMongoCollection<FrameFiestaDocument> GetCollection()
        {
            return GetDatabase().GetCollection<FrameFiestaDocument>(GetDatabaseConfiguration().CollectionName);
        }

        public async Task<bool> UpdateAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, IMongoCollection<T> collection)
        {
            return (await collection.UpdateOneAsync(filter, update).ConfigureAwait(false)).ModifiedCount > 0;
        }

        public DatabaseConfiguration GetConfiguration()
        {
            return _databaseConfiguration;
        }

        public async Task PostAsync(FrameFiestaDocument frameFiestaDocument)
        {
            var collection = _database.GetCollection<FrameFiestaDocument>(_databaseConfiguration.CollectionName);
            await collection.InsertOneAsync(frameFiestaDocument).ConfigureAwait(false);
        }
    }
}