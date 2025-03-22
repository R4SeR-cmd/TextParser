using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextParser.Interfaces;
using TextParser.Models.Enums;

namespace TextParser.Services.Readers
{
    public class FileReader : IInputReader, IPatternChecker
    {
        public string? ReadInput()
        {
            Console.Write("Enter 'read -f path':");
            return Console.ReadLine();
        }
        public PatternType CheckPattern(string input)
        {
            const string pattern = @"^read -f .+$";
            return Regex.IsMatch(input, pattern)
                ? PatternType.File
                : PatternType.None;
        }

    }
}
