using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Driver
{
    public class SeleniumDriver
    {

        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {
            driver = new ChromeDriver();

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;  
        }

    }

}
