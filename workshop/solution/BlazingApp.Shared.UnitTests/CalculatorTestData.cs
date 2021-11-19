using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace BlazingApp.Shared.UnitTests
{
    public class CalculatorTestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 2, 2, 4 };
            yield return new object[] { 3, 3, 6 };
            yield return new object[] { 0, 0, 0 };
            //yield return new object[] { 0, 0, 1 };
        }
    }
}