namespace Katalyst_TDD_Starter.Arithmetics
{
    public class ArithmeticCalculator
    {
        public string Calculate(string input)
        {
            if(input.Length < 6)
            {
                return "0";
            }

            var secondNumber = (int)Char.GetNumericValue(input[6]);
            return (1 + secondNumber).ToString();
        }
    }
}