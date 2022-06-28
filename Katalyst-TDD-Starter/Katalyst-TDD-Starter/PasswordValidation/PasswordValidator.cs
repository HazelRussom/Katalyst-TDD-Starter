namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public PasswordValidator()
        {
        }

        public bool Validate(string input)
        {
            if(input.Length > 8)
            {
                return true;
            }

            return false;
        }
    }
}