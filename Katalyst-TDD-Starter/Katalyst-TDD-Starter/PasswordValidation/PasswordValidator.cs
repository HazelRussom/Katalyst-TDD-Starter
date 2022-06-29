namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public PasswordValidator()
        {
        }

        public bool Validate(string input)
        {
            if (input.Length <= 8)
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

            return true;
        }
    }
}