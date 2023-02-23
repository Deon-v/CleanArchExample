using CleanArchExample.Api.Features.WeatherForecast.Contracts.Requests;
using CleanArchExample.Api.Features.WeatherForecast.Contracts.Responses;
using FastEndpoints;

namespace CleanArchExample.Api.Features.WeatherForecast.Mappers;

public class GetCityHistoricWeatherMapper : Mapper<GetCityHistoricWeatherRequest, GetCityHistoricWeatherResponse, Domain.Entities.WeatherForecast>
{
    public override Domain.Entities.WeatherForecast ToEntity(GetCityHistoricWeatherRequest r) => new()
    {
    };

    public override GetCityHistoricWeatherResponse FromEntity(Domain.Entities.WeatherForecast e) => new()
    {
        Id = e.Id,
        TemperatureC = e.TemperatureC,
        Date = e.Date
    };
}