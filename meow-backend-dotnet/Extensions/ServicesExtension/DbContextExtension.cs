using Microsoft.EntityFrameworkCore;
using PawsBackendDotnet.Data;

namespace PawsBackendDotnet.Extensions.ServicesExtensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextSerice(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PawsContext>(options =>
            {
                var dbUser = Environment.GetEnvironmentVariable("DB_USER");
                var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection") +
                            $";Username={Environment.GetEnvironmentVariable("DB_USER")}" +
                            $";Password={Environment.GetEnvironmentVariable("DB_PASSWORD")}");
            });

            return services;
        }
    }
}
