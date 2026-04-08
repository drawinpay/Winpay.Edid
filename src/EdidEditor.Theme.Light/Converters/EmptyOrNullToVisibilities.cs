using System.Windows;
using System.Windows.Data;

namespace EdidEditor.Theme.Light.Converters
{
    /// <summary>
    /// 空到可见性转换器实例
    /// </summary>
    public static class EmptyOrNullToVisibilities
    {
        /// <summary>
        /// 为空时可见，否则折叠
        /// </summary>
        public static IValueConverter VisibleWhenEmptyOrNull { get; set; } = new EmptyOrNullToVisibilityConverter()
        {
            EmptyOrNullTo = Visibility.Visible,
            NotEmptyOrNullTo = Visibility.Collapsed
        };

        /// <summary>
        /// 为空时折叠，否则可见
        /// </summary>
        public static IValueConverter CollapsedWhenEmptyOrNull { get; set; } = new EmptyOrNullToVisibilityConverter()
        {
            EmptyOrNullTo = Visibility.Collapsed,
            NotEmptyOrNullTo = Visibility.Visible
        };
    }
}
