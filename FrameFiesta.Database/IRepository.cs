using FrameFiesta.Contracts.Models;

namespace FrameFiesta.Database
{
    public interface IRepository
    {
        DatabaseConfiguration GetConfiguration();

        Task<BlogPost> Get(int id);

        Task<bool> Post(BlogPost blog);

        Task<bool> Update(BlogPost blog);

        Task<bool> Delete(int id);

        Task<string> GetSalt(string userIdentification);

        Task<UserDB> Login(string userIdentification, string password);

        Task<bool> Register<T>(RegisterRequest registerRequest);
    }
}