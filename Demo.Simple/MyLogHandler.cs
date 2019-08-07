using System;
using UIRouter.OWIN;
using UIRouter.OWIN.Log;

namespace Demo.Simple
{
    internal class MyLogHandler : ILogHandler
    {
        public void Log(LoggingEvent loggingEvent)
        {
            Console.WriteLine($"{DateTime.Now} - {loggingEvent.Level} - {loggingEvent.Message}");
        }
    }
}