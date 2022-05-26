namespace Katalyst_TDD_Starter.RomanNumerals
{
    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            if (input == 4)
            {
                return "IV";
            }

            var result = string.Empty;

            var five_Count = input / 5;

            for(int i = 0; i < five_Count; i++)
            {
                result += "V";
                input -= 5;
            }

            for(int i = 0; i < input; i++)
            {
                result += "I";
            }

            return result;
        }
    }
}