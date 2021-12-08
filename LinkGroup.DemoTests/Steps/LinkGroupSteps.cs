using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LinkGroup.DemoTests.Feature
{
    [Binding]
    public class LinkGroupSteps
    {

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public LinkGroupSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
           
        }

        [Given(@"I have opened the home page")]
        [When(@"I open the home page")]
        public void WhenIOpenTheHomePage()
        {
            driver = _scenarioContext.Get<Driver.SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl("https://www.linkgroup.eu");
        }
        
        
        [Then(@"the page is displayed")]
        public void ThenThePageIsDisplayed()
        {
            string currentURL = "https://www.linkgroup.eu";
            Assert.IsTrue(currentURL == driver.Url);
            
        }

        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            driver.FindElement(By.CssSelector("#btnAccept")).Click();
        }

        [When(@"I search for '(.*)'")]
        public void WhenISearchFor(string value)
        {
            IWebElement elem = driver.FindElement(By.CssSelector(".fa.fa-search"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(elem).Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("input[name=searchTerm]")).Click();
            driver.FindElement(By.CssSelector("input[name=searchTerm]")).SendKeys(value);
            driver.FindElement(By.CssSelector(".btn.btn-outline-default")).Click();
        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplayed()
        {
            string currentURL = "https://www.linkgroup.eu/search-results/?searchTerm=Leeds";
            Assert.IsTrue(currentURL == driver.Url);
        }

    }
}
