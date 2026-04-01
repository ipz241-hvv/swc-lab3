namespace ConsoleApp.src.Utils;

public class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;

    public FileWriter(string filePath, bool append = false)
    {
        _writer = new StreamWriter(filePath, append);
        _writer.AutoFlush = true;
    }

    public void Write(string text)
    {
        _writer.Write(text);
    }

    public void WriteLine(string text)
    {
        _writer.WriteLine(text);
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }
}