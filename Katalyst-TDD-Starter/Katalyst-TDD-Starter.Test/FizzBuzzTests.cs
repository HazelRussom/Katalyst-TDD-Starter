using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test
{
    [TestClass]
    public class FizzBuzzTests
    {
        public FizzBuzz ToTest { get; set; }


        public FizzBuzzTests()
        {
            ToTest = new FizzBuzz();
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
    }
}