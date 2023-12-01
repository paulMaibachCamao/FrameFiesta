using FrameFiesta.Contracts.Models;
using MongoDB.Driver;

namespace FrameFiesta.Database
{
    public interface IRepository
    {
        DatabaseConfiguration GetConfiguration();

        IMongoCollection<FrameFiestaDocument> GetCollection();

        Task<bool> UpdateAsync<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, IMongoCollection<T> collection);

        IMongoDatabase GetDatabase();

        DatabaseConfiguration GetDatabaseConfiguration();

        Task PostAsync(FrameFiestaDocument frameFiestaDocument);
    }
}