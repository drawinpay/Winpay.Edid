using System.Globalization;
using System.Windows.Data;
using EdidEditor.Theme.Light.Helpers;

namespace EdidEditor.Theme.Light.Converters
{
    /// <summary>
    /// 数值缩放转换器
    /// </summary>
    public class NumberRateConverter : IValueConverter
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterUtils.ToNumber(value) * ConverterUtils.ToNumber(parameter);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConverterUtils.ToNumber(value) / ConverterUtils.ToNumber(parameter);
        }
    }
}
