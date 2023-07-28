using Window = FlaUI.Core.AutomationElements.Window;
using Point = System.Drawing.Point;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using System.Drawing;
using UIAutomation.Utilities_FlaUI.EG_Methods;

namespace UIAutomation.Utilities_OpenCv.EG_PageObjects
{
    public class ProjectInfo_WspPane
    {
        #region Properties
        private Window _appWindow;


        // Below are the AutomationId's of the Project Information Window/Tab


        // Group: Description //
        private const string _acronym = "40";
        private const string _title = "41";
        private const string _owner = "39";

        // Group: Building Info //
        //private const string _type = "";
        //private const string _class = "";
        //private const string _areaFromPlans = "";
        //private const string _stories = "";
        //private const string _ = "";
        //private const string _ = "";
        //private const string _ = "";
        //private const string _ = "";
        //private const string _ = "";


       

        #endregion

        public ProjectInfo_WspPane(Window appWindow)
        {
            if (appWindow != null)
            {
                _appWindow = appWindow;

               
            }
        }


        public void SetValue_Acronym()
        {
            // Set the value of a textbox by its AutomationId
            var textBoxHandler = new TextBoxHandler();

            textBoxHandler.SetTextBoxValueByAutomationId(_appWindow, _acronym, "New Value");
        }



















    }
}
