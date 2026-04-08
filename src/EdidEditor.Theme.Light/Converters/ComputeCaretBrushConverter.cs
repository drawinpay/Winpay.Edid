using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace EdidEditor.Theme.Light.Converters
{
    /// <summary>
    /// 光标画刷转换器
    /// </summary>
    public class ComputeCaretBrushConverter : IMultiValueConverter
    {
        /// <summary>
        /// 光标画刷转换器
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush normalBrush = values[0] as Brush; // 注意确保所有Brush类型是System.Windows.Media.Brush而不是System.Drawing.Brush，两者是互不兼容类型，WPF常用的是前者
            Brush warningBrush = values[1] as Brush;
            Brush errorBrush = values[2] as Brush;
            if(values[3] is bool isWarning && values[4] is bool isError)
            {
                if(isError)
                {
                    return errorBrush;
                }
                if(isWarning)
                {
                    return warningBrush;
                }
                return normalBrush;
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// 光标画刷转换器（反转）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
