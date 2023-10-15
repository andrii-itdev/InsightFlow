using ProcessHub.Services;

namespace ProcessHub.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IProcessService, ProcessService>();

            return services;
        }
    }
}
