using CleanArchExample.Api.Features.WeatherForecast.Contracts.Requests;
using CleanArchExample.Api.Features.WeatherForecast.Contracts.Responses;
using FastEndpoints;
using System;

namespace CleanArchExample.Api.Features.WeatherForecast.Mappers;

public class GetCityWeatherMapper : Mapper<GetCityWeatherRequest, GetCityWeatherResponse, Domain.Entities.WeatherForecast>
{
    public override Domain.Entities.WeatherForecast ToEntity(GetCityWeatherRequest r) => new()
    {
    };

    public override GetCityWeatherResponse FromEntity(Domain.Entities.WeatherForecast e) => new()
    {
        TemperatureC = e.TemperatureC,
        Date = e.Date
    };
}