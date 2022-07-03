using Katalyst_TDD_Starter.PasswordValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.PasswordValidation
{
    [TestClass]
    public class PasswordValidatorBuilderTests
    {
        public PasswordValidatorBuilder UnderTest { get; set; }

        public PasswordValidatorBuilderTests()
        {
            UnderTest = new PasswordValidatorBuilder();
        }

        [TestMethod]
        public void Building_the_validator_should_return_a_validator_object()
        {
            var result = UnderTest.Build();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Validator_with_input_length_should_have_value_set()
        {
            var inputLength = 5;
            var result = UnderTest.WithInputLength(inputLength).Build();

            Assert.AreEqual(inputLength, result.InputLength);
        }
    }
}
