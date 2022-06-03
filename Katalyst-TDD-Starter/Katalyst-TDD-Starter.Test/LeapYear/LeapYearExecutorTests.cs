using Autofac.Extras.Moq;
using Katalyst_TDD_Starter.LeapYear;
using Katalyst_TDD_Starter.Test.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.LeapYear
{
    [TestClass]
    public class LeapYearExecutorTests
    {
        public LeapYearExecutorTests()
        {
        }

        [TestMethod]
        public void Executor_calls_converter_with_passed_in_parameter()
        {
            var input = 2000;
            var expectedResult = true;

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ILeapYearValidator>().Setup(x => x.Validate(input)).Returns(expectedResult);

                var ToTest = mock.Create<LeapYearExecutor>();

                ToTest.Execute(input);

                mock.Mock<ILeapYearValidator>().Verify(x => x.Validate(input), Times.Exactly(1));
                mock.Mock<ILeapYearValidator>().Verify(x => x.Validate(It.IsAny<int>()), Times.Exactly(1));
                mock.Mock<IConsoleWriter>().Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(1));
            }
        }
    }
}
