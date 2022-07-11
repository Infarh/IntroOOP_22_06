using System.Text;

namespace Utilities.Logging;

public class PrefixFileLogger : FileLogger
{
    public bool AddTime { get; set; } = true;

    public string Prefix { get; set; } = " >>";

    public PrefixFileLogger(string FileName) : base(FileName) { }

    public PrefixFileLogger(string FileName, string Prefix, bool AddTime = true) : this(FileName)
    {
        this.Prefix = Prefix;
        this.AddTime = AddTime;
    }

    public override void Log(string Message)
    {
        var message = new StringBuilder();

        if (AddTime)
            message.Append(DateTime.Now.ToString("HH:mm:ss.fff"));

        if (Prefix is { Length: > 0 })
            message.Append(Prefix);

        message.Append(Message);

        base.Log(message.ToString());
    }
}