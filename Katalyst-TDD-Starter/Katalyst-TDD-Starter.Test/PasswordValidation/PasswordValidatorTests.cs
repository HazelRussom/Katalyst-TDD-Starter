using Katalyst_TDD_Starter.PasswordValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.PasswordValidation
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        public void Empty_string_should_return_false()
        {
            var validator = new PasswordValidator();
            Assert.IsFalse(validator.Validate(string.Empty));
        }
    }
}
