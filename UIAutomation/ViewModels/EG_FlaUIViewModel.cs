using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Linq;
using System.Threading;
using System;
using System.Collections.Generic;
using UIAutomation.Commands;
using System.Collections.ObjectModel;
using UIAutomation.Constants;
using FlaUI.Core.Definitions;
using Application = FlaUI.Core.Application;
using Window = FlaUI.Core.AutomationElements.Window;
using System.Diagnostics;
using FlaUI.Core.Input;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Point = System.Drawing.Point;
using UIAutomation.Utilities_FlaUI;
using OpenCvSharp;

namespace UIAutomation.ViewModels
{
    public class EG_FlaUIViewModel : ViewModelBase
    {
        private LaunchApp _app;

        public EG_FlaUIViewModel()
        {
            // Register Commands
            LaunchAppCommand = new RelayCommand(LaunchAppFlaUIButton_Command);
        }


        // Registered Commands
        public RelayCommand LaunchAppCommand { get; private set; }


        private void LaunchAppFlaUIButton_Command()
        {
            _app = new LaunchApp();
            _app.LaunchAndInteractWithApp();
        }
    }
}
