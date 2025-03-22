using TextParser.Models;
using TextParser.Utils;

namespace TextParser.Handlers
{
    public static class FileHandler
    {
        public static CharacterCountResult? AnalyzeFile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            var result = new CharacterCountResult(0, new SortedDictionary<char, int>());

            using var fstream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fstream);
            
            string line;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                result.WordsCount += TextCounter.CountWords(line);
                var dictionary = TextCounter.CountCharacterFrequencies(line);
                foreach (var element in dictionary)
                {
                    if (result.SortedChars.ContainsKey(element.Key))
                    {
                        result.SortedChars[element.Key] += element.Value;
                    }
                    else
                    {
                        result.SortedChars.Add(element.Key, element.Value);
                    }
                }
            }
            return result;
        }
    }
}
