using BlazingApp.Shared;

namespace BlazingApp.Server.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };        

        public WeatherForecastService(ICityRepository cityRepository,
                                      IDateTimeProvider dateTimeProvider)
        {
            _cityRepository = cityRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public IEnumerable<WeatherForecast> GetNextFiveDays()
        {
            return Enumerable.Range(0, 4)
                             .Select(index => new WeatherForecast
                             {
                                 Date = _dateTimeProvider.GetNow().AddDays(index),
                                 TemperatureC = Random.Shared.Next(-20, 55),
                                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                             })
                             .ToArray();
        }
    }
}