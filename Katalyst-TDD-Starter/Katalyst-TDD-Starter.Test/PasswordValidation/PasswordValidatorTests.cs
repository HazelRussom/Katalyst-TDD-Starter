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

        [TestMethod]
        [DataRow ("")]
        [DataRow ("test")]
        public void Input_should_return_false(string input)
        {
            Assert.IsFalse(UnderTest.Validate(input));
        }

        [TestMethod]
        [DataRow ("Test_w0rd")]
        [DataRow ("Test_w0rd2")]
        public void Valid_input_should_return_true(string input)
        {
            Assert.IsTrue(UnderTest.Validate(input));
        }
    }
}


//Have more than 8 characters
//Contains a capital letter
//Contains a lowercase
//Contains a number
//Contains an underscore
