using System;
using Xunit;

namespace BlazingApp.Shared.UnitTests
{
    public class CalculatorTests
    {

        [Fact]
        public void CalculatorNullTest_Xunit()
        {
            var calculator = new Calculator();

            Xunit.Assert.NotNull(calculator);
        }


        [Fact]
        public void Add_GivenTwoNumbers_ReturnsValidSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(1, 1);

            // Assert
            Assert.Equal(2, actual);
        }


        [Fact]
        public void SubtractTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Subtract(1, 1);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void MultiplyTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Multiply(1, 1);

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        public void DivideTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Divide(1, 1);

            // Assert
            Assert.Equal(1, actual);
        }

        [Fact]
        public void DevideByZeroTest_ReturnsNull()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.TryDivide(1, 0);

            // Assert            
            Assert.Null(actual);
        }

        [Fact(Skip = "Current implementation returns null and handles the exception internally.")]
        public void DevideByZeroTest_ThrowsDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            Action division = () => calculator.TryDivide(1, 0);

            // Assert
            Assert.Throws<DivideByZeroException>(division);
        }

        /* 
        Using Microsoft.VisualStudio.TestTools.UnitTesting
        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 6)]
        [DataRow(0, 0, 1)] // The test run with this row fails

        [Microsoft.VisualStudio.TestTools.UnitTesting.DataTestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DynamicData(nameof(CalculatorTestData.GetData),
                     Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataSourceType.Method)]

        */
        //[Theory]
        //[InlineData(1,1,2)]
        //[InlineData(2, 2, 4)]
        //[InlineData(3, 3, 6)]
        //[InlineData(0, 0, 0)]
        //[InlineData(0, 0, 1)]

        [Theory]
        [CalculatorTestData]
        public void AddDataTests(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(x, y);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
        }
    }
}