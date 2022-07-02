namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public int InputLength { get; private set; }

        public PasswordValidator()
        {
            InputLength = 9;
        }

        public bool Validate(string input)
        {
            if (input.Length < InputLength)
            {
                return false;
            }

            if (!input.Any(char.IsUpper) || !input.Any(char.IsLower))
            {
                return false;
            }

            if (!input.Any(char.IsDigit))
            {
                return false;
            }

            if (!input.Contains('_'))
            {
                return false;
            }

            return true;
        }

        public void SetInputLength(int inputLength)
        {
            InputLength = inputLength;
        }
    }
}