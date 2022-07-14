namespace Utilities.Logging;

public abstract class Logger : ILogger
{
    public abstract void Log(string Message);
}