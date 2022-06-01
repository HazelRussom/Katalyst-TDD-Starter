namespace Katalyst_TDD_Starter.TextProcessing
{
    public class TextProcessorResult
    {
        public int TotalWordCount { get; set; }

        public List<string> MostUsedWords { get; set; } = new();
    }
}
