using Infrastructure.Utilities;

namespace ProcessHub.Extensions
{
    using ProcessHub.API.Repositories;
    using ProcessHub.Services;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProcessService, ProcessService>();
            services.AddSingleton<IProcessesRedisRepository, ProcessesRedisRepository>();

            return services;
        }

        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(servicesProvider =>
            {
                return ConnectionFactory.CreateConnection(configuration);
            });

            return services;
        }

    }
}
