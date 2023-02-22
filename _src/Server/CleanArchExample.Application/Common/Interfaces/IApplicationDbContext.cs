using System.Collections.Generic;
using CleanArchExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchExample.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<WeatherForecast> WeatherForecasts { get; }
}