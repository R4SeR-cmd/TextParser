using TextParser.Handlers;
using TextParser.Models;
using TextParser.Utils;

namespace TextParser;

internal class Program
{
    private static void PrintResult(CharacterCountResult result)
    {
        foreach (var kv in result.SortedChars)
            Console.WriteLine($"|{kv.Key}| : {kv.Value}");

        Console.WriteLine($"Count of words : {result.WordsCount} ");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter text: ");
        string text = Console.ReadLine();

        if (InputParser.CheckPattern(text))
        {
            var pathToFile = InputParser.GetPathToFile(text);
            var result = FileHandler.AnalyzeFile(pathToFile);
            if (result is not null)
            {
                PrintResult(result);
            }
        }
        else
        {
            var result = new CharacterCountResult(TextCounter.CountWords(text),
                TextCounter.CountCharacterFrequencies(text));
            PrintResult(result);
        }
    }
}