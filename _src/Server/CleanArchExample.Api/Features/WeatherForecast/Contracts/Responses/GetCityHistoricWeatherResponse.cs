namespace CleanArchExample.Api.Features.WeatherForecast.Contracts.Responses;

public class GetCityHistoricWeatherResponse
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }
}