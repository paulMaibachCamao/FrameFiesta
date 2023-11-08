namespace FrameFiesta.Api
{
    public static class ApiCorsDependencyInjection
    {
        public static void AddDefaultCorsHandling(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .DisallowCredentials();
                });
            });
        }
    }
}
