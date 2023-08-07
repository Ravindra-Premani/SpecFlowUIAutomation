using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace IPortSpecflowFramework.Drivers
{
    [Binding]
    public class DriverHelpers
    {        
         public IWebDriver Driver { get; set; }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }
    }    
}
