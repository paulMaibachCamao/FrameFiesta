using Microsoft.Extensions.DependencyInjection;

namespace FrameFiesta.Authentication
{
    public static class AuthenticationDependencyInjection
    {
        public static void AddAuthenticationService(this IServiceCollection services)
        {
            services.AddSingleton<ICryptographyService, CryptographyService>();
        }
    }
}