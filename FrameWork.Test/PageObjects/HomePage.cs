using FrameWork.Core.UI;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;

namespace Framework.Tests.PageObjects
{
    
    public static class HomePage 
    {
        /*
        //1 ans 2 are example of a page object class Locators and Accessor Properties. 
        // 1. By Locators
        public static By NameLocator = By.Id("name-input");

        public static By SaveButtonLocator = By.Id("save-record-btn");

        // 2.  Accessor Properties use FindElementWithWait for most cases
        public static IWebElement NameF => Browser.Driver.FindElement(NameLocator);
        public static IWebElement SaveButton => Browser.Driver.FindElement(SaveButtonLocator);
        */

        // Google search box  Locator example
        public static By SearchTextBoxLocator = By.XPath("//*[@aria-label='Search']");
        // Google search box  Accessor example
        public static IWebElement SearchTextBox => Browser.FindElementWithWait(SearchTextBoxLocator);




    


    }
}
