using Microsoft.Owin;
using Owin;
using UIRouter.OWIN;

[assembly: OwinStartup(typeof(UIRouter.CEF.Example.Startup))]

namespace UIRouter.CEF.Example
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseUIRouter(new UIRouterConfig
            {
                UIRouter = {
                    { "/ui", "UI" }
                },
                LogRouter = "api/log",
                LogHandler = new MyLogHandler()
            });
        }
    }
}
