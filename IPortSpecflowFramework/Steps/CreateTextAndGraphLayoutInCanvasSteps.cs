using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPortSpecflowFramework.PageObjects;
using TechTalk.SpecFlow;
using IPortSpecflowFramework.Drivers;

namespace IPortSpecflowFramework.Steps
{
    [Binding]
    public class CreateTextAndGraphLayoutInCanvasSteps
    {

        CreateTextAndGraphLayoutInCanvasObjects layoutObj = null;

        private DriverHelpers _driverHelper;
        public CreateTextAndGraphLayoutInCanvasSteps(DriverHelpers driverHelpers) => _driverHelper = driverHelpers;

        [When(@"User drags the mouse to create the text layout")]
        public void WhenUserDragsTheMouseToCreateTheTextLayout()
        {
            layoutObj = new CreateTextAndGraphLayoutInCanvasObjects(_driverHelper.Driver);
            layoutObj.DragTextSizeInCanvas();
        }

        [Then(@"User to verify the newly created text layout in drawing canvas")]
        public void ThenUserToVerifyTheNewlyCreatedTextLayoutInDrawingCanvas()
        {
            
        }

    }
}
