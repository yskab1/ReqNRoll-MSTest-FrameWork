using FrameWork.Core.Configuration;
using FrameWork.Core.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.UI
{
    public class Browser
    {
        [ThreadStatic]
        private static IWebDriver _driver;
        public static IWebDriver Driver => _driver;
        public Browser()
        {
            _driver = WebDriverFactory.CreateDriver(ConfigReader.BrowserType);
        }


        public static void GotoHomePage()
        {
            _driver.Navigate().GoToUrl(ConfigReader.TargetURL);
        }
        public static IWebElement FindElementWithWait(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(int.Parse(ConfigReader.TimeoutSeconds)));
            return wait.Until
                (d =>
                    {
                        // 1. Try to find the element on the webpage
                        IWebElement element = d.FindElement(locator);

                        // 2. Check if the element is actually visible to the user
                        if (element.Displayed)
                        {
                            return element; // Found it and visible! Stop waiting and return it.
                        }
                        else
                        {
                            return null; // Found it but hidden. Keep waiting...
                        }
                    }
                );
        }
        public string CaptureScreenshotAsBase64()
        {
            if (_driver == null) return null;
            try
            {
                var ts = (ITakesScreenshot)_driver;
                return ts.GetScreenshot().AsBase64EncodedString;
            }
            catch
            {
                return null;
            }
        }

        public void Quit()
        {
            if (_driver != null) 
            { 
                _driver.Quit(); 
                _driver.Dispose(); 
            }

        }
    }
}
