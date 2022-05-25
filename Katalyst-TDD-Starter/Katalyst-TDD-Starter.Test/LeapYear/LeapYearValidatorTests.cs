using Katalyst_TDD_Starter.LeapYear;
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
        [DataRow(2002)]
        public void Validating_a_year_not_divisible_by_four_returns_false(int input)
        {
            var expected = false;
            var actual = ToTest.Validate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1996)]
        [DataRow(2004)]
        [DataRow(2008)]
        public void Validating_a_year_divisible_by_four_returns_true(int input)
        {
            var expected = true;
            var actual = ToTest.Validate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1600)]
        [DataRow(2000)]
        public void Validating_a_year_divisible_by_400_returns_true(int input)
        {
            var expected = true;
            var actual = ToTest.Validate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1800)]
        [DataRow(1900)]
        [DataRow(2100)]
        public void Validating_a_year_divisible_by_100_but_not_400_returns_false(int input)
        {
            var expected = false;
            var actual = ToTest.Validate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
