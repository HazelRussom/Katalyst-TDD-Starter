using Katalyst_TDD_Starter.UserValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.UserValidation
{
    [TestClass]
    public class UserValidatorShould
    {
        [TestMethod]
        public void Pass_validation_for_valid_user()
        {
            var underTest = new UserValidator();
            var input = new User("First", "Last", "email@address.com");

            var result = underTest.Validate(input);

            Assert.AreEqual(ValidationResult.Valid, result);
        }
    }
}
