using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RevitFamilyBuilder.ViewModels.Converters
{
    public class ZoomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double zoomLevel = (double)value;
            return new ScaleTransform(zoomLevel, zoomLevel);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
