namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public PasswordValidator()
        {
        }

        public bool Validate(string input)
        {
            if (!input.Any(char.IsUpper) || input.Length <= 8)
            {
                return false;
            }

            return true;
        }
    }
}