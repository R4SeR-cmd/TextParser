using TextParser.Models.Enums;

namespace TextParser.Interfaces;


// read -f
// read -d

public interface IPatternChecker
{
    PatternType CheckPattern(string input);
}