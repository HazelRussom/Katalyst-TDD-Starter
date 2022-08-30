using Katalyst_TDD_Starter.Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bank
{
    [TestClass]
    public class StatementPrinterShould
    {
        [TestMethod]
        public void Print_expected_statement_header()
        {
            var input = new List<StatementEntry>();
            var consoleLogger = new Mock<IConsoleLogger>(MockBehavior.Strict);
            var underTest = new StatementPrinter(consoleLogger.Object);
            var expected = "Date || Amount || Balance";

            consoleLogger.Setup(x => x.Log(expected));

            underTest.PrintStatement(input);

            consoleLogger.Verify(x => x.Log(expected), Times.Exactly(1));
        }

        [TestMethod]
        public void Print_single_statement_below_header_of_500_value()
        {
            var expectedHeader = "Date || Amount || Balance";
            var expectedStatement = "14/01/2012 || 500 || 500";

            var input = new List<StatementEntry>
            {
                new StatementEntry { Amount = 500, Timestamp = new DateTime(2012, 01, 14) }
            };
            var consoleLogger = new Mock<IConsoleLogger>(MockBehavior.Strict);
            var underTest = new StatementPrinter(consoleLogger.Object);

            var sequence = new MockSequence();

            consoleLogger.InSequence(sequence).Setup(x => x.Log(expectedHeader));
            consoleLogger.InSequence(sequence).Setup(x => x.Log(expectedStatement));

            underTest.PrintStatement(input);

            consoleLogger.Verify(x => x.Log(expectedHeader), Times.Exactly(1));
            consoleLogger.Verify(x => x.Log(expectedStatement), Times.Exactly(1));
            consoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Print_single_statement_below_header_of_1000_value()
        {
            var expectedHeader = "Date || Amount || Balance";
            var expectedStatement = "15/02/2014 || 1000 || 1000";

            var input = new List<StatementEntry>
            {
                new StatementEntry { Amount = 1000, Timestamp = new DateTime(2014, 02, 15) }
            };

            var consoleLogger = new Mock<IConsoleLogger>(MockBehavior.Strict);
            var underTest = new StatementPrinter(consoleLogger.Object);

            var sequence = new MockSequence();
            consoleLogger.InSequence(sequence).Setup(x => x.Log(expectedHeader));
            consoleLogger.InSequence(sequence).Setup(x => x.Log(expectedStatement));
            
            underTest.PrintStatement(input);

            consoleLogger.Verify(x => x.Log(expectedHeader), Times.Exactly(1));
            consoleLogger.Verify(x => x.Log(expectedStatement), Times.Exactly(1));
            consoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
