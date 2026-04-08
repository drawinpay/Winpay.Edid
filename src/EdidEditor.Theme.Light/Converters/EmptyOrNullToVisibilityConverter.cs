using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EdidEditor.Theme.Light.Converters
{
    /// <summary>
    /// 空到可见性转换器
    /// </summary>
    public class EmptyOrNullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 空或Null时的可见性
        /// </summary>
        public Visibility EmptyOrNullTo { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// 不为空或Null时的可见性
        /// </summary>
        public Visibility NotEmptyOrNullTo { get; set; } = Visibility.Visible;

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null ||
                value is string str && string.IsNullOrEmpty(str))
            {
                return EmptyOrNullTo;
            }

            return NotEmptyOrNullTo;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
