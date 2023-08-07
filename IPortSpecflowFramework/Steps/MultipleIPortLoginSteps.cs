using System;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using IPortSpecflowFramework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;
using assert = NUnit.Framework.Assert;
using IPortSpecflowFramework.Drivers;
using IPortSpecflowFramework.Utilities;
using TechTalk.SpecFlow;
using webhooks = IPortSpecflowFramework.Hooks.WebHooks;
using System.IO;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class MultipleIPortLoginSteps
    {

        LoginPageObjects loginPageObj = null;
        CreateNewIPortPageObjects NewIPortPO = null;
        ExcelUtility excelUtility = new ExcelUtility();


        private DriverHelpers _driverHelper;
        public MultipleIPortLoginSteps(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;



        [When(@"User reads login credentials from excel sheet IPORT_Input_Sheet\.xls")]
        public void WhenUserReadsLoginCredentialsFromExcelSheetIPORT_Input_Sheet_Xls()
        {
            loginPageObj = new LoginPageObjects(_driverHelper.Driver);

            loginPageObj = new LoginPageObjects(_driverHelper.Driver);
            loginPageObj.txtUserName.SendKeys(excelUtility.ReadXLSFile(webhooks.filepath, "UserName"));
            loginPageObj.txtPassword.SendKeys(excelUtility.ReadXLSFile(webhooks.filepath, "Password"));

        }


        [When(@"User reads multiple login credentials from excel sheet IPORT_Input_Sheet\.xls")]
        public void WhenUserReadsMultipleLoginCredentialsFromExcelSheetIPORT_Input_Sheet_Xls()
        {
            loginPageObj = new LoginPageObjects(_driverHelper.Driver);
            NewIPortPO = new CreateNewIPortPageObjects(_driverHelper.Driver);

            HSSFWorkbook hSSFWorkbook;
            using (FileStream file = new FileStream(webhooks.filepath, FileMode.Open, FileAccess.Read))
            {
                hSSFWorkbook = new HSSFWorkbook(file);
            }

            ISheet sheet = hSSFWorkbook.GetSheetAt(0);
            for (int i = 0; i < sheet.LastRowNum; i++)
            {
                for (int j = 0; j <= sheet.GetRow(i).LastCellNum; j++)
                {
                    if (sheet.GetRow(i) != null)
                    {
                        string celldata = sheet.GetRow(i).GetCell(j).StringCellValue;
                        if (celldata == "UserName")
                        {
                            i++;                            
                            for (int k = 1; k <= sheet.LastRowNum; k++)
                            {
                                string cellValueForLogin = sheet.GetRow(i).GetCell(j).StringCellValue;
                                loginPageObj.txtUserName.Clear();
                                loginPageObj.txtUserName.SendKeys(cellValueForLogin);
                                string cellValueForLogin1 = sheet.GetRow(i).GetCell(j + 1).StringCellValue;
                                loginPageObj.txtPassword.SendKeys(cellValueForLogin1);
                                loginPageObj.btnLogin.Click();
                                assert.AreEqual(true, loginPageObj.IsCreateIPortNowBtnExists());
                                assert.AreEqual(true, NewIPortPO.IsLogoutButtonDisplayed());
                                NewIPortPO.ClickLogoutButton();
                                i++;                                
                            }
                            break;
                        }                        
                    }                    
                }                
            }
        }
    }
}

