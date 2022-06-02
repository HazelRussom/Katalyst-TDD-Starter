using Katalyst_TDD_Starter.TextProcessing;

namespace Katalyst_TDD_Starter.Test.TextProcessing
{
    public class TextProcessorResultFormatter
    {
        public string Format(TextProcessorResult input)
        {
            var result = $"These are the top {input.MostUsedWords.Count} words used:";

            for(int i = 0; i < input.MostUsedWords.Count; i++)
            {
                result += $"\n{i + 1}. {input.MostUsedWords[i]}";
            }

            result += $"\nThe text has { input.TotalWordCount} words in total.";
            return result;
        }
    }
}