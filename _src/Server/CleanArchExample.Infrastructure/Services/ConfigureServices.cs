using CleanArchExample.Application.Common.Interfaces;
using CleanArchExample.Application.Services;
using CleanArchExample.Infrastructure.Persistence;
using CleanArchExample.Infrastructure.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchExample.Infrastructure.Services
{
    internal static class ConfigureServices
    {
        internal static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLazyCache();
            services.AddScoped<IWeatherService,WeatherService>();
            services.AddScoped<ICachedWeatherApi,CachedWeatherApi>();

            return services;
        }
    }
}