using FrameFiesta.Contracts.Models;
using FrameFiesta.Database;
using FrameFiesta.Authentication;
using Microsoft.OpenApi.Models;
using FrameFiesta.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        var dataBaseConfiguration = Configuration.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();

        services.AddMvc();
        services.AddDefaultCorsHandling();
        services.AddAuthenticationService();
        services.AddDatabaseService(dataBaseConfiguration);
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }
}