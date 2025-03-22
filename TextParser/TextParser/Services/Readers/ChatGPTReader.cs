using TextParser.Interfaces;
using TextParser.Models.Enums;

namespace TextParser.Services.Readers
{
    public class ChatGPTReader : IInputReader, IPatternChecker
    {
        public string? ReadInput()
        {
            Console.Write("Enter sentence:");
            return Console.ReadLine();
        }

        public PatternType CheckPattern(string input)
        {
            return PatternType.ChatGPT;
        }
    }
}
