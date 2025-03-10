using TextParser.Models;

namespace TextParser.Handlers;

public static class DirectoryHandler
{
    public static async Task<List<CharacterCountResult?>> AnalyzeDirectory(string path)
    {
        if (!Directory.Exists(path))
            return [];

        var files = Directory.GetFiles(path);

        var tasks = files.Select(filePath => Task.Run(() => FileHandler.AnalyzeFile(filePath))).ToList();

        await Task.WhenAll(tasks);

        return tasks
            .Select(task => task.Result)
            .ToList();
    }
}