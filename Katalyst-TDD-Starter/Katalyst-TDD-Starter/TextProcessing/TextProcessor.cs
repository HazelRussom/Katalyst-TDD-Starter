namespace Katalyst_TDD_Starter.TextProcessing
{
    public class TextProcessor
    {
        public string Process(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var wordCount = words.Length;

            var topWordCount = (wordCount < 10) ? wordCount : 10;

            var output = $"These are the top {topWordCount} words used:";

            output += $"\nThis text has {wordCount} words in total";
            return output;
        }
    }
}