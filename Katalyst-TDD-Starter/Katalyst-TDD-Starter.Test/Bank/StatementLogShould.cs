using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class StatementLogShould
    {
        [TestMethod]
        public void Be_empty()
        {
            var timeGetter = new Mock<ITimeGetter>();
            var UnderTest = new StatementLog(timeGetter.Object);

            var entries = UnderTest.GetEntries();

            Assert.AreEqual(0, entries.Count);
        }

        [TestMethod]
        public void Log_single_100_entry()
        {
            var timeGetter = new Mock<ITimeGetter>();
            var UnderTest = new StatementLog(timeGetter.Object);
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
            var timeGetter = new Mock<ITimeGetter>();
            timeGetter.Setup(x => x.GetTime()).Returns(expectedDate);
            var UnderTest = new StatementLog(timeGetter.Object);
            var amount = 100;

            UnderTest.AddEntry(amount);
            var entries = UnderTest.GetEntries();

            Assert.AreEqual(1, entries.Count);
            Assert.AreEqual(amount, entries[0].Amount);
            Assert.AreEqual(expectedDate, entries[0].Timestamp);
        }
    }
}
