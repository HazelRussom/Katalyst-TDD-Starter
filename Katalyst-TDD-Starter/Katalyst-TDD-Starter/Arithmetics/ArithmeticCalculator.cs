namespace Katalyst_TDD_Starter.Arithmetics
{
    public class ArithmeticCalculator
    {
        public string Calculate(string input)
        {
            var openParenthesisCount = input.Count(x => x.Equals('('));
            var closeParenthesisCount = input.Count(x => x.Equals(')'));

            if (openParenthesisCount != closeParenthesisCount)
            {
                throw new Exception("Invalid record error");
            }

            if(input.First() != '(' || input.Last() != ')') {
                throw new Exception("Invalid record error");
            }

            return "0";

            //var secondNumber = (int)Char.GetNumericValue(input[6]);
            //return (1 + secondNumber).ToString();
        }
    }
}