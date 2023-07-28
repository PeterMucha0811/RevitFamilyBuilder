using Window = FlaUI.Core.AutomationElements.Window;
using Point = System.Drawing.Point;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using System.Drawing;


namespace UIAutomation.Utilities_FlaUI.EG_PageObjects
{
    public class ToolBarButtons_Pane
    {
        #region Top ToolBar - Button Widths
        private const int width_Margin = 15;
        private const int width_New = 56;
        private const int width_Open = 62;
        private const int width_Close = 62;
        private const int width_Save = 60;
        private const int width_Print = 55;
        private const int width_Help = 112;
        #endregion


        #region Properties
        private Window _appWindow;

        // Toolbar Pane Button Click Points
        private Point _btnCenter_New;
        private Point _btnCenter_Open;
        private Point _btnCenter_Close;
        private Point _btnCenter_Save;
        private Point _btnCenter_Print;
        private Point _btnCenter_Help;
        #endregion


        public ToolBarButtons_Pane(Window appWindow)
        {
            if (appWindow != null)
            {
                _appWindow = appWindow;
                InitializeButtonPoints(appWindow);
            }
        }


        #region Title Bar - Button Click Actions
        public void ClickBtn_New() { MouseMoveClick(_btnCenter_New); }
        public void ClickBtn_Open() { MouseMoveClick(_btnCenter_Open); }
        public void ClickBtn_Close() { MouseMoveClick(_btnCenter_Close); }
        public void ClickBtn_Save() { MouseMoveClick(_btnCenter_Save); }
        public void ClickBtn_Print() { MouseMoveClick(_btnCenter_Print); }
        public void ClickBtn_Help() { MouseMoveClick(_btnCenter_Help); }
        #endregion


        #region Helper Methods

        // Get Center Points of all the Title Bar Buttons
        private void InitializeButtonPoints(Window appWindow)
        {
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
            int newCenterX = (width_Margin + (width_New / 2));
            int openCenterX = (newCenterX + width_Open);
            int closeCenterX = (openCenterX + width_Close);
            int saveCenterX = (closeCenterX + width_Save);
            int printCenterX = (saveCenterX + width_Print);
            int helpCenterX = (printCenterX + width_Help);


            // ToolBar Button Center/Click Points
            _btnCenter_New = new Point(newCenterX, yAxisCenter);
            _btnCenter_Open = new Point(openCenterX, yAxisCenter);
            _btnCenter_Close = new Point(closeCenterX, yAxisCenter);
            _btnCenter_Save = new Point(saveCenterX, yAxisCenter);
            _btnCenter_Print = new Point(printCenterX, yAxisCenter);
            _btnCenter_Help = new Point(helpCenterX, yAxisCenter);
        }


        // Mouse Moveto Point & Click
        private static void MouseMoveClick(Point p)
        {
            Mouse.MoveTo(p);
            Mouse.Click(MouseButton.Left);
        }

        #endregion
    }
}
