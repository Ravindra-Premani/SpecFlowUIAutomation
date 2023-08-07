using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IPortSpecflowFramework.Utilities
{   
    public class WaitHelpers
    {
        
        public IWebElement ExplicitWait(IWebDriver driver, string identifier)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.XPath(identifier)));
        }
    }
}
