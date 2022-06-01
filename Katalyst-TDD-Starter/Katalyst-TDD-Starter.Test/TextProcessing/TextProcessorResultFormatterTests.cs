using Katalyst_TDD_Starter.TextProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [Ignore]
        public void The_output_should_begin_with_the_top_words_message()
        {
            var input = new TextProcessorResult
            {
                TotalWordCount = 5
            };

            var expected = $"These are the top 5 words used:";
            var actual = ToTest.Format(input);

            Assert.IsTrue(actual.StartsWith(expected));
        }
    }
}
