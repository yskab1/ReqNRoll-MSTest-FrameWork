using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Core.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToUpper())
            {
                case "CHROME":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddArgument("--incognito");
                    return new ChromeDriver(chromeOptions);

                case "EDGE":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new NotImplementedException($"The Browser '{browser}' is not implemented");
                      
            }
        }
    }
}
