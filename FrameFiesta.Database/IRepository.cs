using FrameFiesta.Contracts.Models;
using MongoDB.Driver;

namespace FrameFiesta.Database
{
    public interface IRepository
    {
        DatabaseConfiguration GetConfiguration();

        IMongoCollection<FrameFiestaDocument> GetCollection();

        Task<bool> UpdateAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, IMongoCollection<T> collection);

        Task<string> GetSalt(string userIdentification);

        IMongoDatabase GetDatabase();

        DatabaseConfiguration GetDatabaseConfiguration();

        Task PostAsync(FrameFiestaDocument frameFiestaDocument);
    }
}