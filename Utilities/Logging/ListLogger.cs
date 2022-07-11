using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Logging;

public class ListLogger : Logger
{
    private List<string> _LogList;

    public ListLogger(List<string> LogList)
    {
        _LogList = LogList;
    }

    public ListLogger() : this(new List<string>())
    {
        
    }

    public override void Log(string Message)
    {
        _LogList.Add(Message);
    }

    public string[] GetLog() => _LogList.ToArray();
}
