using Microsoft.Owin;
using Owin;
using UIRouter.OWIN;

[assembly: OwinStartup(typeof(UIRouterTest.MockStartup))]

namespace UIRouterTest
{
    public class MockStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseUIRouter(new UIRouterConfig
            {
                UIRouter ={
                    { "UI", "UI" }
                },
                LogRouter = "Api/Log",
                LogHandler = new MockHandler()
            });
        }
    }
}
