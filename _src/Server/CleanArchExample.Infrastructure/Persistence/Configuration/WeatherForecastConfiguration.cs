using CleanArchExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchExample.Infrastructure.Persistence.Configuration;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
    }
}