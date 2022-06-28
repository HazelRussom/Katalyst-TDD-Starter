using Katalyst_TDD_Starter.PasswordValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.PasswordValidation
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        [DataRow ("")]
        [DataRow ("test")]
        public void Input_should_return_false(string input)
        {
            var validator = new PasswordValidator();
            Assert.IsFalse(validator.Validate(input));
        }

        [TestMethod]
        public void Valid_input_should_return_true()
        {
            var input = "Test_w0rd";
            var validator = new PasswordValidator();
            Assert.IsTrue(validator.Validate(input));
        }
    }
}


//Have more than 8 characters
//Contains a capital letter
//Contains a lowercase
//Contains a number
//Contains an underscore
