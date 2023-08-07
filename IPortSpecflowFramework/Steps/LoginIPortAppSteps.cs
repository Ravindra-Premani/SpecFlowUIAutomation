using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;
using IPortSpecflowFramework.Drivers;
using IPortSpecflowFramework.Utilities;
using assert = NUnit.Framework.Assert;
using Serilog;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class LoginIPortSteps
    {        

        LoginPageObjects loginPageObj = null;
        ExcelUtility excelUtility = new ExcelUtility();

        private DriverHelpers _driverHelper;
        public LoginIPortSteps(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {            
            loginPageObj = new LoginPageObjects(_driverHelper.Driver);
            Log.Debug("Navigate to {0} on chrome browser");
        }

        [Given(@"User enters ""(.*)"" and ""(.*)""")]
        public void GivenUserEntersAnd(string username, string password)
        {
            loginPageObj.LoginIPort(username, password);
            Log.Debug("Entered {0} and {1}", username, password);
        }

        //Table Approach       
        [When(@"User enters UserName and Password")]
        public void GivenUserEntersUserNameAndPassword(Table table)
        {            
            dynamic data = table.CreateDynamicInstance();
            loginPageObj.LoginIPort((string)data.UserName, (string)data.Password);
            Log.Debug("Entered {0} and {1}", (string)data.UserName, (string)data.Password);
        }

        [When(@"User clicks login")]
        public void WhenUserClicksLogin()
        {
            loginPageObj.ClickLoginButton();
            Log.Debug("Clicked on Login button {0}");
        }

        [Then(@"Verify Create iPort Now Button Is Visible")]
        public void ThenVerifyCreateIPortNowButtonIsVisible()
        {
            assert.AreEqual(true, loginPageObj.IsCreateIPortNowBtnExists());
        }

        [Then(@"Verify the wrong username and password message")]
        public void ThenVerifyTheWrongUsernameAndPasswordMessage()
        {
            loginPageObj.VerifyWrongUserAndPassMessage();
        }

        [When(@"User creates excel sheet ""(.*)""")]
        public void WhenUserCreatesExcelSheet(string filename, Table table)
        {            
            excelUtility.CreateXLSFile(@"C:\D_DRIVE\IPort\iportautomation\IPortSpecflowFramework\TestData\TestInput\" + filename, table);
        }
    }
}

//********************************************************************************************************
//Scenario Outline Approach for future reference

//[When(@"User enters (.*) and (.*)")]
//public void WhenUserEntersAnd(string username, string password)
//{
//    loginPageObj.LoginIPort(username, password);
//}


//Feature: LoginIPortApp
//   As a user of IPORT Application
//	I want to verify whether I can successfully login to the application or not

//@smoke
//Scenario Outline: Login user with Valid Credentials
//	Given I navigate to application
//	When User enters <UserName> and <Password>
//	When User clicks login
//	Then Verify Create iPort Now Button Is Visible

//	Examples:

//        | UserName | Password |

//        | jitendra.verma.consultant@nielsen.com | iPort!23 |

//        | sarvesh.maurya.consultant@nielsen.com | iPort!2 |
//********************************************************************************************************


