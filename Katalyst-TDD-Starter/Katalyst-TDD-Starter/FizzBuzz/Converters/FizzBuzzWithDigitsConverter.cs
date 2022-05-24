namespace Katalyst_TDD_Starter.FizzBuzz.Converters
{
    public class FizzBuzzWithDigitsConverter : IFizzBuzzConverter
    {
        public string Convert(int value)
        {
            var result = string.Empty;

            if (value % 3 == 0)
            {
                result += "Fizz";
            }

            if (value % 5 == 0)
            {
                result += "Buzz";
            }

            return result.Equals(string.Empty) ? value.ToString() : result;
        }
    }
}
