using PawsBackendDotnet.Services;
using PawsBackendDotnet.Services.Interfaces;

namespace PawsBackendDotnet.Extensions.ServicesExtensions
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddServicesCollection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPetService, PetService>();

            return services;
        }
    }
}
