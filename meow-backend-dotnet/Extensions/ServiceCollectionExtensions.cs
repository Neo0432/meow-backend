using Microsoft.EntityFrameworkCore;
using PawsBackendDotnet.Data;
using PawsBackendDotnet.Data.Repositories;
using PawsBackendDotnet.Data.Repositories.Interfaces;
using PawsBackendDotnet.Services;
using PawsBackendDotnet.Services.Interfaces;

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

            services.AddSwaggerService(configuration);


            services.AddDbContext<PawsContext>(options =>
            {
                var dbUser = Environment.GetEnvironmentVariable("DB_USER");
                var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection") +
                            $";Username={Environment.GetEnvironmentVariable("DB_USER")}" +
                            $";Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}");
            });

            services.AddAutoMapper(typeof(Program));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
