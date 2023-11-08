using FrameFiesta.Contracts.Models;

namespace FrameFiesta.Authentication
{
    public interface IAuthenticationService
    {
        User Login(string userIdentification, string password);
        bool Register (string email, string username, string password);
    }
}