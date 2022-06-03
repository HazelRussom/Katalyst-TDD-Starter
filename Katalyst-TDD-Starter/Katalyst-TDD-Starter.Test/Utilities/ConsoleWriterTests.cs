using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Katalyst_TDD_Starter.Test.Utilities
{
    [TestClass]
    public class ConsoleWriterTests
    {
        public ConsoleWriterTests()
        {
            ToTest = new ConsoleWriter();
        }

        public ConsoleWriter ToTest { get; private set; }

        [TestMethod]
        public void Write_method_should_execute_without_error()
        {
            var input = "Test input string";
            var testPass = true;

            try
            {
                ToTest.Write(input);
            }
            catch (Exception)
            {
                testPass = false; 
            }

            Assert.IsTrue(testPass);
        }
    }
}
