using System;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.Drivers;
using IPortSpecflowFramework.PageObjects;
using assert = NUnit.Framework.Assert;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class DeleteExistingDashboardsSteps
    {

        DeleteExistingDashboardsPageObjects DelDashboard = null;

        private DriverHelpers _driverHelper;
        public DeleteExistingDashboardsSteps(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;


        [Then(@"Delete all the existing dashboards")]
        public void ThenDeleteAllTheExistingDashboards()
        {
            DelDashboard = new DeleteExistingDashboardsPageObjects(_driverHelper.Driver);
            DelDashboard.DeleteAllExistingDashboards();
        }


    }
}
