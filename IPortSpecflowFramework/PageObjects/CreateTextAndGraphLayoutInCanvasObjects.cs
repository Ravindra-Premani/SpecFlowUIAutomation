using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using webhooks = IPortSpecflowFramework.Hooks.WebHooks;

namespace IPortSpecflowFramework.PageObjects
{

    public class CreateTextAndGraphLayoutInCanvasObjects
    {
        public IWebDriver WebDriver { get; }
        public CreateTextAndGraphLayoutInCanvasObjects(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement dragTextSize => WebDriver.FindElement(By.Id("drawing-canvas"));


        public void DragTextSizeInCanvas()
        {
            //Thread.Sleep(5000);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)webhooks._driverHelper.Driver;
            //js.ExecuteScript("document.body.style.zoom='80%'");  //zoom in and zoom out the chrome browser
            //Thread.Sleep(5000);
            
            Actions actions = new Actions(webhooks._driverHelper.Driver);
            Thread.Sleep(5000);
            actions.ClickAndHold(dragTextSize).MoveByOffset(-400, -50).Release().Build().Perform();            
        }
    }
}
