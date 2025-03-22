using System.Text.RegularExpressions;
using TextParser.Interfaces;
using TextParser.Models.Enums;

namespace TextParser.Services.Readers;

public class DirectoryReader : IInputReader, IPatternChecker
{
    public string? ReadInput()
    {
        Console.Write("Enter 'read -d path':");
        return Console.ReadLine();
    }

    public PatternType CheckPattern(string input)
    {
        const string pattern = @"^read -d .+$";
        return Regex.IsMatch(input, pattern) 
            ? PatternType.Directory
            : PatternType.None;
    }
}