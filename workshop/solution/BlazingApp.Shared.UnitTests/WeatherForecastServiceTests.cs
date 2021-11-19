using BlazingApp.Server.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlazingApp.Shared.UnitTests
{
    public class WeatherForecastServiceTests
    {
        [Fact]
        public void GetNextFiveDays_WhenCalled_ReturnRangeWithFiveItems()
        {
            // Arrange
            var mockCityRepository = new Mock<ICityRepository>();
            var dateTimeProvider = new Mock<IDateTimeProvider>();

            var service = new WeatherForecastService(mockCityRepository.Object,
                                                     dateTimeProvider.Object);

            // Act
            IEnumerable<WeatherForecast> forecasts = service.GetNextFiveDays();


            // Assert            
            forecasts.Should().HaveCount(4).And.NotBeEmpty();
        }

        [Fact]
        public void GetNextFiveDays_GivenReferenceDate_WhenCalled_ReturnValidRageBasedOnReferenceDate()
        {
            // Arrange
            var referenceDate = new DateTime(2020, 1, 1);

            var mockCityRepository = new Mock<ICityRepository>();

            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider.Setup(provider => provider.GetNow())
                            .Returns(referenceDate);

            var service = new WeatherForecastService(mockCityRepository.Object,
                                                     dateTimeProvider.Object);

            // Act
            IEnumerable<WeatherForecast> forecasts = service.GetNextFiveDays();

            // Assert                        
            forecasts.First().Date.Should().Be(referenceDate);
        }
    }

    /*
     
    Example: Xamarin.Native and/or Xamarin.Forms

    What are we testing?

        public class LoginViewModel
        {
           public ICommand Login { get; set; }      
        }

    How?

        var mockLoginCommand = new Mock<ICommand>();

        var cut = new LoginViewModel { Login = mockLoginCommand.Object };

        mockLoginCommand.Verify(cmd => cmd.Execute(It.IsAny<object>()));
    

     */  
}
