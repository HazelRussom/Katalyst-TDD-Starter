namespace Katalyst_TDD_Starter.Arithmetics
{
    public class ArithmeticCalculator
    {
        public double Calculate(string input)
        {
            var openParenthesisCount = input.Count(x => x.Equals('('));
            var closeParenthesisCount = input.Count(x => x.Equals(')'));

            if (openParenthesisCount != closeParenthesisCount)
            {
                throw new Exception("Invalid record error");
            }

            if (input.First() != '(' || input.Last() != ')')
            {
                throw new Exception("Invalid record error");
            }

            var startParenthesisIndex = input.IndexOf("(");
            var endParenthesisIndex = input.LastIndexOf(")");

            var unwrappedInput = input.Substring(startParenthesisIndex + 1, endParenthesisIndex - startParenthesisIndex - 1);
            if (unwrappedInput.Length == 0)
            {
                return 0;
            }

            var splitInput = unwrappedInput.Split(" ").ToList();

            if (splitInput[1] == "*")
            {
                return double.Parse(splitInput[0]) * double.Parse(splitInput[2]);
            }

            if (splitInput[1] == "+")
            {
                return double.Parse(splitInput[0]) + double.Parse(splitInput[2]);
            }
            
            return double.Parse(splitInput[0]) - double.Parse(splitInput[2]);
        }
    }
}