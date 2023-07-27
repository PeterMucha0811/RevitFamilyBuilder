using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Linq;
using System.Threading;
using UIAutomation.Constants;

namespace UIAutomation.Commands
{
    public class FlaUIDemo
    {
        //public FlaUIDemo()
        //{
        //    // Launch the EnergyGaugeSummit application
        //    var app = Application.Launch(HardCodedValues.EnergyGaugeExePath);
        //    app.WaitWhileBusy();


        //    // Wait for the splash screen to close
        //    Thread.Sleep(1000); // Wait for 1 seconds (adjust if needed)

        //    // Handle the dialog notification if it appears
        //    Window dialogWindow = null;



        //    //var poop = app.GetAllTopLevelWindows(new UIA3Automation();



        //    #region Wait for the Application to Initialize/Load
        //    do
        //    {
        //        Thread.Sleep(100);



        //        dialogWindow = app.GetAllTopLevelWindows(new UIA3Automation())
        //            .FirstOrDefault(w => w.Properties.ControlType.Value == FlaUI.Core.Definitions.ControlType.Window
        //                && w.Properties.IsDialog.Value == true // Is Dialog Bool
        //                && w.Properties.Name.Value == "EnergyGauge Summit"); // Dialog window name


        //        if (dialogWindow != null)
        //        {
        //            HandleDialogNotification(dialogWindow);
        //        }

        //    } while (dialogWindow != null);

        //    #endregion

        //    // Get the main window of the EnergyGaugeSummit application
        //    Window mainAppWindow = app.GetMainWindow(new UIA3Automation());

        //    // Continue with the rest of the UI automation
        //    PerformUIAutomation(mainAppWindow);
        //}

        //// Dialog Notification Handeler
        //private void HandleDialogNotification(Window dialogWindow)
        //{
        //    // Find and interact with the "OK" button of the dialog notification
        //    var okButton = dialogWindow.FindFirstChild(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Button)
        //        .And(cf.ByAutomationId("2"))).AsButton();

        //    // Click the "OK" button if found
        //    okButton?.Click();
        //}
        //private void PerformUIAutomation(Window mainWindow)
        //{
        //    // Continue with the rest of your UI automation code here
        //    // Find and interact with UI elements as needed
        //    // For example:
        //    // var button = mainWindow.FindFirstChild(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Button)
        //    //     .And(cf.ByAutomationId("buttonId"))).AsButton();
        //    // button?.Click();
        //}
    }
}








////using FlaUI.Core;
////using FlaUI.Core.AutomationElements;
////using FlaUI.Core.Conditions;
////using FlaUI.UIA3;
////using System.Threading;

////namespace UIAutomation
////{
////    internal class FlaUIDemo
////    {
////        public FlaUIDemo()
////        {
////            // Launch the EnergyGaugeSummit application
////            Application app = Application.Launch("C:\\Program Files (x86)\\EnergyGauge\\EnergyGaugeSummit\\EnergyGaugeSummit.exe");

////            // Wait for the application window to appear
////            Window appMainWindow = null;
////            do
////            {
////                Thread.Sleep(100); // Pause for a short duration
////                appMainWindow = app.GetMainWindow(new UIA3Automation());
////            } while (appMainWindow == null);

////            // Handle the pop-up notification if it appears
////            if (IsPopupNotificationVisible(appMainWindow))
////            {
////                HandlePopupNotification(appMainWindow);
////            }

////            // Continue with the rest of the UI automation
////            PerformUIAutomation(appMainWindow);
////        }

////        private bool IsPopupNotificationVisible(Window mainWindow)
////        {
////            // Add code to check if the pop-up notification is visible
////            // You can use UI Automation to find the necessary UI elements and determine their visibility
////            // Return true if the pop-up notification is visible, false otherwise
////            // For example:
////            // var popupNotification = mainWindow.FindFirstDescendant(c => c.ByAutomationId("popupNotification"));
////            // return popupNotification != null && popupNotification.IsOffscreen == false;
////            return false; // Replace with your implementation
////        }

////        private void HandlePopupNotification(Window mainWindow)
////        {
////            // Add code to handle the pop-up notification
////            // This can include finding and interacting with UI elements in the pop-up
////            // For example, you can click on the "OK" button to dismiss the notification:
////            // var okButton = mainWindow.FindFirstDescendant(c => c.ByAutomationId("okButton")).AsButton();
////            // okButton?.Click();
////        }

////        private void PerformUIAutomation(Window mainWindow)
////        {
////            // Continue with the rest of your UI automation code here
////            // Find and interact with UI elements as needed
////            // For example:
////            // var button = mainWindow.FindFirstDescendant(c => c.ByAutomationId("buttonId")).AsButton();
////            // button?.Click();
////        }
////    }
////}

