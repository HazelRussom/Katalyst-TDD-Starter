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

            var output = $"{year} is a valid leap year.";

            if (!result)
            {
                output = $"{year} is not a valid leap year.";
            }

            Logger.Write(output);
        }
    }
}
