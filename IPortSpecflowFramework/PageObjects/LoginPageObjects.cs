using System;
using OpenQA.Selenium;
using IPortSpecflowFramework.Utilities;
using System.Collections.Generic;
using System.Text;

namespace IPortSpecflowFramework.PageObjects
{
    public class LoginPageObjects
    {
        ExcelUtility exceUtility = new ExcelUtility();
        public static string UserName;

        public IWebDriver WebDriver { get; }
        public LoginPageObjects(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement txtUserName => WebDriver.FindElement(By.XPath(".//input[@class = 'email iport-input-box-shadow']"));                
        public IWebElement txtPassword => WebDriver.FindElement(By.XPath(".//input[@class = 'password iport-input-box-shadow']"));
        public IWebElement btnLogin => WebDriver.FindElement(By.XPath(".//a[@class = 'btn ok right']"));
        public IWebElement btnCreateIPortNow => WebDriver.FindElement(By.XPath("//a[contains(text(), 'Create iPort Now')]"));
        public IWebElement verifyWrongUserAndPassMessage => WebDriver.FindElement(By.XPath("//div[contains(text(), 'Wrong user name/password')]"));
        

        public void LoginIPort(string userName, string password)
        {            
            UserName = userName;
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }
        public void ClickLoginButton() => btnLogin.Click();


        public bool IsCreateIPortNowBtnExists() => btnCreateIPortNow.Displayed;


        public bool VerifyWrongUserAndPassMessage() => verifyWrongUserAndPassMessage.Displayed;


    }    

}
