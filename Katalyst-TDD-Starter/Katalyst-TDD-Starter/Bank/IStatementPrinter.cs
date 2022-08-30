namespace Katalyst_TDD_Starter.Bank
{
    public interface IStatementPrinter
    {
        void PrintStatement(List<StatementEntry> statementLog);
    }
}