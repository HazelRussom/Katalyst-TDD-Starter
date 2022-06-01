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
        [DataRow ("Hello, this is an example for you to practice. You should grab this text and make it as your test case.", 21)]
        public void The_output_should_contain_the_total_word_count(string input, int expectedCount)
        {
            var expected = $"This text has {expectedCount} words in total";

            var actual = ToTest.Process(input); 

            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        [DataRow("Hello", 1)]
        [DataRow("Hello, this is an example", 5)]
        [DataRow("Hello, this is an example for you to practice with.", 10)]
        [DataRow("Hello, this is an example for you to practice test driven development with.", 10)]
        public void The_output_should_begin_with_the_top_words_used (string input, int expectedTopWordCount)
        {
            var expected = $"These are the top {expectedTopWordCount} words used:";

            var actual = ToTest.Process(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }
    }
}
