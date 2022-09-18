namespace Katalyst_TDD_Starter.UserValidation
{
    public class UserValidator : IUserValidator
    {
        public ValidationResult Validate(User userToValidate)
        {
            return userToValidate.IsValid() ? ValidationResult.Valid : ValidationResult.Invalid;
        }
    }
}