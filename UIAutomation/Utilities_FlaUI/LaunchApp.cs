using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using UIAutomation.Constants;
using UIAutomation.Utilities_FlaUI.EG_PageObjects;
using UIAutomation.Utilities_OpenCv.EG_PageObjects;
using UIAutomation.ViewModels;
using Application = FlaUI.Core.Application;
using Window = FlaUI.Core.AutomationElements.Window;

namespace UIAutomation.Utilities_FlaUI
{
    public class LaunchApp : ViewModelBase
    {
        public void LaunchAndInteractWithApp()
        {
            Window mainWindow = null;
            var automation = new UIA3Automation();
            
            // Launch the EnergyGaugeSummit application
            var app = Application.Launch(HardCodedValues.EnergyGaugeExePath);
            app.WaitWhileBusy();

           
            #region Wait for the Application to Initialize/Load

            List<Window> dialogWindows = new List<Window>();

            do
            {
                Thread.Sleep(100);

                // Get all top-level windows
                var topLevelWindows = app.GetAllTopLevelWindows(automation);

                // Check for dialog windows and handle/close them
                dialogWindows = topLevelWindows.Where(w => w.Properties.ControlType.Value == ControlType.Window
                                                           && w.Properties.IsDialog.Value == true).ToList();


                // Call Dialog Handler to close Dialog Windows
                if (dialogWindows.Count > 0)
                {
                    HandleDialogWindow(dialogWindows);
                }

                // Check if the main window is present
                mainWindow = topLevelWindows.FirstOrDefault(
                    w => w.Properties.ControlType.Value == ControlType.Window
                    && w.Properties.Name.Value == "EnergyGauge Summit - [Startup Page]");

            } while (mainWindow == null);

            #endregion

            // Get the main window of the EnergyGaugeSummit application
            Window mainAppWindow = app.GetMainWindow(new UIA3Automation());

            //Continue with the rest of the UI automation
            PerformUIAutomation(mainWindow);
        }



        // Dialog Notification Handeler
        private void HandleDialogWindow(List<Window> dialogWindow)
        {
            // Handle or close the dialog window based on your requirements
            // Example: Close the dialog window by finding and clicking the "Close" button

            if (dialogWindow.Count() > 0)
            {
                foreach (Window dialog in dialogWindow)
                {
                    var closeButton = dialog.FindFirstDescendant(cf => cf
                    .ByControlType(ControlType.Button).And(cf.ByText("Close"))).AsButton();
                    closeButton?.Click();
                }
            }
        }
       


        private void PerformUIAutomation(Window mainWindow)
        {
            // Click New Project button
            var buttons = new ToolBarButtons_Pane(mainWindow);
            buttons.ClickBtn_New();

            Thread.Sleep(1000);

            var test = new ProjectInfo_WspPane(mainWindow);
            test.SetValue_Acronym();

        }
    }
}