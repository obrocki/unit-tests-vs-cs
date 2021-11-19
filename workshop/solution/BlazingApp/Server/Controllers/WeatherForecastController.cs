using BlazingApp.Server.Services;
using BlazingApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazingApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,                                         
                                         IWeatherForecastService forecastService)
        {
            _logger = logger;
            _forecastService = forecastService;
        }

        [HttpGet("GetV1")]
        public IEnumerable<WeatherForecast> GetV1()
        {
            return _forecastService.GetNextFiveDays();
        }

        [HttpGet("GetV2")]
        public async Task<IActionResult> GetV2()
        {
            try
            {
                return Ok(await Task.FromResult(_forecastService.GetNextFiveDays()));
            }
            catch (Exception)
            {
                return NotFound();
            }            
        }
    }
}