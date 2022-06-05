using Autofac.Extras.Moq;
using Katalyst_TDD_Starter.RomanNumerals;
using Katalyst_TDD_Starter.Test.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.RomanNumerals
{
    [TestClass]
    public class RomanNumeralExecutorTests
    {
        [TestMethod]
        [DataRow (1)]
        [DataRow (2)]
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

        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(10, "X")]
        public void Console_writer_should_recieve_converter_output(int input, string converterOutputs)
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRomanNumeralConverter>().Setup(x => x.Convert(input)).Returns(converterOutputs);

                var ToTest = mock.Create<RomanNumeralExecutor>();

                ToTest.Execute(input);

                mock.Mock<IConsoleWriter>().Verify(x => x.Write(converterOutputs), Times.Exactly(1));
            }
        }
    }
}
