using DataManagement.Application.Interfaces;
using DataManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace DataManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, DataManagementContext>();
            services.AddScoped<DataManagementContext>();
            services.AddScoped<IRecordsRepository, RecordsRepository>();

            return services;
        }
    }
}
