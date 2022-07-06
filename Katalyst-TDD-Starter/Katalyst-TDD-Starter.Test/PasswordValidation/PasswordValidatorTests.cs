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
            UnderTest = new PasswordValidatorBuilder().Build();
        }

        [TestMethod ("Default Validator fail cases")]
        [DataRow ("", DisplayName = "Empty Input")]
        [DataRow ("test", DisplayName = "Fail every check")]
        [DataRow ("Test_w0", DisplayName = "Less than 9 characters")]
        [DataRow ("test_w0rd", DisplayName = "Missing capital letter")]
        [DataRow ("TEST_W0RD", DisplayName = "Missing lowercase letter")]
        [DataRow ("Test_word", DisplayName = "Missing number")]
        [DataRow ("Test-w0rd", DisplayName = "Missing underscore")]
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
            UnderTest = new PasswordValidatorBuilder().WithInputLength(length).Build();

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }

        [TestMethod("Capital letter validation config")]
        [DataRow(false, true, DisplayName = "Disable capital letter check")]
        [DataRow(true, false, DisplayName = "Enable capital letter check")]
        public void Setting_capital_letter_requirement_should_affect_validation(bool configSetting, bool expected)
        {
            UnderTest = new PasswordValidatorBuilder().WithRequiredCapital(configSetting).Build();

            var input = "test_w0rd";

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }

        [TestMethod("Lowercase letter validation config")]
        [DataRow(false, true, DisplayName = "Disable lowercase letter check")]
        [DataRow(true, false, DisplayName = "Enable lowercase letter check")]
        public void Setting_lowercase_letter_requirement_should_affect_validation(bool configSetting, bool expected)
        {
            UnderTest = new PasswordValidatorBuilder().WithRequiredLowercase(configSetting).Build();

            var input = "TEST_W0RD";

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }

        [TestMethod("Numeric validation config")]
        [DataRow(false, true, DisplayName = "Disable numeric character check")]
        [DataRow(true, false, DisplayName = "Enable numeric character check")]
        public void Setting_numeric_character_requirement_should_affect_validation(bool configSetting, bool expected)
        {
            UnderTest = new PasswordValidatorBuilder().WithRequiredNumericCharacter(configSetting).Build();

            var input = "Test_word";

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }

        [TestMethod("Underscore validation config")]
        [DataRow(false, true, DisplayName = "Disable underscore check")]
        [DataRow(true, false, DisplayName = "Enable underscore check")]
        public void Setting_underscore_requirement_should_affect_validation(bool configSetting, bool expected)
        {
            UnderTest = new PasswordValidatorBuilder().WithRequiredUnderscore(configSetting).Build();

            var input = "Test-w0rd";

            Assert.AreEqual(UnderTest.Validate(input), expected);
        }
    }
}

