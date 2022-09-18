namespace Katalyst_TDD_Starter.UserValidation
{
    internal class Email
    {
        private string email;

        public Email(string email)
        {
            this.email = email;
        }

        internal bool IsValid()
        {
            return email != "email";
        }
    }
}