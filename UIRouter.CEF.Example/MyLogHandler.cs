using System;
using System.Diagnostics;
using UIRouter.OWIN;
using UIRouter.OWIN.Log;

namespace UIRouter.CEF.Example
{
    internal class MyLogHandler : ILogHandler
    {
        public void Log(LoggingEvent loggingEvent)
        {
            Trace.WriteLine($"{DateTime.Now} - {loggingEvent.Level} - {loggingEvent.Message}");
        }
    }
}