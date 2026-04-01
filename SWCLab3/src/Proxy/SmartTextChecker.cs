namespace SWCLab3.src.Proxy;

public class SmartTextChecker : ITextReader
{
    private readonly ITextReader _realReader;

    public SmartTextChecker(ITextReader reader)
    {
        _realReader = reader;
    }

    public char[][]? ReadFile(string filePath)
    {
        Console.WriteLine($"[LOG] Opening file: {filePath}");

        var result = _realReader.ReadFile(filePath);

        if (result != null)
        {
            Console.WriteLine($"[LOG] Successfully read file: {filePath}");

            int totalRows = result.Length;
            int totalChars = result.Sum(row => row.Length);

            Console.WriteLine($"[STAT] Total rows: {totalRows}");
            Console.WriteLine($"[STAT] Total characters: {totalChars}");
            Console.WriteLine($"[LOG] Closing file: {filePath}");
        }

        return result;
    }
}