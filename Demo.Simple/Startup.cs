using Microsoft.Owin;
using Owin;
using UIRouter.OWIN;

[assembly: OwinStartup(typeof(Demo.Simple.Startup))]

namespace Demo.Simple
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseUIRouter(new UIRouterConfig
            {
                UIRouter = {
                    { "1/ui1", "UIs/ui1" },
                    { "2/ui2", "UIs/ui2" },
                    { "/", "UIs/ui2" }
                },
                LogRouter = "api/log",
                LogHandler = new MyLogHandler()
            });
        }
    }
}
