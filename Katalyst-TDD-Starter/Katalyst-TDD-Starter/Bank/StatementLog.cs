using Katalyst_TDD_Starter.Bank;

namespace Katalyst_TDD_Starter.Test.Bank
{
    public class StatementLog : IStatementLog
    {
        private readonly ITimeGetter timeGetter;
        private readonly List<StatementEntry> entries;
        private int currentBalance = 0;

        public StatementLog(ITimeGetter timeGetter)
        {
            entries = new List<StatementEntry>();
            this.timeGetter = timeGetter;
        }

        public void AddEntry(int amount)
        {
            currentBalance += amount;

            entries.Add(new StatementEntry
            {
                Amount = amount,
                Timestamp = timeGetter.GetTime(),
                Balance = currentBalance
            });
        }

        public List<StatementEntry> GetEntries()
        {
            return entries;
        }
    }
}