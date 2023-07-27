using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace RevitFamilyBuilder.Helpers
{
    public static class GeometryHelper
    {



        public static List<Rectangle> CreateDefaultRectangles()
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            List<MonitorInfoProvider.MonitorInfo> monitorInfoList = MonitorInfoProvider.GetConnectedMonitors();
            foreach (var monitorInfo in monitorInfoList)
            {
                Rectangle rect = new Rectangle();
                rect.Width = monitorInfo.Bounds.Width;
                rect.Height = monitorInfo.Bounds.Height;
                rect.Fill = Brushes.White;
                rect.Opacity = 0.5;
                Canvas.SetLeft(rect, monitorInfo.Bounds.Left);
                Canvas.SetTop(rect, monitorInfo.Bounds.Top);
                rectangles.Add(rect);
            }

            return rectangles;
        }


        public static Rectangle CreateRectangle(double width, double height, double left, double top, Brush fill, double opacity)
        {
            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = fill;
            rect.Opacity = opacity;
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);
            return rect;
        }



    }
}
