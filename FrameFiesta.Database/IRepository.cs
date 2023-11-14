using FrameFiesta.Contracts.Models;
using MongoDB.Driver;

namespace FrameFiesta.Database
{
    public interface IRepository
    {
        DatabaseConfiguration GetConfiguration();

        Task<BlogPostDb> Get(int id);

        Task<bool> Post(BlogPostDb blog);

        Task<bool> Update(BlogPostDb blog);

        Task<bool> Delete(int id);

        Task<string> GetSalt(string userIdentification);

        IMongoDatabase GetDatabase();

        DatabaseConfiguration GetDatabaseConfiguration();
        Task PostAsync(FrameFiestaDocument frameFiestaDocument);
    }
}