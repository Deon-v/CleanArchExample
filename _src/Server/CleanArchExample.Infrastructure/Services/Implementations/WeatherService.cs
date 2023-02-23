using CleanArchExample.Application.Services;
using CleanArchExample.Domain.Entities;
using CleanArchExample.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchExample.Infrastructure.Services.Implementations;

public class WeatherService : IWeatherService
{
    private readonly DataContext _dataContext;
    public WeatherService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ICollection<WeatherForecast>> GetHistoricWeatherForecastsAsync(string city, DateTime from)
    {
        return await _dataContext.WeatherHistory//.Where(w => w.Date >= from)
            .ToArrayAsync();
    }

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