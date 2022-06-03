using Katalyst_TDD_Starter.Test.Utilities;

namespace Katalyst_TDD_Starter.LeapYear
{
    public class LeapYearExecutor
    {
        public LeapYearExecutor(ILeapYearValidator validator, IConsoleWriter logger)
        {
            Validator = validator;
            Logger = logger;
        }

        public ILeapYearValidator Validator { get; }
        public IConsoleWriter Logger { get; }

        public void Execute(int year)
        {
            var result = Validator.Validate(year);

            Logger.Write(result.ToString());
        }
    }
}
