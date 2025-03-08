using System.Text.RegularExpressions;

namespace TextParser.Utils
{
    public static class TextCounter
    {
        public static SortedDictionary<char, int> CountCharacterFrequencies(string text)
        {
            return new SortedDictionary<char, int>(
                text
                    .GroupBy(c => c)
                    .ToDictionary(group => group.Key, group => group.Count())
            );
        }

        public static int CountWords(string text)
        {
            var words = text.Split([' ', ',', '.', ';', '!', '?', '\n'], StringSplitOptions.RemoveEmptyEntries);
            return words.Count(word => Regex.Matches(word, @"[a-zA-Z]").Count > 0);
        }
    }
}
