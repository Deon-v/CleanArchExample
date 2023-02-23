using CleanArchExample.Api.Features.WeatherForecast.Contracts.Requests;
using CleanArchExample.Api.Features.WeatherForecast.Contracts.Responses;
using CleanArchExample.Api.Features.WeatherForecast.Mappers;
using CleanArchExample.Application.Services;
using FastEndpoints;

namespace CleanArchExample.Api.Features.WeatherForecast.Endpoints;

public class GetCityHistoricWeatherEndpoint : Endpoint<GetCityHistoricWeatherRequest, ICollection<GetCityHistoricWeatherResponse>, GetCityHistoricWeatherMapper>
{
    private readonly IWeatherService _weatherService;
    public GetCityHistoricWeatherEndpoint(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }
    public override void Configure()
    {
        Get("/api/weather/history/{City}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCityHistoricWeatherRequest r, CancellationToken ct)
    {
        var weather = await _weatherService.GetHistoricWeatherForecastsAsync(r.City, r.From);
        await SendOkAsync(weather.Select(s => Map.FromEntity(s)).ToArray(), ct);
    }
}