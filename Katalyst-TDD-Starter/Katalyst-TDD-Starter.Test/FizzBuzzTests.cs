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

        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(4, "4")]
        [DataRow(7, "7")]
        [DataTestMethod]
        public void Convert_number_to_default_fizzbuzz_string(int input, string expectedResult)
        {
            string actual = ToTest.Convert(input);

            Assert.AreEqual(expectedResult, actual, $"Fizzbuzz({input}) does not return {expectedResult}.");
        }
    }
}