namespace Katalyst_TDD_Starter.RomanNumerals
{
    public enum RomanNumerals
    {
        NotSpecified = 0,
        I = 1,
        V = 5,
        X = 10,
    }

    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var result = string.Empty;

            ConvertGivenCharacter(ref input, ref result, RomanNumerals.X);
            ConvertGivenCharacter(ref input, ref result, RomanNumerals.V);
            ConvertGivenCharacter(ref input, ref result, RomanNumerals.I);

            return result;
        }

        private static void ConvertGivenCharacter(ref int input, ref string result, RomanNumerals numeral)
        {
            var number = (int)numeral;

            while (input >= number)
            {
                input -= number;
                result += numeral;
            }
        }
    }
}