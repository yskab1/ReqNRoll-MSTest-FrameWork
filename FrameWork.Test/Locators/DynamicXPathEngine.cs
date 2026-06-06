using OpenQA.Selenium;

namespace Framework.Tests.Locators
{
    public static class DynamicXPathEngine
    {
        // Custom string interpolation method to handle changing options (e.g. Male/Female, Yes/No)
        public static By GetRadioButtonLocator(string labelIdentifier, string targetValue)
        {
            return By.XPath($"//div[contains(text(), '{labelIdentifier}')]/following-sibling::input[@value='{targetValue}']");
        }
    }
}