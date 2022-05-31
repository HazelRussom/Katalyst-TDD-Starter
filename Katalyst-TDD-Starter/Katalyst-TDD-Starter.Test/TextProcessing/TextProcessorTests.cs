using Katalyst_TDD_Starter.TextProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.TextProcessing
{
    [TestClass]
    public class TextProcessorTests
    {
        public TextProcessorTests()
        {
            ToTest = new TextProcessor();
        }

        public TextProcessor ToTest { get; private set; }

        [TestMethod]
        [DataRow ("", 0)]
        [DataRow ("Hello", 1)]
        [DataRow ("Hello, this is an example", 5)]
        [DataRow ("Hello, this is an example for you to practice.", 9)]
        public void The_output_should_contain_the_total_word_count(string input, int expectedCount)
        {
            var expected = $"This text has {expectedCount} words in total";

            var actual = ToTest.Process(input); 

            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
