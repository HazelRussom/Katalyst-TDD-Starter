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
        public void The_output_should_begin_with_the_top_words_message ()
        {
            var input = "This is a test message.";

            var expected = $"These are the top 5 words used:";
            var actual = ToTest.Process(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }

        [TestMethod]
        [DataRow("Hello", 1)]
        [DataRow("Hello, this is an example", 5)]
        [DataRow("Hello, this is an example for you to practice with.", 10)]
        [DataRow("Hello, this is an example for you to practice test driven development with.", 10)]
        public void The_top_words_message_should_not_count_more_than_10_words (string input, int expectedTopWordCount)
        {
            var expected = $"These are the top {expectedTopWordCount} words used:";

            var actual = ToTest.Process(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }

        [TestMethod]
        [DataRow("Hello Hello", 1)]
        [DataRow("Hello hello world", 2)]
        [DataRow("Hello hello, this is an example.", 5)]
        [DataRow("Hello! hello? hEl-lo , this is an example.", 5)]
        public void The_top_words_message_should_not_count_duplicates_of_words (string input, int expectedTopWordCount)
        {
            var expected = $"These are the top {expectedTopWordCount} words used:";

            var actual = ToTest.Process(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }
    }
}
