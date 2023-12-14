using FrameFiesta.Api;
using FrameFiesta.Authentication;
using FrameFiesta.Contracts.Models;
using FrameFiesta.Database;
using JsonSubTypes;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        RegisterMongoDBMappings();
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            c.UseAllOfToExtendReferenceSchemas();
            c.UseAllOfForInheritance();
            c.UseOneOfForPolymorphism();
            c.SelectDiscriminatorNameUsing(type =>
            {
                return type.Name switch
                {
                    nameof(MotionPicture) => "type",
                    _ => null
                };
            });

            c.SelectDiscriminatorValueUsing(subType =>
            {
                return subType.Name switch
                {
                    nameof(Film) => "film",
                    nameof(Series) => "series",
                    _ => null
                };
            });
        });

        var dataBaseConfiguration = Configuration.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();

        services.AddEndpointsApiExplorer();
        services.AddMvc();
        services.AddDefaultCorsHandling();
        services.AddAuthenticationService();
        services.AddDatabaseService(dataBaseConfiguration);

        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            options.SerializerSettings.Converters.Add(
                JsonSubtypesConverterBuilder
                .Of(typeof(MotionPicture), "type")
                .RegisterSubtype(typeof(Series), MotionPictureEnum.Series)
                .RegisterSubtype(typeof(Film), MotionPictureEnum.Film)
                .SerializeDiscriminatorProperty()
                .Build()
            );
        });
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
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }

    private void RegisterMongoDBMappings()
    {
        BsonSerializer.RegisterDiscriminatorConvention(typeof(MotionPicture), new HierarchicalDiscriminatorConvention("_t"));
        BsonClassMap.RegisterClassMap<MotionPicture>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
        BsonClassMap.RegisterClassMap<Series>(cm => cm.AutoMap());
        BsonClassMap.RegisterClassMap<Film>(cm => cm.AutoMap());
    }
}