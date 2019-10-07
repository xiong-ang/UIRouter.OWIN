using System.Net;
using System.Web.Http;

namespace UIRouter.OWIN.Log
{
    public class LogController : ApiController
    {
        [HttpPost]
        [Route("")]
        public HttpStatusCode Post([FromBody]LoggingEvent loggingEvent)
        {
            loggingEvent.Output();

            return HttpStatusCode.OK;
        }
    }
}
