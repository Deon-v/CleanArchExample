using CleanArchExample.Application.Common.Interfaces;
using CleanArchExample.Domain.Entities;
using CleanArchExample.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchExample.Infrastructure.Persistence;

public class DataContextInitialiser
{
    private readonly ILogger<DataContextInitialiser> _logger;
    private readonly DataContext _context;

    public DataContextInitialiser(ILogger<DataContextInitialiser> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!await _context.WeatherHistory.AnyAsync())
        {
            _context.WeatherHistory.AddRange(Enumerable.Range(1, 10000).Select(index =>
                {
                    var temprature = Random.Shared.Next(-20, 55);
                    return new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(-index),
                        TemperatureC = temprature
                    };
                })
                .ToArray());

            await _context.SaveChangesAsync();
        }
    }

}