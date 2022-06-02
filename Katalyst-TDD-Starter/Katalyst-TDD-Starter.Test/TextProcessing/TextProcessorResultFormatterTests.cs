using Katalyst_TDD_Starter.TextProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.TextProcessing
{
    [TestClass]
    public class TextProcessorResultFormatterTests
    {
        public TextProcessorResultFormatter ToTest { get; private set; }

        public TextProcessorResultFormatterTests()
        {
            ToTest = new TextProcessorResultFormatter();
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(128)]
        public void The_output_should_end_with_the_total_word_count_message(int totalWordCount)
        {
            var input = new TextProcessorResult
            {
                TotalWordCount = totalWordCount
            };

            var expected = $"\nThe text has {totalWordCount} words in total.";
            var actual = ToTest.Format(input);

            Assert.IsTrue(actual.EndsWith(expected));
        }

        [TestMethod]
        [DataRow (1)]
        [DataRow(5)]
        [DataRow(10)]
        public void The_output_should_begin_with_the_top_word_count_message(int mostUsedWordsCount)
        {
            var mostUsedWords = new List<string>();

            for (int i = 0; i < mostUsedWordsCount; i++)
            {
                mostUsedWords.Add(string.Empty);
            }

            var input = new TextProcessorResult
            {
                MostUsedWords = mostUsedWords
            };

            var expected = $"These are the top {mostUsedWordsCount} words used:\n";
            var actual = ToTest.Format(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }

        [TestMethod]
        public void The_output_should_list_the_most_used_words_in_order()
        {
            var mostUsedWords = new List<string>
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4",
                "Test5",
                "Test6",
                "Test7",
                "Test8",
                "Test9",
                "Test10"
            };

            var input = new TextProcessorResult
            {
                MostUsedWords = mostUsedWords
            };

            var expectedFirstEntry = $"\n1. {mostUsedWords[0]}";
            var expectedSecondEntry = $"\n2. {mostUsedWords[1]}";
            var expectedLastEntry = $"\n10. {mostUsedWords[9]}";
            var actual = ToTest.Format(input);

            Assert.IsTrue(actual.Contains(expectedFirstEntry));
            Assert.IsTrue(actual.Contains(expectedSecondEntry));
            Assert.IsTrue(actual.Contains(expectedLastEntry));
        }
    }
}
