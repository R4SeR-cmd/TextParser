using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TextParser.Utils
{
    public static class InputParser
    {
        private const string Pattern = @"^read -f .+$";

        public static bool CheckPattern(string input)
        {
            return Regex.IsMatch(input, Pattern);
        }

        public static string GetPathToFile(string input)
        {
            var splitInput = input.Split(' ');
            return string.Join(" ", splitInput, 2, splitInput.Length - 2);
        }
    }
}
