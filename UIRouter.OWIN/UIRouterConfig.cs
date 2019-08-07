using System;
using System.Collections.Generic;
using System.IO;
using UIRouter.OWIN.Log;
using UIRouter.OWIN.Utils;

namespace UIRouter.OWIN
{
    public class UIRouterConfig
    {
        //Map<Router, Folder>
        public Dictionary<string, string> UIRouter = new Dictionary<string, string>();
        public string LogRouter = "UIRouterLogApi/Log";
        public ILogHandler LogHandler = new DefaultLogHandler();

        public UIRouterConfig GetFormatConfig()
        {
            UIRouterConfig result = new UIRouterConfig();

            //format ui router
            if(null != this.UIRouter && this.UIRouter.Count > 0)
            {
                foreach (var router in this.UIRouter)
                {
                    var uirouter = RouterHelper.FormatStaticUIRouter(router.Key);
                    var filePath = router.Value;
                    if (!Path.IsPathRooted(filePath))
                        filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                    result.UIRouter.Add(uirouter, filePath);
                }
            }

            //format log router
            if(!string.IsNullOrWhiteSpace(this.LogRouter))
                result.LogRouter = RouterHelper.FormatWebApiRouter(this.LogRouter);

            //format log handler
            if (null != this.LogHandler)
                result.LogHandler = this.LogHandler;

            return result;
        }
    }
}
