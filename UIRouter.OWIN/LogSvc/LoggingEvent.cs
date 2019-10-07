using Newtonsoft.Json;

namespace UIRouter.OWIN.Log
{
    [JsonObject]
    public class LoggingEvent
    {
        [JsonProperty("level")]
        private int _level = 0;

        [JsonIgnore]
        public LogLevel Level
        {
            get
            {
                return (LogLevel)_level;
            }
            set
            {
                _level = (int)value;
            }
        }

        [JsonProperty("msg")]
        public string Message;

        public static ILogHandler LogHandler;

        public void Output()
        {
            LogHandler.Log(this);
        }
    }


    public enum LogLevel
    {
        Info = 0,
        Warning,
        Error
    }
}
