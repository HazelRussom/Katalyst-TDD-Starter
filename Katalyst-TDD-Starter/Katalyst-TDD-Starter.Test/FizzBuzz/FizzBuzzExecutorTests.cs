using Autofac.Extras.Moq;
using Katalyst_TDD_Starter.FizzBuzz;
using Katalyst_TDD_Starter.FizzBuzz.Converters;
using Katalyst_TDD_Starter.Test.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.FizzBuzz
{
    [TestClass]
    public class FizzBuzzExecutorTests
    {
        public FizzBuzzExecutorTests()
        {
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(100)]
        public void FizzBuzz_converter_is_called_expected_number_of_times_and_each_output_is_sent_to_console_writer(int count)
        {
            using( var mock = AutoMock.GetLoose())
            {
                var testReturnString = "This is a test value";

                mock.Mock<IFizzBuzzConverter>().Setup(x => x.Convert(It.IsAny<int>())).Returns(testReturnString);

                var ToTest = mock.Create<FizzBuzzExecutor>();

                ToTest.Execute(count);

                mock.Mock<IFizzBuzzConverter>().Verify(x => x.Convert(It.IsAny<int>()), Times.Exactly(count));
                mock.Mock<IConsoleWriter>().Verify(x => x.Write(testReturnString), Times.Exactly(count));
            }
        }
    }
}