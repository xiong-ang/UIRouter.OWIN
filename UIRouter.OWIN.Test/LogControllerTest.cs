using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using UIRouter.OWIN.Log;
using UIRouterTest;

namespace UIRouter.OWIN.Test
{
    [TestClass]
    public class LogControllerTest
    {
        private static readonly LogController logController = new LogController();
        private static readonly LoggingEvent loggingEvent = new LoggingEvent { Level = LogLevel.Error, Message = "Mock Message" };

        [TestMethod]
        public void PostTest()
        {
            LoggingEvent.LogHandler = new MockHandler();
            LoggingEvent e = new LoggingEvent();
            logController.Request = new HttpRequestMessage(HttpMethod.Post, "");
            logController.Post(loggingEvent);

            Assert.AreEqual(loggingEvent, MockHandler.LogRecord, "Post call failed");
        }
    }
}
