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

        [DataTestMethod]
        [DataRow(3)]
        [DataRow(63)]
        [DataRow(93)]
        public void Convert_multiples_of_3_with_the_digit_3_to_FizzFizz(int input)
        {
            var expected = "FizzFizz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(13)]
        [DataRow(23)]
        [DataRow(43)]
        public void Convert_numbers_with_the_digit_3_to_Fizz(int input)
        {
            var expected = "Fizz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(331, "FizzFizz")]
        [DataRow(332, "FizzFizz")]
        [DataRow(3331, "FizzFizzFizz")]
        public void Convert_numbers_with_multiple_3_digits(int input, string expected)
        {
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        [DataRow(5, "BuzzBuzz")]
        [DataRow(25, "BuzzBuzz")]
        [DataRow(52, "Buzz")]
        public void Add_a_Buzz_for_each_5_digit(int input, string expected)
        {
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        public void Convert_15_to_FizzBuzzBuzz()
        {
            var input = 15;

            var expected = "FizzBuzzBuzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }

        [DataTestMethod]
        public void Convert_30_to_FizzFizzBuzz()
        {
            var input = 30;

            var expected = "FizzFizzBuzz";
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual, $"Fizzbuzz({input}) does not return {expected}.");
        }
    }
}