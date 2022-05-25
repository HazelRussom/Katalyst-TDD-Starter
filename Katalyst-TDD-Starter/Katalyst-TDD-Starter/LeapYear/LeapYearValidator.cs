namespace Katalyst_TDD_Starter.FizzBuzz.Converters
{
    public interface ILeapYearValidator
    {
        public bool Validate(int input);
    }

    public class LeapYearValidator : ILeapYearValidator
    {
        public bool Validate(int input)
        {
            if (IsDivisibleBy(input, 100) && !IsDivisibleBy(input, 400))
            {
                return false;
            }

            return IsDivisibleBy(input, 4);
        }

        private static bool IsDivisibleBy(int value, int divideBy)
        {
            return value % divideBy == 0;
        }
    }
}
