using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UIRouter.OWIN.Log;
using UIRouterTest;

namespace UIRouter.OWIN.Test
{
    [TestClass]
    public class OWINMiddleWareTest
    {
        [TestMethod]
        public async Task TestUIHost()
        {
            using (var server = TestServer.Create<MockStartup>())
            {
                using (var client = new HttpClient(server.Handler))
                {
                    var response = await client.GetAsync("http://testserver/ui");

                    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Moved, "Invalid Status Code");
                    Assert.IsInstanceOfType(response.Content, typeof(StreamContent), "Invalid Type");
                }
            }
        }

        [TestMethod]
        public async Task TestLogHost()
        {
            LoggingEvent loggingEvent = new LoggingEvent { Level = LogLevel.Error, Message = "Mock Message" };
            var myContent = JsonConvert.SerializeObject(loggingEvent);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var server = TestServer.Create<MockStartup>())
            {
                using (var client = new HttpClient(server.Handler))
                {
                    var response = await client.PostAsync("http://testserver/Api/Log", byteContent);

                    //Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK, "Invalid Status Code");
                    Assert.IsTrue(response.IsSuccessStatusCode, "Invalid Status");

                    Assert.AreEqual(myContent, JsonConvert.SerializeObject(MockHandler.LogRecord), "Post call failed");
                }
            }
        }
    }
}
