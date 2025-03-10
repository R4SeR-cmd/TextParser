using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace TextParser.Utils
{
    public static class InputParser
    {
        public static string GetPath(string input)
        {
            var splitInput = input.Split(' ');
            return string.Join(" ", splitInput, 2, splitInput.Length - 2);
        }
    }
}
