using System.Text.Json;
using ChatGptConsoleApp.Services;
using TextParser.Handlers;
using TextParser.Interfaces;
using TextParser.Models;
using TextParser.Models.Enums;
using TextParser.Services.Readers;
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
    static async Task Main(string[] args)
    {
        Console.WriteLine("----MENU----\n" +
                          "1 - Read sentence.\n" +
                          "2 - Read file.\n" +
                          "3 - Read directory.\n" +
                          "4 - Use chat gpt");
        Console.Write("Enter your choice: ");
        Enum.TryParse(Console.ReadLine(), out MenuChoice choice);

        IInputReader? reader = choice switch
        {
            MenuChoice.Sentence => new SentenceReader(),
            MenuChoice.File => new FileReader(),
            MenuChoice.Directory => new DirectoryReader(),
            MenuChoice.ChatGPT => new ChatGPTReader(),
            _ => null
        };

        if (reader == null) return;

        var text = reader.ReadInput();

        if(string.IsNullOrEmpty(text))
            return;

        var patternChecker = (IPatternChecker)reader;

        var matchedPattern = patternChecker.CheckPattern(text);

        switch (matchedPattern)
        {
            case PatternType.None:
            {
                Console.WriteLine("Bad request");
            }
                break;
            case PatternType.File:
            {
                var pathToFile = InputParser.GetPath(text);
                var result = FileHandler.AnalyzeFile(pathToFile);
                if (result is not null)
                {
                    PrintResult(result);
                }
            }
                break;
            case PatternType.Directory:
            {
                var pathToFile = InputParser.GetPath(text);
                var resultFromDirectory = await DirectoryHandler.AnalyzeDirectory(pathToFile);
                if (resultFromDirectory.Count > 0)
                {
                    var files = Directory.GetFiles(pathToFile);
                    for (int i = 0; i < resultFromDirectory.Count; i++)
                    {
                        Console.WriteLine($"Path: {files[i]}");
                        PrintResult(resultFromDirectory[i]);
                    }
                }
            }
                break;
            case PatternType.Sentence:
            {
                var result = new CharacterCountResult(TextCounter.CountWords(text),
                    TextCounter.CountCharacterFrequencies(text));
                PrintResult(result);
            }
                break;

            case PatternType.ChatGPT:
            {
                var сhatGptService = new ChatGptService();
                var result = await сhatGptService.GetChatGptResponse(text);
                Console.WriteLine($"Chat GPT response\n{result}");
            } 
                break;
        }
    }
}