using Katalyst_TDD_Starter.FizzBuzz;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.FizzBuzz
{
    [TestClass]
    public class FizzBuzzConverterTests
    {
        public FizzBuzzConverter ToTest { get; set; }


        public FizzBuzzConverterTests()
        {
            ToTest = new FizzBuzzConverter();
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
        [DataRow(3)]
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
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(25)]
        public void Convert_multiples_of_five_to_Buzz(int input)
        {
            var expected = "Buzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(15)]
        [DataRow(30)]
        [DataRow(45)]
        public void Convert_multiples_of_both_three_and_five_to_FizzBuzz(int input)
        {
            var expected = "FizzBuzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }
    }
}