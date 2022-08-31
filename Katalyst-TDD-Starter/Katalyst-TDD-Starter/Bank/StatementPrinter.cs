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

        public void PrintStatement(IStatementLog statementLog)
        {
            throw new NotImplementedException();
        }

        public void PrintStatement(List<StatementEntry> statementLog)
        {
            consoleLogger.Log("Date || Amount || Balance");

            foreach(var statement in statementLog.OrderByDescending(x => x.Timestamp))
            {
                consoleLogger.Log(BuildStatementMessage(statement));
            }
        }

        private static string BuildStatementMessage(StatementEntry statement)
        {
            return $"{FormatDateTime(statement.Timestamp)} || {statement.Amount} || {statement.Balance}";
        }

        private static string FormatDateTime(DateTime time)
        {
            return time.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}