using Katalyst_TDD_Starter.Bank;

namespace Katalyst_TDD_Starter.Test.Bank
{
    public class StatementLog
    {
        public List<StatementEntry> Entries;

        public StatementLog()
        {
            Entries = new List<StatementEntry>();
        }
    }
}