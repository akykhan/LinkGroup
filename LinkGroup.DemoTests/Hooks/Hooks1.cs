using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using LinkGroup.DemoTests.Driver;
using OpenQA.Selenium;

namespace LinkGroup.DemoTests.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        public HookInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}
