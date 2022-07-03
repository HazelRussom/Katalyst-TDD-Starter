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

        [TestMethod ("Input length validation config")]
        [DataRow("Tw0_", 0, true, DisplayName = "Disable input check")]
        [DataRow("Tw0_", 5, false, DisplayName = "Configure minimum limit to 5 fail")]
        [DataRow("Tw00_", 5, true, DisplayName = "Configure minimum limit to 5 pass")]
        [DataRow("Tw0_Tw0_Tw0_Tw0", 16, false, DisplayName = "Configure minimum limit to 16 fail")]
        [DataRow("Tw0_Tw0_Tw0_Tw0_", 16, true, DisplayName = "Configure minimum limit to 16 fail")]
        public void Input_length_configuration_changes_should_affect_validation(string input, int length, bool expected)
        {
            UnderTest.SetInputLength(length);

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }

        [TestMethod("Capital letter validation config")]
        public void Disabling_capital_letter_requirement_should_not_check_for_capital_letters()
        {
            UnderTest.SetCapitalsConfig(false);

            Assert.IsTrue(UnderTest.Validate("test_w0rd"));

        }
    }
}

