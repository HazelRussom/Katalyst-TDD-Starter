using Katalyst_TDD_Starter.FizzBuzz.Converters;
using Katalyst_TDD_Starter.Test.Utilities;

namespace Katalyst_TDD_Starter.FizzBuzz
{
    public class FizzBuzzExecutor
    {
        public FizzBuzzExecutor(IFizzBuzzConverter converter, IConsoleWriter logger)
        {
            Converter = converter;
            Logger = logger;
        }

        public IFizzBuzzConverter Converter { get; }
        public IConsoleWriter Logger { get; }

        public void Execute(int limit)
        {
            for(int i = 1; i <= limit; i++)
            {
                var result = Converter.Convert(i);

                Logger.Write(result);
            }
        }
    }
}
