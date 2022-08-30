using System.Globalization;

namespace Katalyst_TDD_Starter.Bank
{
    public class AccountService : IAccountService
    {
        private IStatementPrinter statementPrinter;
        private ITimeGetter timeGetter;
        private int currentBalance = 0;

        public AccountService(IStatementPrinter statementPrinter, ITimeGetter timeGetter)
        {
            this.statementPrinter = statementPrinter;
            this.timeGetter = timeGetter;
        }

        public List<StatementEntry> StatementLog { get; set; } = new();

        public void Deposit(int amount)
        {
            currentBalance += amount;

            var statement = new StatementEntry
            {
                Amount = amount,
                Balance = currentBalance,
                Timestamp = timeGetter.GetTime()
            };

            StatementLog.Add(statement);
        }

        public void PrintStatement()
        {
            statementPrinter.PrintStatement(StatementLog);
        }

        public void Withdraw(int amount)
        {
            currentBalance -= amount;

            var statement = new StatementEntry
            {
                Amount = -amount,
                Balance = currentBalance,
                Timestamp = timeGetter.GetTime()
            };

            StatementLog.Add(statement);
        }
    }
}