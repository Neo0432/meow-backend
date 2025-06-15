using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PawsBackendDotnet.Data;

namespace PawsBackendDotnet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuthentification(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddOpenApi();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Meow API", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            services.AddDbContext<PawsContext>(options =>
            {
                var dbUser = Environment.GetEnvironmentVariable("DB_USER");
                var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection") +
                            $";Username={Environment.GetEnvironmentVariable("DB_USER")}" +
                            $";Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}");
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

    }
}
