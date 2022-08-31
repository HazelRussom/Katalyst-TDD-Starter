using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class StatementLogShould
    {
        [TestMethod]
        public void Be_empty()
        {
            var UnderTest = new StatementLog();

            var entries = UnderTest.GetEntries();

            Assert.AreEqual(0, entries.Count);
        }

        [TestMethod]
        public void Log_single_100_entry()
        {
            var UnderTest = new StatementLog();
            var amount = 100;

            UnderTest.AddEntry(amount);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1, entries.Count);
            Assert.AreEqual(amount, entries[0].Amount);
        }
    }
}
