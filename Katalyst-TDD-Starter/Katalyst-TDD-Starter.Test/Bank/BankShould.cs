using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class BankShould
    {
        [TestMethod]
        [Ignore]
        public void Print_statement_with_deposit_and_withdrawal_history()
        {
            var consoleLogger = new Mock<IConsoleLogger>();
            var timeGetter = new Mock<ITimeGetter>();
            var statementPrinter = new StatementPrinter(consoleLogger.Object);
            IAccountService UnderTest = new AccountService(statementPrinter, timeGetter.Object);

            //Given a client makes a deposit of 1000 on 10-01-2012
            UnderTest.Deposit(1000);

            //And a deposit of 2000 on 13-01-2012
            UnderTest.Deposit(2000);

            //And a withdrawal of 500 on 14-01-2012
            UnderTest.Withdraw(500);

            //When they print their bank statement
            UnderTest.PrintStatement();

            //Then they would see:
            //Date       || Amount || Balance
            consoleLogger.Verify(x => x.Log(It.Is<string>(x => x.Contains("Date || Amount || Balance"))));
            //14/01/2012 || -500   || 2500
            consoleLogger.Verify(x => x.Log(It.Is<string>(x => x.Contains("14/01/2012 || -500 || 2500"))));
            //13/01/2012 || 2000   || 3000
            consoleLogger.Verify(x => x.Log(It.Is<string>(x => x.Contains("13/01/2012 || 2000 || 3000"))));
            //10/01/2012 || 1000   || 1000
            consoleLogger.Verify(x => x.Log(It.Is<string>(x => x.Contains("10/01/2012 || 1000 || 1000"))));
        }
    }
}
