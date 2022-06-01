using System.Text.RegularExpressions;

namespace Katalyst_TDD_Starter.TextProcessing
{
    public class TextProcessor
    {
        public TextProcessorResult Process(string input)
        {
            var punctuationTrim = new Regex("[^a-zA-Z0-9 ]");
            var trimmedInput = punctuationTrim.Replace(input, string.Empty);

            var words = trimmedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var totalWordCount = words.Length;

            var groupedWords = words.GroupBy(x => x.ToLower()).OrderByDescending(y => y.Count());

            var distinctWordCount = words.Select(x => x.ToLower()).Distinct().Count();
            var topWordCount = (distinctWordCount < 10) ? distinctWordCount : 10;

            var output = $"These are the top {topWordCount} words used:";

            output += $"\nThis text has {totalWordCount} words in total";

            var result = new TextProcessorResult
            {
                MostUsedWords = words,
                TotalWordCount = totalWordCount
            };

            return result;
        }
    }
}