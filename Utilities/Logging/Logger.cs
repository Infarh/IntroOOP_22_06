namespace Utilities.Logging;

public class Logger
{
    public virtual void Log(string Message)
    {

    }
}

public class FileLogger : Logger
{
    private readonly string _LogFileName;

    public FileLogger(string LogFileName)
    {
        _LogFileName = LogFileName;

        Log("Журнал создан");
    }

    public override void Log(string Message)
    {
        //base.Log(Message);

        var new_line_symbol = Environment.NewLine;
        var file_message = $"{DateTime.Now:HH:mm:ss.fff} >>{Message}{new_line_symbol}";

        File.AppendAllText(_LogFileName, file_message);
    }
}
