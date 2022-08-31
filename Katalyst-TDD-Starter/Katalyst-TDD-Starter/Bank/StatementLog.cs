using Katalyst_TDD_Starter.Bank;

namespace Katalyst_TDD_Starter.Test.Bank
{
    public class StatementLog : IStatementLog
    {
        private List<StatementEntry> Entries;

        public StatementLog()
        {
            Entries = new List<StatementEntry>();
        }

        public void AddEntry(int amount)
        {
            Entries.Add(new StatementEntry
            {
                Amount = amount
            });
        }

        public List<StatementEntry> GetEntries()
        {
            return Entries;
        }
    }
}