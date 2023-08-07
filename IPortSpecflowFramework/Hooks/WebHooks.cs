using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.Drivers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using IPortSpecflowFramework.Utilities;
using AventStack.ExtentReports.Reporter.Configuration;
using relativePathUtility = IPortSpecflowFramework.Utilities.RelativePathUtility;
using OpenQA.Selenium.Interactions;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Serilog.Core;
using Serilog;
using Serilog.Formatting.Json;
  

//[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace IPortSpecflowFramework.Hooks
{
    [Binding]
    public class WebHooks : DriverHelpers
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks                

        static ExtentReports extent;
        static ExtentTest feature;
        public static ExtentTest scenario, step;

        ExcelUtility excelUtility = new ExcelUtility();        
      

        public static string filepath = Path.Combine(relativePathUtility.AssemblyDirectory, @"..\..\..\TestData\TestInput\IPORT_Input_Sheet.xls");        

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //string reportpath1 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //+ Path.DirectorySeparatorChar + "ExtentReports"
            //+ Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("yyyyMMd-HHmmss") + "\\";
            
            string reportpath = Path.Combine(relativePathUtility.AssemblyDirectory,  @"..\..\..\ExtentReports\" + "IPortTestReport_" + DateTime.Now.ToString("yyyyMMd-HHmmss") + "\\");
            extent = new ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportpath);
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "IPORT Test Case Report";
            htmlReporter.Config.ReportName = "IPORT Test Case Report";
            extent.AttachReporter(htmlReporter);

            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch).
                WriteTo.File(new JsonFormatter(), reportpath + @"..\..\Logs\logfile_", 
                rollingInterval: RollingInterval.Day).CreateLogger();        // generate logs in json format

//, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}",
//                rollingInterval: RollingInterval.Day).CreateLogger();      // generate logs in text format

        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
            Log.Information("Select feature file {0} to run", context.FeatureInfo.Title);
        }

        public static DriverHelpers _driverHelper;
        public WebHooks(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized"); // maximize the window
            option.AddExcludedArgument("enable-automation"); //disbale the popup "chrome is being controlled by automated test software"            
            option.AddUserProfilePreference("credentials_enable_service", false);  //disable the save password popup
            option.AddUserProfilePreference("profile.password_manager_enabled", false);
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driverHelper.Driver = new ChromeDriver();
            //_driverHelper.Driver = new ChromeDriver(@"C:\D_DRIVE\ChromeDriver\", option);            
            //_objectContainer.RegisterInstanceAs(_driverHelper.Driver); 
            //TODO: implement logic that has to run before executing each scenario
            //Driver = new ChromeDriver(@"C:\Users\s_pfusionqc01.t1\Downloads\chromedriver_win32\chromedriver.exe");
            _driverHelper.Driver.Navigate().GoToUrl(excelUtility.ReadXLSFile(filepath, "IPORT URL"));
            _driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driverHelper.Driver.Manage().Cookies.DeleteAllCookies();
            Log.Information("Select scenario {0} to run", context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                Log.Information("Test Step Passed | " + context.StepContext.StepInfo.Text);
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                Log.Error("Test Step Failed | " + context.TestError.Message);
                var MediaEntity = _driverHelper.CaptureScreenshotAndReturnModel(context.ScenarioInfo.Title.Trim());
                step.Log(Status.Fail, context.StepContext.StepInfo.Text).Fail(context.ScenarioInfo.Title.Trim() +" - ", MediaEntity);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            _driverHelper.Driver.Quit();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
