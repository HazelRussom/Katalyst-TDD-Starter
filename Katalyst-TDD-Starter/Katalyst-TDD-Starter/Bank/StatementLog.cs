using Katalyst_TDD_Starter.Bank;

namespace Katalyst_TDD_Starter.Test.Bank
{
    public class StatementLog : IStatementLog
    {
        private readonly ITimeGetter timeGetter;
        private readonly List<StatementEntry> entries;

        public StatementLog(ITimeGetter timeGetter)
        {
            entries = new List<StatementEntry>();
            this.timeGetter = timeGetter;
        }

        public void AddEntry(int amount)
        {
            entries.Add(new StatementEntry
            {
                Amount = amount,
                Timestamp = timeGetter.GetTime(),
                Balance = 1000
            });
        }

        public List<StatementEntry> GetEntries()
        {
            return entries;
        }
    }
}