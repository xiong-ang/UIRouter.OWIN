using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UIRouter.OWIN.Utils;

namespace UIRouter.OWIN.Test
{
    [TestClass]
    public class RouterHelperTest
    {
        [TestMethod]
        public void TestFormatStaticUIRouter()
        {
            Assert.IsTrue(string.Equals(RouterHelper.FormatStaticUIRouter(string.Empty), ""), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatStaticUIRouter(""), ""), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatStaticUIRouter("/"), ""), "Format Error");

            Assert.IsTrue(string.Equals(RouterHelper.FormatStaticUIRouter("ui/ui1"), "/ui/ui1"), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatStaticUIRouter("/ui/ui1"), "/ui/ui1"), "Format Error");
        }

        [TestMethod]
        public void TestFormatWebApiRouter()
        {
            Assert.IsTrue(string.Equals(RouterHelper.FormatWebApiRouter(string.Empty), ""), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatWebApiRouter(""), ""), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatWebApiRouter("/"), ""), "Format Error");

            Assert.IsTrue(string.Equals(RouterHelper.FormatWebApiRouter("ui/ui1"), "ui/ui1"), "Format Error");
            Assert.IsTrue(string.Equals(RouterHelper.FormatWebApiRouter("/ui/ui1"), "ui/ui1"), "Format Error");
        }
    }
}
