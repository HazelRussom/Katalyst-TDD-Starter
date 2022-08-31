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
        readonly Mock<IConsoleLogger> ConsoleLogger;
        readonly Mock<IStatementLog> StatementLog;
        readonly StatementPrinter UnderTest;

        public StatementPrinterShould()
        {
            ConsoleLogger = new Mock<IConsoleLogger>(MockBehavior.Strict);
            StatementLog = new Mock<IStatementLog>();
            UnderTest = new StatementPrinter(ConsoleLogger.Object);
        }

        [TestMethod]
        public void Print_expected_statement_header()
        {
            var expected = "Date || Amount || Balance";

            ConsoleLogger.Setup(x => x.Log(expected));
            StatementLog.Setup(x => x.GetEntries()).Returns(new List<StatementEntry>());

            UnderTest.PrintStatement(StatementLog.Object);

            StatementLog.Verify(x => x.GetEntries(), Times.Exactly(1));
            ConsoleLogger.Verify(x => x.Log(expected), Times.Exactly(1));
        }

        [TestMethod]
        public void Print_single_statement_below_header_of_500_value()
        {
            var entries = new List<StatementEntry>
            {
                new StatementEntry { Amount = 500, Balance = 500, Timestamp = new DateTime(2012, 01, 14) }
            };

            var expectedHeader = "Date || Amount || Balance";
            var expectedStatement = "14/01/2012 || 500 || 500";

            StatementLog.Setup(x => x.GetEntries()).Returns(entries);
            var sequence = new MockSequence();
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedHeader));
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedStatement));


            UnderTest.PrintStatement(StatementLog.Object);


            StatementLog.Verify(x => x.GetEntries(), Times.Exactly(1));
            ConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Print_single_statement_below_header_of_1000_value()
        {
            var input = new List<StatementEntry>
            {
                new StatementEntry { Amount = 1000, Balance = 1000, Timestamp = new DateTime(2014, 02, 15) }
            };

            var expectedHeader = "Date || Amount || Balance";
            var expectedStatement = "15/02/2014 || 1000 || 1000";

            var sequence = new MockSequence();
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedHeader));
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedStatement));


            UnderTest.PrintStatement(input);


            ConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        public void Print_two_statements_in_descending_date_order()
        {
            var input = new List<StatementEntry>
            {
                new StatementEntry { Amount = 1000, Balance = 1000, Timestamp = new DateTime(2014, 02, 15) },
                new StatementEntry { Amount = 1000, Balance = 2000, Timestamp = new DateTime(2014, 02, 16) }
            };

            var expectedHeader = "Date || Amount || Balance";
            var expectedNewStatement = "16/02/2014 || 1000 || 2000";
            var expectedOldStatement = "15/02/2014 || 1000 || 1000";


            var sequence = new MockSequence();
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedHeader));
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedNewStatement));
            ConsoleLogger.InSequence(sequence).Setup(x => x.Log(expectedOldStatement));


            UnderTest.PrintStatement(input);


            ConsoleLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3));
        }
    }
}
