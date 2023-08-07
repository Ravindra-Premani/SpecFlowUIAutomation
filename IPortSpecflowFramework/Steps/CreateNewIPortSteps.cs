using System;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;
using IPortSpecflowFramework.Drivers;
using createNewIPortPage = IPortSpecflowFramework.PageObjects.CreateNewIPortPageObjects;
using OpenQA.Selenium.Interactions;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class CreateNewIPortSteps
    {
        createNewIPortPage NewIPortPO = null;

        private DriverHelpers _driverHelper;
        public CreateNewIPortSteps(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;


        [Then(@"User enters dashboard name ""(.*)""")]
        public void ThenUserEntersDashboardName(string dashboardname)
        {
            NewIPortPO = new createNewIPortPage(_driverHelper.Driver);
            createNewIPortPage.dashBoardName = dashboardname + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            NewIPortPO.EnterNewIPortName(createNewIPortPage.dashBoardName);
        }

        

        [Then(@"User clicks create new Iport button")]
        public void ThenUserClicksCreateNewIportButton()
        {
            NewIPortPO.ClickCreateNewIPortButton();
        }
        

        [Then(@"user verifies the iPort logo on the landing page")]
        public void ThenUserVerifiesTheIPortLogoOnTheLandingPage()
        {
            NewIPortPO.IsIPortImageExists();
        }

        [When(@"User to click on My iPorts drop down")]
        public void WhenUserToClickOnMyIPortsDropDown()
        {
            NewIPortPO.ClickMyIPortsDropDown();
        }

        [Then(@"User to verify the newly created dashboard in My iPorts dropdown")]
        public void ThenUserToVerifyTheNewlyCreatedDashboardInMyIPortsDropdown()
        {
            NewIPortPO.VerifyDashboardName();
        }

        [When(@"User clicks on My Details Section")]
        public void WhenUserClicksOnMyDetailsSection()
        {
            NewIPortPO.ClickMyDetailsSection();
        }

        [Then(@"Verify the username")]
        public void ThenVerifyTheUsername()
        {
            NewIPortPO.VerifyUserNameAfterLogin();
        }

        
    }
}
