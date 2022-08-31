using Castle.Core.Logging;
using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class AccountServiceShould
    {
        private Mock<IStatementPrinter> StatementPrinter;
        private Mock<ITimeGetter> TimeGetter;
        private Mock<IStatementLog> StatementLog;
        private AccountService UnderTest;

        public AccountServiceShould()
        {
            StatementPrinter = new Mock<IStatementPrinter>();
            TimeGetter = new Mock<ITimeGetter>();
            StatementLog = new Mock<IStatementLog>();
            UnderTest = new AccountService(StatementPrinter.Object, TimeGetter.Object, StatementLog.Object);
        }

        [TestMethod]
        public void Log_deposited_statement_with_value_of_1000()
        {
            UnderTest.Deposit(1000);

            StatementLog.Verify(x => x.AddEntry(1000), Times.Exactly(1));
        }

        [TestMethod]
        public void Log_withdrawn_statement_with_value_of_1000()
        {
            UnderTest.Withdraw(1000);

            StatementLog.Verify(x => x.AddEntry(-1000), Times.Exactly(1));
        }

        [TestMethod]
        public void Print_statement_log()
        {
            UnderTest.PrintStatement();

            StatementPrinter.Verify(x => x.PrintStatement(It.IsAny<IStatementLog>()), Times.Exactly(1));
        }

        //[TestMethod]
        //public void Print_populated_statement_log()
        //{
        //    List<StatementEntry> printedStatements = null;
        //    StatementPrinter.Setup(x => x.PrintStatement(It.IsAny<List<StatementEntry>>())).Callback<List<StatementEntry>>(r => printedStatements = r);

        //    UnderTest.Deposit(25);
        //    UnderTest.Deposit(43);
        //    UnderTest.PrintStatement();

        //    Assert.AreEqual(2, printedStatements.Count);
        //    Assert.AreEqual(25, printedStatements[0].Amount);
        //    Assert.AreEqual(43, printedStatements[1].Amount);
        //}
    }
}
