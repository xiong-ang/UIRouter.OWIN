using System;
using System.Diagnostics;

namespace UIRouter.OWIN.Log
{
    public class DefaultLogHandler : ILogHandler
    {
        virtual public void Log(LoggingEvent loggingEvent)
        {
            Trace.WriteLine($"{DateTime.Now}-{loggingEvent.Level}-{loggingEvent.Message}");
        }
    }

}
