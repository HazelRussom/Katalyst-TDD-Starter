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

            if (unwrappedInput.Contains("("))
            {
                if (!unwrappedInput.Contains("+")) {
                    return 0;
                }


                var innerStartParenthesisIndex = unwrappedInput.IndexOf("(");
                var innerEndParenthesisIndex = unwrappedInput.LastIndexOf(")");
                var unwrappedInnerInput = unwrappedInput.Substring(innerStartParenthesisIndex + 1, innerEndParenthesisIndex - innerStartParenthesisIndex - 1);

                var innerResult = 0d;
                var splitInnerInput = unwrappedInnerInput.Split(" ").ToList();
                if (splitInnerInput[1] == "+")
                {
                    innerResult = GetFirstNumber(splitInnerInput) + GetSecondNumber(splitInnerInput);
                }
                unwrappedInput = $"{unwrappedInput.Substring(0, innerStartParenthesisIndex-1)} {innerResult} {unwrappedInput.Substring(innerEndParenthesisIndex)}";
                
            }

            var splitInput = unwrappedInput.Split(" ").ToList();

            if (splitInput[1] == "/")
            {
                return GetFirstNumber(splitInput) / GetSecondNumber(splitInput);
            }

            if (splitInput[1] == "*")
            {
                return GetFirstNumber(splitInput) * GetSecondNumber(splitInput);
            }

            if (splitInput[1] == "+")
            {
                return GetFirstNumber(splitInput) + GetSecondNumber(splitInput);
            }

            return GetFirstNumber(splitInput) - GetSecondNumber(splitInput);
        }

        private static double GetFirstNumber(List<string> splitInput)
        {
            return double.Parse(splitInput[0]);
        }

        private static double GetSecondNumber(List<string> splitInput)
        {
            return double.Parse(splitInput[2]);
        }
    }
}