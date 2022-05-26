namespace Katalyst_TDD_Starter.RomanNumerals
{
    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var result = string.Empty;

            for(int i = 0; i < input; i++)
            {
                result += "I";
            }

            return result;
        }
    }
}