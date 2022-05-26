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
        public void Arabic_number_should_become_Roman_numeral_equivalent(int input, string expected)
        {
            var actual = ToTest.Convert(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
