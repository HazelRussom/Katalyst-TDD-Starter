using Autofac.Extras.Moq;
using Katalyst_TDD_Starter.FizzBuzz;
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

        [TestMethod]
        public void FizzBuzz_converter_is_called_1_time()
        {
            using( var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFizzBuzzConverter>().Setup(x => x.Convert(It.IsAny<int>())).Returns(string.Empty);

                var ToTest = mock.Create<FizzBuzzExecutor>();

                ToTest.Execute(1);

                mock.Mock<IFizzBuzzConverter>().Verify(x => x.Convert(It.IsAny<int>()), Times.Exactly(1));
            }
        }
    }
}