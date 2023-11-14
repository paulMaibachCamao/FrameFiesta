using FrameFiesta.Contracts.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FrameFiesta.Database
{
    public static class DatabaseDependencyInjection
    {
        public static void AddDatabaseService(this IServiceCollection services, DatabaseConfiguration databaseConfiguration)
        {
            services.AddTransient(x =>  databaseConfiguration);
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<IDatabaseService, DatabaseService>();
        }
    }
}