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
        private AccountService UnderTest;

        public AccountServiceShould()
        {
            StatementPrinter = new Mock<IStatementPrinter>();
            TimeGetter = new Mock<ITimeGetter>();
            UnderTest = new AccountService(StatementPrinter.Object, TimeGetter.Object);
        }

        [TestMethod]
        public void Log_deposited_statement_with_value_of_1000()
        {
            UnderTest.Deposit(1000);

            Assert.AreEqual(1000, UnderTest.StatementLog[0].Amount);
        }

        [TestMethod]
        public void Track_deposited_statements_in_correct_order()
        {
            UnderTest.Deposit(1000);
            UnderTest.Deposit(2000);

            Assert.AreEqual(1000, UnderTest.StatementLog[0].Amount);
            Assert.AreEqual(2000, UnderTest.StatementLog[1].Amount);
        }

        [TestMethod]
        public void Track_expected_deposit_statement_timestamp()
        {
            var expected = new DateTime(2012, 01, 14);
            TimeGetter.Setup(x => x.GetTime()).Returns(expected);

            UnderTest.Deposit(1000);

            Assert.AreEqual(expected, UnderTest.StatementLog[0].Timestamp);
        }

        [TestMethod]
        public void Log_withdrawal_statement_with_value_of_500()
        {
            UnderTest.Withdraw(500);

            Assert.AreEqual(-500, UnderTest.StatementLog[0].Amount);
        }

        [TestMethod]
        public void Log_withdrawal_statement_with_value_of_1000()
        {
            UnderTest.Withdraw(1000);

            Assert.AreEqual(-1000, UnderTest.StatementLog[0].Amount);
        }

        [TestMethod]
        public void Track_history_of_multiple_withdrawals()
        {
            UnderTest.Withdraw(100);
            UnderTest.Withdraw(500);

            Assert.AreEqual(-100, UnderTest.StatementLog[0].Amount);
            Assert.AreEqual(-500, UnderTest.StatementLog[1].Amount);
        }

        [TestMethod]
        public void Track_expected_timestamp_of_withdrawal()
        {
            var expected = new DateTime(2010, 01, 04);
            TimeGetter.Setup(x => x.GetTime()).Returns(expected);

            UnderTest.Withdraw(1);

            Assert.AreEqual(expected, UnderTest.StatementLog[0].Timestamp);
        }

        [TestMethod]
        public void Track_total_balance()
        {
            UnderTest.Deposit(1000);
            UnderTest.Withdraw(100);
            UnderTest.Withdraw(500);

            Assert.AreEqual(1000, UnderTest.StatementLog[0].Balance);
            Assert.AreEqual(900, UnderTest.StatementLog[1].Balance);
            Assert.AreEqual(400, UnderTest.StatementLog[2].Balance);
        }

        [TestMethod]
        public void Print_empty_statement_log()
        {
            UnderTest.PrintStatement();

            StatementPrinter.Verify(x => x.PrintStatement(It.IsAny<List<StatementEntry>>()), Times.Exactly(1));
        }

        [TestMethod]
        public void Print_populated_statement_log()
        {
            List<StatementEntry> printedStatements = null;
            StatementPrinter.Setup(x => x.PrintStatement(It.IsAny<List<StatementEntry>>())).Callback<List<StatementEntry>>(r => printedStatements = r);

            UnderTest.Deposit(25);
            UnderTest.Deposit(43);
            UnderTest.PrintStatement();

            Assert.AreEqual(2, printedStatements.Count);
            Assert.AreEqual(25, printedStatements[0].Amount);
            Assert.AreEqual(43, printedStatements[1].Amount);
        }
    }
}
