namespace Katalyst_TDD_Starter.LeapYear
{
    public class LeapYearExecutor
    {
        public LeapYearExecutor(ILeapYearValidator validator)
        {
            Validator = validator;
        }

        public ILeapYearValidator Validator { get; }

        public void Execute(int year)
        {
            Validator.Validate(year);
        }
    }
}
