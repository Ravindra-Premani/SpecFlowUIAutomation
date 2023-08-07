using System;
using System.Threading;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using IPortSpecflowFramework.Drivers;
using System.Collections.Generic;
using assert = NUnit.Framework.Assert;
using webhooks = IPortSpecflowFramework.Hooks.WebHooks;
using IPortSpecflowFramework.Utilities;

using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace IPortSpecflowFramework.PageObjects
{
    public class DeleteExistingDashboardsPageObjects : DriverHelpers
    {
        
        WaitHelpers waitHelpers = new WaitHelpers();

        public static string dashboardname;


        public IWebDriver WebDriver { get; }
        public DeleteExistingDashboardsPageObjects(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IList <IWebElement> imgIPortDasboard => WebDriver.FindElements
            (By.XPath("//a[@class = 'item link-hover-box-shadow']//div"));  //div[@class='table']//div[1]//div[1]//a[1]//img[1]

        public IWebElement clickMyIPortDrpDwn => WebDriver.FindElement
            (By.XPath("//span[contains(text(), 'My iports')]"));

        public IWebElement clickDashboardBinBtn => WebDriver.FindElement
            (By.XPath("//div[@class = 'mj-grid-cell name mj-nowrap' and contains(text()," + "'" + dashboardname + "'" + ")]/following-sibling::div[@class = 'mj-grid-cell delete']"));//div[@class='mj-grid-row mj-selected']//div[@class='mj-grid-cell delete']//img[@class='mj-image']

        public IWebElement dashboardDeleteBtn => WebDriver.FindElement
            (By.XPath("//a[@class = 'bbm-button ok']"));

        public IWebElement verifyDeleteIPortMessage => WebDriver.FindElement
            (By.XPath("//div[@class='message']"));


        

        public void ClickMyIPortDropDown() => clickMyIPortDrpDwn.Click();

        public void VerifyDashboardBinButton()
        {
            try
            {
                waitHelpers.ExplicitWait(WebDriver, "//div[@class = 'mj-grid-cell name mj-nowrap' and contains(text()," + "'" + dashboardname + "'" + ")]/following-sibling::div[@class = 'mj-grid-cell delete']");
                bool message = clickDashboardBinBtn.Displayed;
                assert.AreEqual(true, message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void ClickDashboardBinButton() => clickDashboardBinBtn.Click();

        public void DashboardDeleteButton() => dashboardDeleteBtn.Click();

        public void VerifyDeleteDashboardMessage()
        {
            try
            {                
                waitHelpers.ExplicitWait(WebDriver, "//div[@class='message']");
                bool message = verifyDeleteIPortMessage.Displayed;
                var MediaEntity = webhooks._driverHelper.CaptureScreenshotAndReturnModel("Verify the Delete IPort Message");
                webhooks.step.Log(Status.Pass, "User to verify the delete IPort message in the screenshot - ", MediaEntity);
                assert.AreEqual(true, message);
            }
            catch (Exception ex)
            {
                assert.Fail(ex.Message);
                throw;
            }

        }

        public void DeleteAllExistingDashboards()
        {
            try
            {
                Thread.Sleep(5000);
                for (int i = 0; i < imgIPortDasboard.Count; i++)
                {
                    dashboardname = imgIPortDasboard[i].Text;
                    imgIPortDasboard[i].Click();
                    ClickMyIPortDropDown();
                    VerifyDashboardBinButton();
                    ClickDashboardBinButton();
                    VerifyDeleteDashboardMessage();
                    DashboardDeleteButton();
                    Thread.Sleep(5000);
                    webhooks.step.Log(Status.Pass, "Successfully Deleted the dashboard - " + dashboardname);
                    //WebDriver.Navigate().Refresh();
                    Thread.Sleep(5000);
                }                             
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
