namespace TextParser;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<char,int> dictionary = new Dictionary<char,int>();


        Console.WriteLine("Enter text: ");
        string text = Console.ReadLine();

        foreach (var t in text)
        {
            if (t is >= 'A' and <= 'Z' 
                or >= 'a' and <= 'z' 
                or ' ' or '!' or '?' or '.' or ',')
            {
                if (dictionary.ContainsKey(t))
                {
                    dictionary[t]++;
                }

                else
                {
                    dictionary.Add(t, 1);
                }
            }
        }

        List<char> sortedSymbols = dictionary.Keys.ToList();
        sortedSymbols.Sort();

        foreach (var c in sortedSymbols)
            Console.WriteLine($"|{c}| : {dictionary[c]}");
    }

    
}