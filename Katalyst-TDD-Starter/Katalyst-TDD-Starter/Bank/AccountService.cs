namespace Katalyst_TDD_Starter.Bank
{
    public class AccountService : IAccountService
    {
        private readonly IStatementPrinter statementPrinter;
        private readonly ITimeGetter timeGetter;
        private readonly IStatementLog statementLog;

        public AccountService(IStatementPrinter statementPrinter, ITimeGetter timeGetter, IStatementLog statementLog)
        {
            this.statementPrinter = statementPrinter;
            this.timeGetter = timeGetter;
            this.statementLog = statementLog;
        }

        public List<StatementEntry> StatementLog { get; set; } = new();

        public void Deposit(int amount)
        {
            statementLog.AddEntry(amount);
        }

        public void PrintStatement()
        {
            statementPrinter.PrintStatement(statementLog);
        }

        public void Withdraw(int amount)
        {
            statementLog.AddEntry(-amount);
        }
    }
}