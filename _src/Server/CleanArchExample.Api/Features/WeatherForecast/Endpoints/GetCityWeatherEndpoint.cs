using CleanArchExample.Api.Features.WeatherForecast.Contracts.Requests;
using CleanArchExample.Api.Features.WeatherForecast.Contracts.Responses;
using CleanArchExample.Api.Features.WeatherForecast.Mappers;
using CleanArchExample.Application.Services;
using FastEndpoints;

namespace CleanArchExample.Api.Features.WeatherForecast.Endpoints;

public class GetCityWeatherEndpoint : Endpoint<GetCityWeatherRequest, ICollection<GetCityWeatherResponse>, GetCityWeatherMapper>
{
    private readonly ICachedWeatherApi _cachedWeatherApi;
    public GetCityWeatherEndpoint(ICachedWeatherApi cachedWeatherApi)
    {
        _cachedWeatherApi = cachedWeatherApi;
    }
    public override void Configure()
    {
        Get("/api/Weather/live/{City}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCityWeatherRequest r, CancellationToken ct)
    {
        var weather = await _cachedWeatherApi.GetWeatherForecastsAsync(r.City);
        await SendOkAsync(weather.Select(s => Map.FromEntity(s)).ToArray(), ct);
    }
}