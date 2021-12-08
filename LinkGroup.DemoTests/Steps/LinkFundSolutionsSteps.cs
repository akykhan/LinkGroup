﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace LinkGroup.DemoTests.Feature
{
    [Binding]
    public class LinkFundSolutionsSteps
    {

        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public LinkFundSolutionsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }


        [Given(@"I have opened the Found Solutions page")]
        public void GivenIHaveOpenedTheFoundSolutionsPage()
        {
            driver = _scenarioContext.Get<Driver.SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk");
        }
        
        [When(@"I view Funds")]
        public void WhenIViewFunds()
        {
            IWebElement elem = driver.FindElement(By.Id("navbarDropdown"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(elem).Perform();
            Thread.Sleep(5000);
        }
        
        [Then(@"I can select the investment managers for UK investors")]
        public void ThenICanSelectTheInvestmentManagersForUKInvestors()
        {

            IList<IWebElement> selectElements = driver.FindElements(By.CssSelector(".nav.flex-column .nav-item"));
            var displayedSelectElements = selectElements.Where(se => se.Displayed);
            //var option = driver.FindElement(By.CssSelector(".nav.flex-column .nav-item"));
            //var selectElement = new SelectElement(option);
            //Thread.Sleep(5000);
            //selectElement.SelectByText("UK");
        }
    }
}
