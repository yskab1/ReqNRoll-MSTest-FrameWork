using Framework.Tests.PageObjects;
using FrameWork.Core.UI;
using OpenQA.Selenium;

namespace FrameWorkl.Test
{
    [TestClass]
    public class Test1 : Browser
    {

        [TestMethod]
        public void TestMethod1()
        {
            Browser.GotoHomePage();
            Thread.Sleep(2000);
            HomePage.SearchTextBox.SendKeys("Selenium WebDriver");
            Thread.Sleep(2000);
            HomePage.SearchTextBox.Submit();
            Thread.Sleep(2000);
            Browser.Driver.Navigate().Back();
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Browser.Driver.Quit();
        }
    }
}
