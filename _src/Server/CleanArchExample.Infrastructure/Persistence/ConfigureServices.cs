using CleanArchExample.Application.Common.Interfaces;
using CleanArchExample.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchExample.Infrastructure.Persistence
{
    internal static class ConfigureServices
    {
        internal static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseInMemoryDatabase("DemoDb"));
            }
            else
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<DataContext>());

            services.AddScoped<DataContextInitialiser>();
            return services;
        }
    }
}