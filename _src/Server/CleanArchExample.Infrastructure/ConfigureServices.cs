using CleanArchExample.Infrastructure.Persistence;
using CleanArchExample.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchExample.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceServices(configuration);
            services.AddExternalServices(configuration);
            return services;
        }
    }
}