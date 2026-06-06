using Framework.Tests.PageObjects;
using FrameWork.Core.UI;
using OpenQA.Selenium.DevTools.V146.IndexedDB;
using Reqnroll;
using System;

namespace FrameWork.Test.StepDefination
{
    [Binding]
    public class HomePageStepDef 
    {
        [Given("I Navigate to the Home Page")]
        public void GivenINavigateToTheHomePage()
        {
            Browser.GotoHomePage();
        }

        [Given("I Enter {string} in the Search Box")]
        public void GivenIEnterInTheSearchBox(string p0)
        {
            HomePage.SearchTextBox.SendKeys(p0);
            Thread.Sleep(2000);
        }

        [When("I Click on the Search Button")]
        public void WhenIClickOnTheSearchButton()
        {
            HomePage.SearchTextBox.Submit();
        }

        [Then("I Should See Search Results for {string}")]
        public void ThenIShouldSeeSearchResultsFor(string p0)
        {
            Thread.Sleep(2000);
            Browser.Driver.Navigate().Back();
        }

    }
}
