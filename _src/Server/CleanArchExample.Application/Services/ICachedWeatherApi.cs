using CleanArchExample.Domain.Entities;

namespace CleanArchExample.Application.Services;

public interface ICachedWeatherApi
{
    public Task<ICollection<WeatherForecast>> GetWeatherForecastsAsync(string city);
}