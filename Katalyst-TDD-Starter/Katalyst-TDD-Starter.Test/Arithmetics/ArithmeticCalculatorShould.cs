using Katalyst_TDD_Starter.Arithmetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Katalyst_TDD_Starter.Test.Arithmetics
{
    [TestClass]
    public class ArithmeticCalculatorShould
    {
        [TestMethod]
        public void Calculate_empty_parenthesis_as_0()
        {
            var calculator = new ArithmeticCalculator();

            var result = calculator.Calculate("()");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow("(")]
        [DataRow("())")]
        [DataRow("((())")]
        [DataRow(")(")]
        public void Throw_when_parenthesis_do_not_match(string input)
        {
            var calculator = new ArithmeticCalculator();

            var exception = Assert.ThrowsException<Exception>(() => calculator.Calculate(input));

            Assert.AreEqual(exception.Message, "Invalid record error");
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("3 + ( 1 + 2 )")]
        public void Throw_when_input_is_not_wrapped_in_parenthesis(string input)
        {
            var calculator = new ArithmeticCalculator();

            var exception = Assert.ThrowsException<Exception>(() => calculator.Calculate(input));

            Assert.AreEqual(exception.Message, "Invalid record error");
        }

        //[TestMethod]
        //[DataRow("1", "2")]
        //[DataRow("2", "3")]
        //[DataRow("3", "4")]
        //public void Calculate_one_plus_another_number(string numberToAdd, string expectedResult)
        //{
        //    var UnderTest = new ArithmeticCalculator();

        //    var result = UnderTest.Calculate($"( 1 + {numberToAdd} )");

        //    Assert.AreEqual(expectedResult, result);
        //}

        //[TestMethod]
        //[DataRow("1", "2")]
        //[DataRow("2", "3")]
        //[DataRow("3", "4")]
        //public void Calculate_two_numbers_summed(string numberToAdd, string expectedResult)
        //{
        //    var UnderTest = new ArithmeticCalculator();

        //    var result = UnderTest.Calculate($"( 1 + {numberToAdd} )");

        //    Assert.AreEqual(expectedResult, result);
        //}
    }
}
