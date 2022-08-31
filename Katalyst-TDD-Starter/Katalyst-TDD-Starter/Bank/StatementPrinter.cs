using Katalyst_TDD_Starter.Test.Bank;
using System.Globalization;

namespace Katalyst_TDD_Starter.Bank
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IConsoleLogger consoleLogger;

        public StatementPrinter(IConsoleLogger consoleLogger)
        {
            this.consoleLogger = consoleLogger;
        }

        public void PrintStatement(IStatementLog statementLog)
        {
            consoleLogger.Log("Date || Amount || Balance");

            var loggedStatements = statementLog.GetStatements();

            foreach (var statement in InDescendingOrder(loggedStatements))
            {
                consoleLogger.Log(BuildStatementMessage(statement));
            }
        }

        private static IOrderedEnumerable<StatementEntry> InDescendingOrder(List<StatementEntry> entries)
        {
            return entries.OrderByDescending(x => x.Timestamp);
        }

        private static string BuildStatementMessage(StatementEntry statement)
        {
            var time = FormatDateTime(statement.Timestamp);
            var amount = statement.Amount;
            var balance = statement.Balance;

            return $"{time} || {amount} || {balance}";
        }

        private static string FormatDateTime(DateTime time)
        {
            return time.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}