namespace SWCLab3.src.Adapter;

public interface ILogger
{
    public void Log(string text);
    public void Warn(string text);
    public void Error(string text);
}
