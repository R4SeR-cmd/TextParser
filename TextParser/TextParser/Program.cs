using System.Collections;
using System.Collections.Generic;

namespace TextParser;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter text: ");
        string text = Console.ReadLine();

        var characterCounter = new CharacterCounter(text);
        var sortedChars = characterCounter.CountCharacterFrequencies();

        foreach (var kv in sortedChars)
            Console.WriteLine($"|{kv.Key}| : {kv.Value}");
    }
}