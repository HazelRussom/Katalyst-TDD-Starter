using Katalyst_TDD_Starter.StringCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.StringCalculation
{
    [TestClass]
    public class StringCalculatorTests
    {
        public StringCalculatorTests()
        {
            ToTest = new StringCalculator();
        }

        public StringCalculator ToTest { get; private set; }

        [TestMethod]
        public void No_input_should_return_0()
        {
            var input = string.Empty;

            var expected = 0;
            var actual = ToTest.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow ("1", 1)]
        [DataRow ("5", 5)]
        [DataRow ("20", 20)]
        public void Single_number_inputs_should_return_their_int_value(string input, int expected)
        {
            var actual = ToTest.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1,1", 2)]
        [DataRow("1,0", 1)]
        [DataRow("10,1", 11)]
        [DataRow("10,11", 21)]
        [DataRow("100,2", 102)]
        [DataRow("1,2,3", 6)]
        [DataRow("1,2,3,4,5", 15)]
        [DataRow("1,2,3,4,5,6,7,8,9", 45)]
        [DataRow("1,2,3,4,5,6,7,8,9,10", 55)]
        public void Comma_separated_numbers_should_return_their_summed_value(string input, int expected)
        {
            var actual = ToTest.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow ("1\n1", 2)]
        [DataRow ("1\n2\n3", 6)]
        [DataRow ("1\n2,4", 7)]
        [DataRow ("1,3\n5", 9)]
        [DataRow ("1,3\n5,10", 19)]
        public void Newline_separated_numbers_should_return_their_summed_value(string input, int expected)
        {
            var actual = ToTest.Add(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow ("//;\n1;2", 3)]
        public void Custom_separator_should_split_strings_and_return_summed_value(string input, int expected)
        {
            var actual = ToTest.Add(input);

            Assert.AreEqual (expected, actual);
        }
    }
}
