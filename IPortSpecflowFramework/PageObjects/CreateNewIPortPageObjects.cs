using System;
using System.Threading;
using OpenQA.Selenium;
using IPortSpecflowFramework.Drivers;
using assert = NUnit.Framework.Assert;
using IPortSpecflowFramework.Utilities;
using loginPageObj = IPortSpecflowFramework.PageObjects.LoginPageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace IPortSpecflowFramework.PageObjects
{
    public class CreateNewIPortPageObjects
    {
       
        WaitHelpers waitHelpers = new WaitHelpers();

        public static string dashBoardName;
        public IWebDriver WebDriver { get; }
        public CreateNewIPortPageObjects(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement txtCreateNewIPort => WebDriver.FindElement(By.XPath("//input[@class = 'name iport-input-box-shadow']"));

        public IWebElement imgIPort => WebDriver.FindElement(By.XPath("//img[@class = 'logo-image left']"));

        public IWebElement btnCreateIPortNow => WebDriver.FindElement(By.XPath("//a[contains(text(), 'Create iPort Now')]"));

        public IWebElement dropDownMyIPorts => WebDriver.FindElement(By.XPath("//span[contains(text(),'My iports')]"));

        public IWebElement dashboardName => WebDriver.FindElement(By.XPath("//div[contains(text()," + "'" + dashBoardName + "'" + ")]"));

        public IWebElement clickMyDetails => WebDriver.FindElement(By.XPath("//span[contains(text(), 'My Details')]"));

        public IWebElement verifyUserName => WebDriver.FindElement(By.XPath("//label[@class = 'xx-large']"));

        public IWebElement btnLogout => WebDriver.FindElement(By.XPath("//a[@class = 'logout']"));
        

        

        public void EnterNewIPortName(string iPortName)
        {
            txtCreateNewIPort.SendKeys(iPortName);
        }

        public void ClickCreateNewIPortButton() => btnCreateIPortNow.Click();

        public bool IsIPortImageExists() => imgIPort.Displayed;

        public void ClickMyIPortsDropDown() => dropDownMyIPorts.Click();

        public void VerifyDashboardName()
        {
            string dashboardname = dashboardName.Text;
            assert.AreEqual(dashboardname, dashBoardName);
        }

        public void ClickMyDetailsSection() => clickMyDetails.Click();

        public void VerifyUserNameAfterLogin()
        {
            waitHelpers.ExplicitWait(WebDriver, "//label[@class = 'xx-large']");            
            string username = verifyUserName.Text;            
            assert.AreEqual(username, loginPageObj.UserName);            
        }


        public bool IsLogoutButtonDisplayed() => btnLogout.Displayed;

        public void ClickLogoutButton() => btnLogout.Click();

       

    }
}
