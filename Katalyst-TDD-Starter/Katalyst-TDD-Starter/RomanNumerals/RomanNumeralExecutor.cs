using Katalyst_TDD_Starter.Test.Utilities;

namespace Katalyst_TDD_Starter.RomanNumerals
{
    public class RomanNumeralExecutor
    {
        public RomanNumeralExecutor(IRomanNumeralConverter converter, IConsoleWriter logger)
        {
            Converter = converter;
            Logger = logger;
        }

        public IRomanNumeralConverter Converter { get; }
        public IConsoleWriter Logger { get; }

        public void Execute(int input)
        {
            Logger.Write(Converter.Convert(input));
        }
    }
}