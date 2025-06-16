using Microsoft.EntityFrameworkCore;
using PawsBackendDotnet.Data;

namespace PawsBackendDotnet.Extensions.ServicesExtensions
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

            services.AddDbContextSerice(configuration);

            services.AddAutoMapper(typeof(Program));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddRepositoriesCollection();
            services.AddServicesCollection();

            return services;
        }

    }
}
