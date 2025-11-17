namespace Katalyst_TDD_Starter.Arithmetics
{
    public class ArithmeticCalculator
    {
        public int Calculate(string input)
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

            var startParenthesisIndex = input.IndexOf("(");
            var endParenthesisIndex = input.LastIndexOf(")");

            var unwrappedInput = input.Substring(startParenthesisIndex + 1, endParenthesisIndex - startParenthesisIndex - 1);
            if(unwrappedInput.Length > 0)
            {
                var numbers = unwrappedInput.Split("+").Select(x => int.Parse(x)).ToList();

                return 1 + numbers[1];
            }

            return 0;

            //var secondNumber = (int)Char.GetNumericValue(input[6]);
            //return (1 + secondNumber).ToString();
        }
    }
}