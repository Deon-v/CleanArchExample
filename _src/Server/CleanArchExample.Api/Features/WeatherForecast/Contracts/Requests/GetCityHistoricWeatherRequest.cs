namespace CleanArchExample.Api.Features.WeatherForecast.Contracts.Requests;

public class GetCityHistoricWeatherRequest
{
    public string City { get; set; }
    public DateTime From { get; set; }
}