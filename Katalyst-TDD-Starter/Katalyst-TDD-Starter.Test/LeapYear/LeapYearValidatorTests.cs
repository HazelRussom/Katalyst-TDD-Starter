using Katalyst_TDD_Starter.FizzBuzz.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.LeapYear
{
    [TestClass]
    public class LeapYearValidatorTests
    {
        public LeapYearValidator ToTest { get; set; }

        public LeapYearValidatorTests()
        {
            ToTest = new LeapYearValidator();
        }

        [TestMethod]
        [DataRow(1999)]
        [DataRow(2001)]
        public void Validating_a_year_not_divisible_by_four_returns_false(int input)
        {
            var expected = false;
            var actual = ToTest.Validate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
