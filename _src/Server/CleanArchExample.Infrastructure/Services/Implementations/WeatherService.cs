using CleanArchExample.Application.Services;
using CleanArchExample.Domain.Entities;

namespace CleanArchExample.Infrastructure.Services.Implementations;

public class WeatherService : IWeatherService
{
    public async Task<ICollection<WeatherForecast>> GetWeatherForecastsAsync(string city)
    {
        return Enumerable.Range(1, 10).Select(index =>
            {
                var temprature = Random.Shared.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = temprature
                };
            })
            .ToArray();
    }
}