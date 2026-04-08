using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using EdidEditor.Theme.Light.Helpers;

namespace EdidEditor.Theme.Light.Converters
{
    internal class SolidColorBrushLerpConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] is SolidColorBrush brush1 && values[1] is SolidColorBrush brush2)
            {
                double amount = ConverterUtils.ToNumber(values[2]);
                Color color = new Color();
                color.R = ToByte(Lerp(brush1.Color.R, brush2.Color.R, amount));
                color.G = ToByte(Lerp(brush1.Color.G, brush2.Color.G, amount));
                color.B = ToByte(Lerp(brush1.Color.B, brush2.Color.B, amount));
                color.A = ToByte(Lerp(brush1.Color.A, brush2.Color.A, amount));
                Brush brush = new SolidColorBrush(color);
                brush.Opacity = Lerp(brush1.Opacity, brush2.Opacity, amount);
                return brush;
            }
            throw new NotSupportedException();
        }

        private static double Lerp(double a, double b, double amount)
        {
            double diff = b - a;
            double delta = diff * amount;
            return a + delta;
        }

        private static byte ToByte(double number)
        {
            return (byte)number;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
