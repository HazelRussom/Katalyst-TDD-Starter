using Katalyst_TDD_Starter.Arithmetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Arithmetics
{
    [TestClass]
    public class ArithmeticCalculatorTests
    {
        [TestMethod]
        public void Empty_parentheses_should_calculate_0()
        {
            var UnderTest = new ArithmeticCalculator();

            var result = UnderTest.Calculate("()");

            Assert.AreEqual("0", result);
        }

        [TestMethod]
        [DataRow("1", "2")]
        [DataRow("2", "3")]
        [DataRow("3", "4")]
        public void Parentheses_with_1_plus_another_number_should_calculate_expected_result(string numberToAdd, string expectedResult)
        {
            var UnderTest = new ArithmeticCalculator();

            var result = UnderTest.Calculate($"( 1 + {numberToAdd} )");

            Assert.AreEqual(expectedResult, result);
        }
    }
}
