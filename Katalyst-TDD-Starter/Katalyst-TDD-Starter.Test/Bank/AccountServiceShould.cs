using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
        public void Print_expected_statement_header()
        {
            var expected = "Date || Amount || Balance";

            UnderTest.PrintStatement();

            StatementPrinter.Verify(x => x.Print(expected), Times.Exactly(1));
        }
    }
}
