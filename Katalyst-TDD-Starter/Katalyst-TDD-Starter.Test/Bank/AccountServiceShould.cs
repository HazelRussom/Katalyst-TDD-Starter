using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class AccountServiceShould
    {
        private Mock<ITimeGetter> TimeGetter;
        private AccountService UnderTest;

        public AccountServiceShould()
        {
            var statementPrinter = new Mock<IStatementPrinter>();
            TimeGetter = new Mock<ITimeGetter>();
            UnderTest = new AccountService(statementPrinter.Object, TimeGetter.Object);
        }
        
        [TestMethod]
        public void Log_deposited_statement_with_value_of_1000()
        {
            UnderTest.Deposit(1000);

            Assert.IsTrue(UnderTest.StatementLog[0].Amount == 1000);
        }

        [TestMethod]
        public void Track_deposited_statements_in_correct_order()
        {
            UnderTest.Deposit(1000);
            UnderTest.Deposit(2000);

            Assert.IsTrue(UnderTest.StatementLog[0].Amount == 1000);
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
    }
}
