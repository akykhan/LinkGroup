using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace LinkGroup.DemoTests.Pages
{

    public class LinkGroupCode
    {
        public IWebDriver driver;

        public void ClickPolicyButton()
        {
            driver.FindElement(By.CssSelector(".btn.btn-light.mr-3")).Click();
        }

        public void SearchValue(string value)
        {
           
        }

    }


}
