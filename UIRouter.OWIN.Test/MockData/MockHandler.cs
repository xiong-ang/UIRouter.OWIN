using System;
using UIRouter.OWIN;
using UIRouter.OWIN.Log;

namespace UIRouterTest
{
    class MockHandler: ILogHandler
    {
        public static LoggingEvent LogRecord = null;

        void ILogHandler.Log(LoggingEvent loggingEvent)
        {
            LogRecord = loggingEvent;
        }
    }
}
