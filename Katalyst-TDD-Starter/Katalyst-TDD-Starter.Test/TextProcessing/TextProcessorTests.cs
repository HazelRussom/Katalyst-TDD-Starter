using Katalyst_TDD_Starter.TextProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        [DataRow("", 0)]
        [DataRow("Hello", 1)]
        [DataRow("Hello, this is an example", 5)]
        [DataRow("Hello, this is an example for you to practice.", 9)]
        [DataRow("Hello, this is an example for you to practice. You should grab this text and make it as your test case.", 21)]
        public void The_total_word_count_should_be_set_to_the_total_number_of_words(string input, int expected)
        {
            var actual = ToTest.Process(input);

            Assert.AreEqual(actual.TotalWordCount, expected);
        }

        [TestMethod]
        [DataRow("Hello", 1)]
        [DataRow("Hello Hello", 1)]
        [DataRow("Hello hello world", 2)]
        [DataRow("Hello hello, this is an example.", 5)]
        [DataRow("Hello! hello? hEl-lo , t.h.i.s is is an example.", 5)]
        [DataRow("Hello, this is an example", 5)]
        [DataRow("Hello, this is an example for you to practice with.", 10)]
        [DataRow("Hello, this is an example for you to practice test driven development with.", 10)]
        public void The_most_used_words_should_not_contain_more_than_10_entries_or_duplicates_of_words(string input, int expectedTopWordCount)
        {
            var actual = ToTest.Process(input);

            Assert.IsTrue(actual.MostUsedWords.Count == expectedTopWordCount);
        }

        [TestMethod]
        [DataRow("Hello hello world", "hello", "world")]
        [DataRow("Hello this this is is is an example.", "is", "this")]
        public void The_most_used_words_should_contain_the_most_used_words_in_order_of_usages(string input, string word1, string word2)
        {
            var actual = ToTest.Process(input);

            var mostUsedWords = actual.MostUsedWords;

            Assert.AreEqual(mostUsedWords[0], word1);
            Assert.AreEqual(mostUsedWords[1], word2);
        }
    }
}
