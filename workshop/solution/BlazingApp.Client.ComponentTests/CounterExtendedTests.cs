using BlazingApp.Client.Components;
using Bunit;
using Xunit;

namespace BlazorComponents.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CounterExtendedTests
    {
        [Fact]
        public void InitialState()
        {
            // Arrange
            using var ctx = new TestContext();
            var componentExtended = ctx.RenderComponent<CounterExtended>();            

            // Act
            var element = componentExtended.Find("#divID");

            // Assert
            Assert.Equal("123", element.GetAttribute("data-tab"));
        }
    }
}