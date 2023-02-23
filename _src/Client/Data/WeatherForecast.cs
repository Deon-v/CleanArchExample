using CleanArchExample.Client.Enums;

namespace CleanArchExample.Client.Data;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }


    public ForecastScale? Summary => TemperatureC switch
    {
        <= 10 => ForecastScale.Freezing,
        > 10 and <= 18 => ForecastScale.Chilly,
        > 18 and <= 25 => ForecastScale.Mild,
        > 25 and <= 32 => ForecastScale.Warm,
        > 32 => ForecastScale.Hell
    };

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}