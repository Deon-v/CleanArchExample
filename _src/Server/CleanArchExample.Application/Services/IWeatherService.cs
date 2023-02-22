using CleanArchExample.Application.Services;
using CleanArchExample.Domain.Entities;

namespace CleanArchExample.Application.Services;

public interface IWeatherService
{
    public Task<ICollection<WeatherForecast>> GetWeatherForecastsAsync(string city);
}