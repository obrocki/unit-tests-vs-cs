using BlazingApp.Shared;

namespace BlazingApp.Server.Services
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetNextFiveDays();
    }
}