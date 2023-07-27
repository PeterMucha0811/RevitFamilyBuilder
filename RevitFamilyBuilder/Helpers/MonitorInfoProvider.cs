using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RevitFamilyBuilder.Helpers
{
    public class MonitorInfoProvider
    {
        public class MonitorInfo
        {
            public int Index { get; set; }
            public int BitsPerPixel { get; set; }
            public string DeviceName { get; set; }
            public bool IsPrimaryMonitor { get; set; }
            public Rectangle Bounds { get; set; }
            public Rectangle WorkingArea { get; set; }
        }

        public static List<MonitorInfo> GetConnectedMonitors()
        {
            List<MonitorInfo> monitors = new List<MonitorInfo>();
            foreach (var screen in Screen.AllScreens)
            {
                MonitorInfo monitor = new MonitorInfo
                {
                    Index = screen.DeviceName.GetHashCode(),
                    BitsPerPixel = screen.BitsPerPixel,
                    DeviceName = screen.DeviceName,
                    IsPrimaryMonitor = screen.Primary,   
                    Bounds = new Rectangle(screen.Bounds.Left, screen.Bounds.Top, screen.Bounds.Width, screen.Bounds.Height),
                    WorkingArea = new Rectangle(screen.WorkingArea.Left, screen.WorkingArea.Top, screen.WorkingArea.Width, screen.WorkingArea.Height)
                };
                monitors.Add(monitor);
            }
            return monitors;
        }
    }
}




