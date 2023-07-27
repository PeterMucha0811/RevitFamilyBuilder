using System.Runtime.InteropServices;

namespace UIAutomation
{
    public class MouseUtilities
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void MoveMouseToClick(int x, int y)
        {
            // Move the mouse instantly to the specified location
            SetCursorPos(x, y); 

            // Perform a left mouse click
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0); 
        }
    }
}
