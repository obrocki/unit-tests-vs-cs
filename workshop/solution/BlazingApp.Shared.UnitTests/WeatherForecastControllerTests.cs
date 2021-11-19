using BlazingApp.Server.Controllers;
using BlazingApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlazingApp.Shared.UnitTests
{
    public class WeatherForecastControllerTests
    {
        private IEnumerable<WeatherForecast> _fiveDayForecastSample;

        public WeatherForecastControllerTests()
        {
            _fiveDayForecastSample = Enumerable.Range(1, 5)
                 .Select(index => new WeatherForecast
                 {
                     Date = DateTime.Now.AddDays(index),
                     TemperatureC = 26,
                     Summary = "Sunny"
                 })
                 .ToArray();
        }

        [Fact]
        public void GetV1_WhenCalled_ReturnsDataRangeForFiveDays()
        {
            // Arrange           
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();

            var mockService = new Mock<IWeatherForecastService>();
            mockService.Setup(service => service.GetNextFiveDays())
                       .Returns(_fiveDayForecastSample);

            // Act
            var controller = new WeatherForecastController(mockLogger.Object, mockService.Object);
            IEnumerable<WeatherForecast>? result = controller.GetV1(); 

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(5, result?.Count());
        }

        [Fact]
        public async Task GetV2_WhenCalled_ReturnsDataRangeForFiveDays()
        {
            // Arrange           
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();

            var mockService = new Mock<IWeatherForecastService>();
            mockService.Setup(service => service.GetNextFiveDays())
                       .Returns(_fiveDayForecastSample);

            // Act
            var controller = new WeatherForecastController(mockLogger.Object, mockService.Object);
            var result = await controller.GetV2(); // returns IEnumerable<WeatherForecast>

            // Assert #1
            var viewResult = Assert.IsType<OkObjectResult>(result);
            // Assert #2
            var model = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(viewResult.Value);
            // Assert #3
            Assert.Equal(5, model.Count());
        }
    }
}