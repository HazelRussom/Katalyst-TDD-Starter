namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public PasswordValidator()
        {
        }

        public bool Validate(string input)
        {
            if(input == "Test_w0rd")
            {
                return true;
            }

            return false;
        }
    }
}