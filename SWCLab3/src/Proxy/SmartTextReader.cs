namespace SWCLab3.src.Proxy;

public class SmartTextReader : ITextReader
{
    public char[][]? ReadFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();
            }

            return result;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Помилка: Файл за шляхом '{filePath}' не знайдено.");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася непередбачена помилка: {ex.Message}");
            return null;
        }
    }
}