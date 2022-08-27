namespace Katalyst_TDD_Starter.Bank
{
    public class AccountService : IAccountService
    {
        private IStatementPrinter statementPrinter;
        private ITimeGetter timeGetter;

        public AccountService(IStatementPrinter statementPrinter, ITimeGetter timeGetter)
        {
            this.statementPrinter = statementPrinter;
            this.timeGetter = timeGetter;
        }

        public List<StatementEntry> StatementLog { get; set; } = new();

        public void Deposit(int amount)
        {
            var statement = new StatementEntry
            {
                Amount = amount,
                Timestamp = timeGetter.GetTime()
            };

            StatementLog.Add(statement);
        }

        public void PrintStatement()
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int amount)
        {
            StatementLog.Add(new StatementEntry
            {
                Amount = -amount
            });
        }
    }
}