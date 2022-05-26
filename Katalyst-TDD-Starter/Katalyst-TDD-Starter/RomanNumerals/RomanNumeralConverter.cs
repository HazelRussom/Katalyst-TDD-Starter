namespace Katalyst_TDD_Starter.RomanNumerals
{
    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var result = string.Empty;

            while (input >= 10)
            {
                input -= 10;
                result += "X";
            }

            if (input >= 5)
            {
                input -= 5;
                result += "V";
            }

            while (input >= 1)
            {
                input -= 1;
                result += "I";
            }

            return result;
        }
    }
}