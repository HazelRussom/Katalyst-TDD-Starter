using Katalyst_TDD_Starter.RomanNumerals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.RomanNumerals
{
    [TestClass]
    public class RomanNumeralConverterTest
    {
        public RomanNumeralConverterTest()
        {
            ToTest = new RomanNumeralConverter();
        }

        public RomanNumeralConverter ToTest { get; private set; }

        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(3, "III")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(7, "VII")]
        [DataRow(8, "VIII")]
        [DataRow(10, "X")]
        [DataRow(11, "XI")]
        [DataRow(12, "XII")]
        [DataRow(13, "XIII")]
        [DataRow(15, "XV")]
        [DataRow(16, "XVI")]
        [DataRow(20, "XX")]
        [DataRow(26, "XXVI")]
        [DataRow(30, "XXX")]
        public void Arabic_number_should_become_Roman_numeral_equivalent(int input, string expected)
        {
            var actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
