using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class StatementLogShould
    {
        private StatementLog UnderTest;
        private Mock<ITimeGetter> TimeGetter;

        public StatementLogShould()
        {
            TimeGetter = new Mock<ITimeGetter>();
            UnderTest = new StatementLog(TimeGetter.Object);

        }

        [TestMethod]
        public void Be_empty()
        {
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(0, entries.Count);
        }

        [TestMethod]
        public void Log_single_100_entry()
        {
            var amount = 100;

            UnderTest.AddEntry(amount);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1, entries.Count);
            Assert.AreEqual(amount, entries[0].Amount);
        }

        [TestMethod]
        public void Log_single_entry_with_time()
        {
            var expectedDate = new DateTime(2012, 01, 14);
            TimeGetter.Setup(x => x.GetTime()).Returns(expectedDate);

            UnderTest.AddEntry(100);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1, entries.Count);
            Assert.AreEqual(expectedDate, entries[0].Timestamp);
        }

        [TestMethod]
        public void Log_multiple_statements()
        {
            UnderTest.AddEntry(1000);
            UnderTest.AddEntry(-500);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(2, entries.Count);
            Assert.AreEqual(1000, entries[0].Amount);
            Assert.AreEqual(-500, entries[1].Amount);
        }

        [TestMethod]
        public void Track_single_entry_balance()
        {
            UnderTest.AddEntry(1000);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1000, entries[0].Balance);
        }

        [TestMethod]
        public void Track_two_entry_balances()
        {
            UnderTest.AddEntry(1000);
            UnderTest.AddEntry(100);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1000, entries[0].Balance);
            Assert.AreEqual(1100, entries[1].Balance);
        }

        [TestMethod]
        public void Track_balances_with_negative_amounts()
        {
            UnderTest.AddEntry(1000);
            UnderTest.AddEntry(-1100);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1000, entries[0].Balance);
            Assert.AreEqual(-100, entries[1].Balance);
        }
    }
}
