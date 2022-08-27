using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class AccountServiceShould
    {
        [TestMethod]
        public void Log_statement_with_value_of_1000()
        {
            var statementPrinter = new Mock<IStatementPrinter>();
            var timeGetter = new Mock<ITimeGetter>();
            var UnderTest = new AccountService(statementPrinter.Object, timeGetter.Object);

            UnderTest.Deposit(1000);

            Assert.IsTrue(UnderTest.StatementLog[0].Amount == 1000);
        }

        [TestMethod]
        public void Track_statements_in_correct_order()
        {
            var statementPrinter = new Mock<IStatementPrinter>();
            var timeGetter = new Mock<ITimeGetter>();
            var UnderTest = new AccountService(statementPrinter.Object, timeGetter.Object);

            UnderTest.Deposit(1000);
            UnderTest.Deposit(2000);

            Assert.IsTrue(UnderTest.StatementLog[0].Amount == 1000);
            Assert.AreEqual(2000, UnderTest.StatementLog[1].Amount);
        }

        [TestMethod]
        public void Track_expected_statement_timestamp()
        {
            var statementPrinter = new Mock<IStatementPrinter>();
            var timeGetter = new Mock<ITimeGetter>();
            var expected = new DateTime(2012, 01, 14);

            timeGetter.Setup(x => x.GetTime()).Returns(expected);
            var UnderTest = new AccountService(statementPrinter.Object, timeGetter.Object);

            UnderTest.Deposit(1000);
            Assert.AreEqual(expected, UnderTest.StatementLog[0].Timestamp);
        }
    }
}
