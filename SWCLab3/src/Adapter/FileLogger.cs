using ConsoleApp.src.Utils;

namespace SWCLab3.src.Adapter;

public class FileLogger : ILogger, IDisposable
{
    private FileWriter _writer;

    public FileLogger(FileWriter fileWriter)
    {
        _writer = fileWriter;
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }

    public void Error(string text)
    {
        _writer.WriteLine("[ERROR]" + text);
    }

    public void Log(string text)
    {
        _writer.WriteLine("[INFO]" + text);
    }

    public void Warn(string text)
    {
        _writer.WriteLine("[WARN]" + text);
    }
}
