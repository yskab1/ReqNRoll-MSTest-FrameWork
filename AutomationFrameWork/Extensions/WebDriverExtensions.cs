using OpenQA.Selenium;

namespace Framework.Core.Extensions
{
    public static class WebDriverExtensions
    {
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments.scrollIntoView(true);", element);
        }
    }
}