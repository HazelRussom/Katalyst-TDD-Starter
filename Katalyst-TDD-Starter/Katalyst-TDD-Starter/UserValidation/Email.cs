using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            var regex = @"^[^@\s]+@[^@\s]+\.(com)$"; 
            
            return Regex.IsMatch(email, regex);
        }
    }
}