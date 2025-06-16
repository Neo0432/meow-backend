using PawsBackendDotnet.Data.Repositories;
using PawsBackendDotnet.Data.Repositories.Interfaces;

namespace PawsBackendDotnet.Extensions.ServicesExtensions
{
    public static class RepositoriesCollectionExtension
    {
        public static IServiceCollection AddRepositoriesCollection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();

            return services;
        }
    }
}
