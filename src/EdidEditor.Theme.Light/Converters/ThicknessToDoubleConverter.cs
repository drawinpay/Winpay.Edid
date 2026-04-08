using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EdidEditor.Theme.Light.Converters
{
    internal class ThicknessToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Thickness thickness)
            {
                return thickness.Left;
            }
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
