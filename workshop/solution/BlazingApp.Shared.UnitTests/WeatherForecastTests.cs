using Xunit;
using FluentAssertions;

namespace BlazingApp.Shared.UnitTests
{    
    public class WeatherForecastTests
    {
        [Fact]
        public void WeatherForecast_WhenConvertinFromTemperatureC_ReturnsValidTemperatureF()
        {
            // Arrange
            var forecast = new WeatherForecast();

            // Act
            forecast.TemperatureC = 26;

            // Assert            
            forecast.TemperatureF.Should().Be(78).And.NotBe(0).And.NotBe(26);            
        }
    }
}