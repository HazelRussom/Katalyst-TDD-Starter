using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class StatementLogShould
    {
        [TestMethod]
        public void Be_empty()
        {
            var UnderTest = new StatementLog();

            List<StatementEntry> entries = UnderTest.Entries;

            Assert.AreEqual(0, entries.Count);
        }
    }
}
