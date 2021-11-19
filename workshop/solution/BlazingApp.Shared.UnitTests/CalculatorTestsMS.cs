namespace BlazingApp.Shared.UnitTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class CalculatorTestsMS
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void CalculatorNullTest_MsTest()
        {
            var calculator = new Calculator();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(calculator);
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void AddTestMS()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(1, 1);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, actual);
        }
    }
}