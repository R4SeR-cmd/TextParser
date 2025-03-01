using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextParser
{
    public class CharacterCounter
    {
        private readonly string _text;

        public CharacterCounter(string text)
        {
            _text = text;
        }

        public SortedDictionary<char, int> CountCharacterFrequencies()
        {
            return new SortedDictionary<char, int>(
                _text
                    .Where(ValidateChar)
                    .GroupBy(c => c)
                    .ToDictionary(group => group.Key, group => group.Count())
            );
        }

        private static bool ValidateChar(char character)
        {
            return character is >= 'A' and <= 'Z'
                or >= 'a' and <= 'z'
                or ' ' or '!' or '?' or '.' or ',';
        }
    }
}
