namespace UIRouter.OWIN.Utils
{
    public class RouterHelper
    {
        public static string FormatStaticUIRouter(string inputRouter)
        {
            inputRouter = inputRouter.TrimStart().TrimEnd();

            if (string.IsNullOrWhiteSpace(inputRouter) ||
                string.Equals(inputRouter, "/"))
                return "";

            if (inputRouter.StartsWith("/"))
                return inputRouter;
            else
                return $"/{inputRouter}";
        }

        public static string FormatWebApiRouter(string inputRouter)
        {
            inputRouter = inputRouter.TrimStart().TrimEnd();

            if (string.IsNullOrWhiteSpace(inputRouter))
                return "";

            if (inputRouter.StartsWith("/"))
                return inputRouter.Substring(1);
            else
                return inputRouter;
        }
    }
}
