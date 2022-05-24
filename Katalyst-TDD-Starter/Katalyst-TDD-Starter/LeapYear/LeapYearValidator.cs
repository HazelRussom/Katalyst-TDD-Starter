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
            if(input % 4 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
