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
                return int.Parse(splitInput[0]) * int.Parse(splitInput[2]);
            }

            if (splitInput[1] == "+")
            {
                return int.Parse(splitInput[0]) + int.Parse(splitInput[2]);
            }
            
            return int.Parse(splitInput[0]) - int.Parse(splitInput[2]);
        }
    }
}