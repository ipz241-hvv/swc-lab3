namespace SWCLab3.src.Adapter;

public class Logger : ILogger
{
    public void Log(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[INFO]" + text);
        Console.ResetColor();
    }

    public void Warn(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[WARN]" + text);
        Console.ResetColor();
    }

    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[ERROR]" + text);
        Console.ResetColor();
    }
}
