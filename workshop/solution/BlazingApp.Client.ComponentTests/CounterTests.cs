using Bunit;
using BlazingApp.Client.Pages;
using Xunit;

namespace BlazingApp.Client.ComponentTests
{    
    public class CounterTests
    {
        [Fact]
        public void InitialState()
        {
            // Arrange
            using var ctx = new TestContext();
            var component = ctx.RenderComponent<Counter>();

            // Act
            component.Find("button").Click();

            // Assert
            component.Find("p").MarkupMatches("<p role='status'>Current count: 1</p>");
        }

    }
}
