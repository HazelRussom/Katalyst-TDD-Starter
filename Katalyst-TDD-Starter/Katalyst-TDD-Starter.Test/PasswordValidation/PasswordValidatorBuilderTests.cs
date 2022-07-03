using Katalyst_TDD_Starter.PasswordValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.PasswordValidation
{
    [TestClass]
    public class PasswordValidatorBuilderTests
    {
        [TestMethod]
        public void Building_the_validator_should_return_a_validator_object()
        {
            var UnderTest = new PasswordValidatorBuilder();

            var result = UnderTest.Build();

            Assert.IsNotNull(result);
        }
    }
}
