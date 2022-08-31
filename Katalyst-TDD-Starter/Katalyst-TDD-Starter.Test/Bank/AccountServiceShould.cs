using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class AccountServiceShould
    {
        private Mock<IStatementPrinter> StatementPrinter;
        private Mock<IStatementLog> StatementLog;
        private AccountService UnderTest;

        public AccountServiceShould()
        {
            StatementPrinter = new Mock<IStatementPrinter>();
            StatementLog = new Mock<IStatementLog>();
            UnderTest = new AccountService(StatementPrinter.Object, StatementLog.Object);
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
    }
}
