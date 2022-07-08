using Katalyst_TDD_Starter.Arithmetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Arithmetics
{
    [TestClass]
    public class ArithmeticCalculatorTests
    {
        [TestMethod]
        public void Parentheses_should_return_0()
        {
            var UnderTest = new ArithmeticCalculator();

            var result = UnderTest.Calculate("()");

            Assert.AreEqual(result, "0");
        }

    }
}
