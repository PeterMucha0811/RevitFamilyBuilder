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

namespace UIAutomation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            // Register Commands
            LaunchAppCommand = new RelayCommand(LaunchAppFlaUIButton_Command);
        }

        // Registered Commands
        public RelayCommand LaunchAppCommand { get; private set; }

        private void LaunchAppFlaUIButton_Command()
        {
            using (var automation = new UIA3Automation())
            {
                #region Known Values for Reference 

                // // Top Inaccessible ToolBar Button Dimensions  // //
                int marginWidth = 15;
                int newWidth = 56;
                int openWidth = 62;
                int closeWidth = 62;
                int saveWidth = 60;
                int printWidth = 55;
                int helpWidth = 112;


                #endregion

                Window mainWindow = null;
                List<Window> dialogWindows = new List<Window>();

                // Set the startup location to snap the window to the left side
                ProcessStartInfo startInfo = new ProcessStartInfo(HardCodedValues.EnergyGaugeExePath)
                {
                    WindowStyle = ProcessWindowStyle.Normal, // You can use ProcessWindowStyle.Maximized if you want to start it maximized
                };

                Application app = Application.Launch(new ProcessStartInfo(HardCodedValues.EnergyGaugeExePath));



                #region Waiting for App to Initialization and Handle any Dialog Popups
                // Delay before 1st Loop
                Thread.Sleep(1000);

                do
                {
                    Thread.Sleep(1000); // Delay for 1 second

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



                // Application initialization is complete at this point
                if (mainWindow != null)
                {

                    // Find the "Pane" Element based on its Automation ID
                    AutomationElement paneEle = mainWindow.FindFirstDescendant(
                        cf => cf.ByControlType(ControlType.Pane)
                            .And(cf.ByAutomationId("59424")));


                    // Get the Pane Bounding Rectangle Property 
                    Rectangle boundingRectangle = paneEle.Properties.BoundingRectangle.Value;

                    //Get Individual Coordinates of the Rectangle
                    int start_X = boundingRectangle.Left;
                    int start_Y = boundingRectangle.Top;
                    int end_X = boundingRectangle.Right;
                    int end_Y = boundingRectangle.Bottom;

                    // Pane Width and Height
                    int paneWidth = (end_X - start_X);
                    int paneHeight = (end_Y - start_Y);

                    // Center of (X,Y) Axis 
                    int xAxisCenter = (start_X + (paneWidth / 2));
                    int yAxisCenter = (start_Y + (paneHeight / 2));

                    // New Project Button - (X,Y) Click Point
                    int newCenterX = (marginWidth + (newWidth / 2));

                    // Center/Click Points of Buttons
                    int openCenterX = (newCenterX + openWidth);
                    int closeCenterX = (openCenterX + closeWidth);
                    int saveCenterX = (closeCenterX + saveWidth);
                    int printCenterX = (saveCenterX + printWidth);
                    int helpCenterX = (printCenterX + helpWidth);

                    //Click "New" Project Button
                    MouseUtilities.MoveMouseToClick(newCenterX, yAxisCenter);
                    //MoveMouseToClick(newCenterX, yAxisCenter);
                    Thread.Sleep(2000);




                    #region Get Tree View Pane's Scroll Bars

                    // Find the Vertical Scroll Bar
                    AutomationElement scrollBar_Ver = mainWindow.FindFirstDescendant(
                        cf => cf.ByControlType(ControlType.ScrollBar)
                            .And(cf.ByAutomationId("59920")));

                    // Find the Horizontal Scroll Bar
                    AutomationElement scrollBar_Hor = mainWindow.FindFirstDescendant(
                        cf => cf.ByControlType(ControlType.ScrollBar)
                            .And(cf.ByAutomationId("59904")));
                    #endregion


                    #region Get Tree View Pane containing the Project Explorer

                    // Get information about all connected monitors
                    List<GetMonitorInfo.MonitorInfo> connectedMonitors = GetMonitorInfo.GetConnectedMonitors();

                    // Get the bounding rectangle of the Main UI Window
                    var mainWindowRect = mainWindow.Properties.BoundingRectangle.Value;

                    // Get all the Panes with Name: "TreeViewXv3" 
                    List<AutomationElement> treeViewPaneList = mainWindow.FindAllDescendants(
                         cf => cf.ByControlType(ControlType.Pane)
                        .And(cf.ByClassName("TreeViewXv3"))).ToList();

                    AutomationElement treeViewPane = null;

                    if ((connectedMonitors.Count >= 1) && (treeViewPaneList.Count >= 1))
                    {
                        // Loop over Tree View Panes
                        foreach (AutomationElement pane in treeViewPaneList)
                        {
                            // Get the bounding rectangle of the Tree View Pane
                            Rectangle treeViewPaneRect = pane.Properties.BoundingRectangle.Value;

                            // Loop over Monitors
                            foreach (var monitor in connectedMonitors)
                            {
                                Rectangle monitorRect = monitor.Bounds;

                                if (monitorRect.Contains(treeViewPaneRect))
                                {
                                    treeViewPane = pane;
                                    break;
                                }
                            }
                            if (treeViewPane != null) { break; }
                        }
                    }
                    #endregion


                    // Get the Project Browser, Tree View Pane Bounding Rectangle Property 
                    Rectangle projBoundRect = treeViewPane.Properties.BoundingRectangle.Value;

                    // Top and Left Pane Border Padding to Factor in (Need to relocate these...)
                    int paneOffset_Top = 22;
                    int paneOffset_Left = 22;
                    int paneOffset_Right = 30;
                    int paneOffset_Bottom = 72;

                    // Top/Left Start Point of Project Browser Pane
                    int projBrowser_X = projBoundRect.X + paneOffset_Left;
                    int projBrowser_Y = projBoundRect.Y + paneOffset_Top;

                    // Width and Height of Project Browser
                    int projBrowser_Width = projBoundRect.Width - (paneOffset_Left + paneOffset_Right);
                    int projBrowser_Height = projBoundRect.Height - (paneOffset_Top + paneOffset_Bottom);

                    // The coordinates of the row (adjust as needed)
                    int startX = projBoundRect.X;
                    int startY = projBoundRect.Y;
                    int endX = startX + projBrowser_Width;
                    int endY = startY + projBrowser_Height;


                    // Save File Path of the Image
                    string filePath = "";

                    // Added (3px) Padding to Snip to Remove Outside Border
                    using (Bitmap bmp = new Bitmap((projBoundRect.Width - 6), (projBoundRect.Height - 6)))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            // Capture the screen snip
                            g.CopyFromScreen(startX + 3, startY + 3, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                            // File path info for saving
                            string username = Environment.UserName;
                            string saveDir = $@"C:\Users\{username}\Downloads\";
                            string saveName = "UIAutomation_";
                            int saveNumber = 1;
                            int maxLoopNumber = 20;

                            // Check if directory exists, add suffix, and save the image
                            if (!Directory.Exists(saveDir))
                            {
                                MessageBox.Show("Save directory does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }

                            for (int i = 1; i <= maxLoopNumber; i++)
                            {
                                saveNumber = i;
                                filePath = Path.Combine(saveDir, $"{saveName}{saveNumber}.png");

                                if (!File.Exists(filePath))
                                {
                                    try
                                    {
                                        bmp.Save(filePath, ImageFormat.Png);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }

                                    break;
                                }
                            }
                            g.Dispose();
                            bmp.Dispose();

                            // Load the captured image and set it to SnippedImage property
                            SnippedImage = new BitmapImage(new Uri(filePath));
                        }
                    }

                    // Call Image Processing Utility Method //
                    LineDetection lineDetection = new LineDetection();
                    lineDetection.DetectLines(filePath);


                    #region OLD CODE...  NEED TO DELETE
                    //// Load the image from file
                    //Mat image = Cv2.ImRead(filePath, ImreadModes.Grayscale);

                    //// Convert the imag e to grayscale
                    //Mat grayImage = new Mat();
                    //Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);

                    //// Apply thresholding to create a binary image
                    //Mat binaryImage1 = new Mat();
                    //Cv2.Threshold(grayImage, binaryImage1, 220, 255, ThresholdTypes.Binary);

                    //// Apply thresholding to create a binary image
                    //Mat binaryImage2 = new Mat();
                    //Cv2.Threshold(grayImage, binaryImage2, 222, 255, ThresholdTypes.Binary);

                    //// Apply thresholding to create a binary image
                    //Mat binaryImage3 = new Mat();
                    //Cv2.Threshold(grayImage, binaryImage3, 228, 255, ThresholdTypes.Binary);

                    //// Apply thresholding to create a binary image
                    //Mat binaryImage4 = new Mat();
                    //Cv2.Threshold(grayImage, binaryImage4, 230, 255, ThresholdTypes.Binary);

                    //// Display the original image and the binary image
                    //Cv2.ImShow("Original Image", image);
                    //Cv2.ImShow("(220) Binary Image", binaryImage1);
                    //Cv2.ImShow("(222) Binary Image", binaryImage2);
                    //Cv2.ImShow("(228) Binary Image", binaryImage3);
                    //Cv2.ImShow("(230) Binary Image", binaryImage4);

                    //// Wait for a key press and then close the windows
                    //Cv2.WaitKey(0);
                    //Cv2.DestroyAllWindows();


                    //int rowLength = 75; // Length of the row to read

                    //Rectangle rect = new Rectangle(
                    //    startX, // Use the correct X-coordinate here
                    //    (startY + 29), // Use the correct Y-coordinate here
                    //    rowLength,
                    //    20);

                    //// Capture the screen image
                    //using (Bitmap screenCapture2 = new Bitmap(rect.Width, rect.Height))
                    //{
                    //    using (Graphics g = Graphics.FromImage(screenCapture2))
                    //    {
                    //        g.CopyFromScreen(rect.Left, rect.Top, 0, 0, screenCapture2.Size);
                    //    }

                    //    // Read pixel values along the row
                    //    Color[] pixelRow = new Color[rowLength];
                    //    for (int x = 0; x < rowLength; x++)
                    //    {
                    //        pixelRow[x] = screenCapture2.GetPixel(x, 0);
                    //    }

                    //    // After the loop, concatenate the pixel values into a single string and add it to the Sources collection
                    //    string rowString = string.Join(" ", pixelRow.Select(p => $"({p.R},{p.G},{p.B})"));
                    //    Sources.Add(rowString);
                    //}
                    #endregion


                    Thread.Sleep(5000);
                    app.Close();
                }
            }
        }

        public void GetToolBarButtonInfo(Window appWindow)
        {
            if (appWindow == null)
            {
                #region Top ToolBar Button Dimensions
                int marginWidth = 15;
                int newWidth = 56;
                int openWidth = 62;
                int closeWidth = 62;
                int saveWidth = 60;
                int printWidth = 55;
                int helpWidth = 112;
                #endregion

                // Find the "Pane" Element based on its Automation ID
                AutomationElement paneEle = appWindow.FindFirstDescendant(
                    cf => cf.ByControlType(ControlType.Pane)
                        .And(cf.ByAutomationId("59424")));

                // Get the Pane Bounding Rectangle Property 
                Rectangle boundingRectangle = paneEle.Properties.BoundingRectangle.Value;

                //Get Individual Coordinates of the Rectangle
                int start_X = boundingRectangle.Left;
                int start_Y = boundingRectangle.Top;
                int end_X = boundingRectangle.Right;
                int end_Y = boundingRectangle.Bottom;

                // Pane Width and Height
                int paneWidth = (end_X - start_X);
                int paneHeight = (end_Y - start_Y);

                // Center of (X,Y) Axis 
                int xAxisCenter = (start_X + (paneWidth / 2));
                int yAxisCenter = (start_Y + (paneHeight / 2));

                // ToolBar Button Center/Click Points of X-Axis
                int newCenterX = (marginWidth + (newWidth / 2));
                int openCenterX = (newCenterX + openWidth);
                int closeCenterX = (openCenterX + closeWidth);
                int saveCenterX = (closeCenterX + saveWidth);
                int printCenterX = (saveCenterX + printWidth);
                int helpCenterX = (printCenterX + helpWidth);


                // ToolBar Button Center/Click Points
                Point NewTbButton_CenterPoint = new Point(newCenterX, yAxisCenter);
                Point OpenTbButton_CenterPoint = new Point(openCenterX, yAxisCenter);
                Point CloseTbButton_CenterPoint = new Point(closeCenterX, yAxisCenter);
                Point SaveTbButton_CenterPoint = new Point(saveCenterX, yAxisCenter);
                Point PrintTbButton_CenterPoint = new Point(printCenterX, yAxisCenter);
                Point HelpTbButton_CenterPoint = new Point(helpCenterX, yAxisCenter);


                // Click "New" Project Button
                //MoveMouseToClick(newCenterX, yAxisCenter);

                //Mouse.Click(MouseButton.Left);
                Thread.Sleep(1000);

            }
        }


        public ObservableCollection<string> Sources { get; set; }


        private ImageSource _snippedImage;
        public ImageSource SnippedImage
        {
            get { return _snippedImage; }
            set
            {
                _snippedImage = value;
                OnPropertyChanged(nameof(SnippedImage));
            }
        }

        // Move the mouse pointer to the specified point
        public static void MoveMouseTo(int x, int y)
        {
            Mouse.MoveTo(x, y);

            //Thread.Sleep(500);
        }
        public static void MoveMouseToClick(int x, int y)
        {
            Mouse.MoveTo(x, y);
            Mouse.Click(MouseButton.Left);
        }


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

                    Sources.Add($"Dialog Closed...");
                }
            }
        }

        private void CollectButtons(AutomationElement element, List<Button> buttons)
        {
            if (element.ControlType == ControlType.Button)
            {
                buttons.Add(element.AsButton());
            }
            else if (element.ControlType == ControlType.Pane)
            {
                foreach (var childElement in element.FindAllDescendants(cf => cf.ByControlType(ControlType.Button)))
                {
                    buttons.Add(childElement.AsButton());
                }
            }

            foreach (var childElement in element.FindAllChildren())
            {
                CollectButtons(childElement, buttons);
            }
        }
    }
}
