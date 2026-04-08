using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EdidEditor.Theme.Light.Converters
{
    /// <summary>
    /// 宽高至矩形（Rect）转换器
    /// </summary>
    internal class SizeToRectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double width = (double)values[0];
            double height = (double)values[1];
            return width > 0.0 && height > 0.0 ? new Rect(0.0, 0.0, width, height) : Rect.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
