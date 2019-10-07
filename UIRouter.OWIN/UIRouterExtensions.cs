using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Web.Http;
using UIRouter.OWIN.Log;

namespace UIRouter.OWIN
{
    public static class UIRouterExtensions
    {
        public static IAppBuilder UseUIRouter(this IAppBuilder app, UIRouterConfig config)
        {
            //use cros middleware
            app.UseCors(CorsOptions.AllowAll);


            //format user input config
            config = config.GetFormatConfig();


            if (!string.IsNullOrWhiteSpace(config.LogRouter))
            {
                //use log api middleware
                LoggingEvent.LogHandler = config.LogHandler;

                try
                {
                    var webApiConfig = new HttpConfiguration();
                    webApiConfig.Routes.MapHttpRoute(
                        name: "UIRouterLoggApi",
                        routeTemplate: config.LogRouter,
                        defaults: new { controller = "Log" }
                    );
                    app.UseWebApi(webApiConfig);
                }
                catch (System.Exception)
                {
                    throw new Exception("Log router setting constains error!");
                }
            } 


            try
            {
                //use ui static files server middleware
                foreach (var item in config.UIRouter)
                {
                    var fileSystem = new PhysicalFileSystem(item.Value);

                    var options = new FileServerOptions
                    {
                        EnableDirectoryBrowsing = true,
                        FileSystem = fileSystem,
                        RequestPath = new PathString(item.Key)
                    };

                    app.UseFileServer(options);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"UI router settings contain error: {e.ToString()}");
            }
            

            return app;
        }
    }
}
