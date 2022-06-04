using Autofac.Extras.Moq;
using Katalyst_TDD_Starter.RomanNumerals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.RomanNumerals
{
    [TestClass]
    public class RomanNumeralExecutorTests
    {
        [TestMethod]
        [DataRow (1)]
        public void The_converter_should_be_called_with_the_provided_input(int input)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRomanNumeralConverter>().Setup(x => x.Convert(input));

                var ToTest = mock.Create<RomanNumeralExecutor>();

                ToTest.Execute(input);

                mock.Mock<IRomanNumeralConverter>().Verify(x => x.Convert(input), Times.Exactly(1));
            }
        }
    }
}
