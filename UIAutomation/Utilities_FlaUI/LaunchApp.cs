using System;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using FlaUI.UIA3.Identifiers;
using UIAutomation.ViewModels;

namespace UIAutomation.Utilities_FlaUI
{
    public class LaunchApp : ViewModelBase
    {
        //private UIA3Automation _automation;
        //private Application _application;

        //public Application Application
        //{
        //    get { return _application; }
        //    set
        //    {
        //        _application = value;
        //        OnPropertyChanged(nameof(Application));
        //    }

        //}

        //public async Task LaunchAndInteractWithAppAsync(IProgress<string> progress)
        //{
        //    // Initialize FlaUI Automation
        //    _automation = new UIA3Automation();

        //    // Launch the application (replace "YourApp.exe" with the appropriate value)
        //    _application = Application.Launch("YourApp.exe");

        //    // Wait for the main window of the application to appear
        //    var mainWindowCondition = new PropertyCondition(AutomationObjectIds.ControlTypeProperty, ControlType.Window);
        //    var mainWindow = _application.GetMainWindow(_automation, mainWindowCondition);
        //    await mainWindow.WaitForInitialized(); // Wait for the window to be initialized

        //    // Report progress to the UI
        //    progress.Report("Application launched successfully!");

        //    // Perform other actions on the application window (e.g., click buttons, read values, etc.)

        //    // Report more progress to the UI
        //    progress.Report("Actions completed!");

        //    // OnPropertyChanged will be called automatically when you set the Application property
        //}



        //// Other asynchronous methods can now access the application instance and interact with its UI window
        //public async Task DoOtherActionsAsync()
        //{
        //    // Access the application instance using the Application property
        //    if (_application != null)
        //    {
        //        // Perform other actions on the application window
        //    }
        //}


    }
}