using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser.Models
{
    public class CharacterCountResult
    {
        public int WordsCount { get; set; }
        public SortedDictionary<char, int> SortedChars { get; set; }

        public CharacterCountResult(int wordsCount, SortedDictionary<char,int> sortedChars)
        {
            WordsCount = wordsCount;
            SortedChars = sortedChars;
        }

    }
}
