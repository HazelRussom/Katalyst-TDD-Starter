using System.Text.RegularExpressions;

namespace Katalyst_TDD_Starter.FizzBuzz.Converters
{
    public class FizzBuzzWithDigitsConverter : IFizzBuzzConverter
    {
        public string Convert(int value)
        {
            var result = string.Empty;
            result += ConvertSpecificDigit(value, 3, "Fizz");

            result += ConvertSpecificDigit(value, 5, "Buzz");

            return result.Equals(string.Empty) ? value.ToString() : result;
        }

        private static string ConvertSpecificDigit(int value, int intToConvert, string convertedOutput)
        {
            var result = string.Empty;

            if (value % intToConvert == 0)
            {
                result += convertedOutput;
            }

            var countofDigits = Regex.Matches(value.ToString(), intToConvert.ToString()).Count;
            for (int i = 0; i < countofDigits; i++)
            {
                result += convertedOutput;
            }

            return result;
        }
    }
}
