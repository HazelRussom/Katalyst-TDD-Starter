using Katalyst_TDD_Starter.TextProcessing;

namespace Katalyst_TDD_Starter.Test.TextProcessing
{
    public class TextProcessorResultFormatter
    {
        public string Format(TextProcessorResult input)
        {
            return $"These are the top {input.MostUsedWords.Count} words used:";
        }
    }
}