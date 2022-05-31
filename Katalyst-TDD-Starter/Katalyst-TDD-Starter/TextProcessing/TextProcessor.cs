namespace Katalyst_TDD_Starter.TextProcessing
{
    public class TextProcessor
    {
        public string Process(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var wordCount = words.Length;

            return $"This text has {wordCount} words in total";
        }
    }
}