namespace Katalyst_TDD_Starter.Bank
{
    public interface IStatementPrinter
    {
        void PrintStatement(IStatementLog statementLog);
        void PrintStatement(List<StatementEntry> statementLog);
    }
}