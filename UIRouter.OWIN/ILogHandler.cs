using UIRouter.OWIN.Log;

namespace UIRouter.OWIN
{
    public interface ILogHandler
    {
        void Log(LoggingEvent loggingEvent);
    }
}
