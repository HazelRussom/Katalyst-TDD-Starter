using Katalyst_TDD_Starter.Test.Bank;
using System.Globalization;

namespace Katalyst_TDD_Starter.Bank
{
    public class StatementPrinter : IStatementPrinter
    {
        private IConsoleLogger consoleLogger;

        public StatementPrinter(IConsoleLogger consoleLogger)
        {
            this.consoleLogger = consoleLogger;
        }

        public void PrintStatement(List<StatementEntry> statementLog)
        {
            consoleLogger.Log("Date || Amount || Balance");

            if (statementLog.Any())
            {
                consoleLogger.Log($"{statementLog[0].Timestamp.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} || {statementLog[0].Amount} || {statementLog[0].Amount}");
            }
        }
    }
}