namespace Katalyst_TDD_Starter.Bank
{
    public class AccountService : IAccountService
    {
        private readonly IStatementPrinter statementPrinter;
        private readonly IStatementLog statementLog;

        public AccountService(IStatementPrinter statementPrinter, IStatementLog statementLog)
        {
            this.statementPrinter = statementPrinter;
            this.statementLog = statementLog;
        }

        public void Deposit(int amount)
        {
            statementLog.AddEntry(amount);
        }

        public void Withdraw(int amount)
        {
            statementLog.AddEntry(-amount);
        }

        public void PrintStatement()
        {
            statementPrinter.PrintStatement(statementLog);
        }
    }
}