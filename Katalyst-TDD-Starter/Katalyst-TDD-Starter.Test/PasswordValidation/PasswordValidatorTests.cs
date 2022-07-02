using Katalyst_TDD_Starter.PasswordValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.PasswordValidation
{
    [TestClass]
    public class PasswordValidatorTests
    {
        public PasswordValidator UnderTest { get; set; }

        public PasswordValidatorTests()
        {
            UnderTest = new PasswordValidator();
        }

        [TestMethod ("Default Validator fail cases")]
        [DataRow ("", DisplayName = "Empty Input")]
        [DataRow ("test", DisplayName = "Fail every check")]
        [DataRow ("Test_w0", DisplayName = "Less than 9 characters")]
        [DataRow ("test_w0rd", DisplayName = "Missing capital letter")]
        [DataRow ("TEST_W0RD", DisplayName = "Missing lowercase letter")]
        [DataRow ("Test_word", DisplayName = "Missing number")]
        [DataRow ("Test-word", DisplayName = "Missing underscore")]
        public void Input_should_return_false(string input)
        {
            Assert.IsFalse(UnderTest.Validate(input));
        }

        [TestMethod ("Default Validator pass cases")]
        [DataRow ("Test_w0rd", DisplayName = "Passing input")]
        [DataRow ("Test_w0rd2", DisplayName = "Passing input 2")]
        public void Valid_input_should_return_true(string input)
        {
            Assert.IsTrue(UnderTest.Validate(input));
        }

        [TestMethod]
        public void Input_length_should_not_be_checked_when_config_is_disabled()
        {
            UnderTest.SetInputLength(0);

            Assert.IsTrue(UnderTest.Validate("Tw0_"));
        }
    }
}

