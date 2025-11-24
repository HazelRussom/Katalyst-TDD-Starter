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

            return CalculateString(unwrappedInput);
        }

        private double CalculateString(string input)
        {
            input = input.Trim();

            if (input.Length == 0)
            {
                return 0;
            }

            while (input.Contains('('))
            {
                var innerStartParenthesisIndex = input.IndexOf("(");
                int innerEndParenthesisIndex = GetClosingParentheses(input, innerStartParenthesisIndex);

                var innerValue = input.Substring(innerStartParenthesisIndex + 1, innerEndParenthesisIndex - innerStartParenthesisIndex - 1);
                var innerResult = CalculateString(innerValue);

                var inputStart = input.Substring(0, innerStartParenthesisIndex);
                var inputEnd = input.Substring(innerEndParenthesisIndex + 1);

                input = $"{inputStart}{innerResult}{inputEnd}";

            }

            var splitInput = input.Split(" ").ToList();

            var currentIndex = 0;

            while (splitInput.Contains("/"))
            {
                if (splitInput[currentIndex + 1] == "/")
                {
                    var result = CalculateNumbersAt(currentIndex, splitInput);
                    splitInput.RemoveRange(currentIndex + 1, 2);
                    splitInput[currentIndex] = $"{result}";
                }
                currentIndex++;
            }

            currentIndex = 0;

            while (splitInput.Contains("*")) {
                if (splitInput[currentIndex + 1] == "*") { 
                    var result = CalculateNumbersAt(currentIndex, splitInput);
                    splitInput.RemoveRange(currentIndex + 1, 2);
                    splitInput[currentIndex] = $"{result}";
                }
                currentIndex++;
            }


            while (splitInput.Count > 1)
            {
               
                var result = CalculateFirstTwoNumbers(splitInput);
                splitInput.RemoveRange(1, 2);
                splitInput[0] = $"{result}";
            }
            return Convert.ToDouble(splitInput[0]);
        }

        private double CalculateNumbersAt(int currentIndex, List<string> splitInput)
        {
            var symbol = splitInput[currentIndex + 1];
            if (symbol == "/")
            {
                return GetNumber(splitInput[currentIndex]) / GetNumber(splitInput[currentIndex + 2]);
            }

            if (symbol == "*")
            {
                return GetNumber(splitInput[currentIndex]) * GetNumber(splitInput[currentIndex + 2]);
            }

            if (symbol == "+")
            {
                return GetNumber(splitInput[currentIndex]) + GetNumber(splitInput[currentIndex + 2]);
            }

            return GetNumber(splitInput[currentIndex]) - GetNumber(splitInput[currentIndex + 2]);
        }

        private static double CalculateFirstTwoNumbers(List<string> splitInput)
        {
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

        private static int GetClosingParentheses(string input, int startParenthesisIndex)
        {
            var endParenthesisIndex = 0;
            var openParentheses = 0;
            for (int index = startParenthesisIndex; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    openParentheses++;
                    continue;
                }

                if (input[index] == ')')
                {
                    openParentheses--;

                    if (openParentheses == 0)
                    {
                        endParenthesisIndex = index;
                        break;
                    }
                    continue;
                }
            }

            return endParenthesisIndex;
        }

        private static double GetNumber(string input)
        {
            return double.Parse(input);
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