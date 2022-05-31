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
        public void The_output_should_contain_the_total_word_count()
        {
            var input = string.Empty;

            var expected = "This text has 0 words in total";

            var actual = ToTest.Process(input); 

            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
