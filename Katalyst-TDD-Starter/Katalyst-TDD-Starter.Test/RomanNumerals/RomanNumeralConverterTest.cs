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
        [DataRow(4, "IV")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(9, "IX")]
        [DataRow(10, "X")]
        [DataRow(13, "XIII")]
        [DataRow(14, "XIV")]
        [DataRow(15, "XV")]
        [DataRow(16, "XVI")]
        [DataRow(20, "XX")]
        [DataRow(26, "XXVI")]
        [DataRow(30, "XXX")]
        [DataRow(38, "XXXVIII")]
        [DataRow(40, "XL")]
        [DataRow(50, "L")]
        [DataRow(86, "LXXXVI")]
        [DataRow(100, "C")]
        [DataRow(382, "CCCLXXXII")]
        [DataRow(500, "D")]
        [DataRow(800, "DCCC")]
        [DataRow(1000, "M")]
        [DataRow(2371, "MMCCCLXXI")]
        public void Arabic_number_should_become_Roman_numeral_equivalent(int input, string expected)
        {
            var actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
