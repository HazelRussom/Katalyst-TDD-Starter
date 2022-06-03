namespace Katalyst_TDD_Starter.Test.Utilities
{
    public interface IConsoleWriter
    {
        public void Write(string message);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}