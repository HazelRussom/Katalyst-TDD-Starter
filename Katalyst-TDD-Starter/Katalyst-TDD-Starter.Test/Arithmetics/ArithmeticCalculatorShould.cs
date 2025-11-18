using Katalyst_TDD_Starter.Arithmetics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Katalyst_TDD_Starter.Test.Arithmetics
{
    [TestClass]
    public class ArithmeticCalculatorShould
    {
        ArithmeticCalculator calculator;

        public ArithmeticCalculatorShould()
        {
            calculator = new ArithmeticCalculator();
        }

        [TestMethod]
        public void Calculate_empty_parenthesis_as_0()
        {
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
            var exception = Assert.ThrowsException<Exception>(() => calculator.Calculate(input));

            Assert.AreEqual(exception.Message, "Invalid record error");
        }

        [TestMethod]
        [DataRow("1")]
        [DataRow("3 + ( 1 + 2 )")]
        public void Throw_when_input_is_not_wrapped_in_parenthesis(string input)
        {
            var exception = Assert.ThrowsException<Exception>(() => calculator.Calculate(input));

            Assert.AreEqual(exception.Message, "Invalid record error");
        }

        [TestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(1, 2, 3)]
        [DataRow(3, 6, 9)]
        public void Sum_two_numbers(int firstNumber, int secondNumber, int expectedResult)
        {
            var actualResult = calculator.Calculate($"({firstNumber} + {secondNumber})");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(2, 1, 1)]
        
        public void Subtract_two_numbers(int firstNumber, int secondNumber, int expectedResult)
        {
            var actualResult = calculator.Calculate($"({firstNumber} - {secondNumber})");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
