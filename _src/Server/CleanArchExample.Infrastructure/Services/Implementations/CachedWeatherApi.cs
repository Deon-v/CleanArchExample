using CleanArchExample.Application.Services;
using CleanArchExample.Domain.Entities;
using LazyCache;

namespace CleanArchExample.Infrastructure.Services.Implementations;

public class CachedWeatherApi : ICachedWeatherApi
{
    private readonly IWeatherService _weatherService;
    private readonly IAppCache _appCache;

    public CachedWeatherApi(IWeatherService weatherService, IAppCache appCache)
    {
        _weatherService = weatherService;
        _appCache = appCache;
    }

    public async Task<ICollection<WeatherForecast>> GetWeatherForecastsAsync(string city)
    {
        return await _appCache.GetOrAddAsync(city,
            async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
                return await _weatherService.GetWeatherForecastsAsync(city);
            });
    }
}