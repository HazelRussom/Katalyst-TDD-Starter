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

            Assert.AreEqual(result, "0");
        }

        [TestMethod]
        public void Parentheses_with_1_plus_1_should_calculate_2()
        {
            var UnderTest = new ArithmeticCalculator();

            var result = UnderTest.Calculate("( 1 + 1 )");

            Assert.AreEqual(result, "2");
        }

        [TestMethod]
        public void Parentheses_with_1_plus_2_should_calculate_3()
        {
            var UnderTest = new ArithmeticCalculator();

            var result = UnderTest.Calculate("( 1 + 2 )");

            Assert.AreEqual(result, "3");
        }
    }
}
