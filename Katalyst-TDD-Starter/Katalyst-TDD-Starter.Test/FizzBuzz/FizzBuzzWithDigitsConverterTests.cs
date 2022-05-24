using Katalyst_TDD_Starter.FizzBuzz.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.FizzBuzz
{
    [TestClass]
    public class FizzBuzzWithDigitsConverterTests
    {
        public FizzBuzzWithDigitsConverter ToTest { get; set; }


        public FizzBuzzWithDigitsConverterTests()
        {
            ToTest = new FizzBuzzWithDigitsConverter();
        }

        [DataTestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(4, "4")]
        [DataRow(7, "7")]
        public void Convert_number_to_default_fizzbuzz_string(int input, string expectedResult)
        {
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expectedResult, actual, $"Fizzbuzz({input}) does not return {expectedResult}.");
        }


        [DataTestMethod]
        [DataRow(6)]
        [DataRow(9)]
        [DataRow(27)]
        public void Convert_multiples_of_three_to_Fizz(int input)
        {
            var expected = "Fizz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(110)]
        public void Convert_multiples_of_five_to_Buzz(int input)
        {
            var expected = "Buzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(60)]
        [DataRow(90)]
        [DataRow(120)]
        public void Convert_multiples_of_both_three_and_five_to_FizzBuzz(int input)
        {
            var expected = "FizzBuzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }
    }
}