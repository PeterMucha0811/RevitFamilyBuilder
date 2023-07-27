using System;
using System.Globalization;
using System.Windows.Data;

namespace RevitFamilyBuilder.ViewModels.Converters
{
    public class SliderPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double sliderValue = (double)value;
            double actualHeight = System.Convert.ToDouble(parameter, culture);

            double offset = sliderValue / actualHeight;
            return offset;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
