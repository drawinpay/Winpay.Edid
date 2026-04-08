using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using EdidEditor.Theme.Light.Converters;

namespace EdidEditor.Theme.Light.Helpers
{
    /// <summary>
    /// 圆角相关附加属性
    /// </summary>
    public partial class AttachedProperties
    {
        #region 为控件附加圆角属性

        /// <summary>
        /// 获取圆角
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        /// <summary>
        /// 设置圆角
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// 圆角
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(AttachedProperties),
                new PropertyMetadata(default(CornerRadius)));

        #endregion

        #region 为控件提供圆角裁剪

        /// <summary>
        /// 圆角裁剪
        /// </summary>
        public static readonly DependencyProperty ClipCornerRadiusProperty = DependencyProperty.RegisterAttached(
            "ClipCornerRadius", typeof(double), typeof(AttachedProperties),
            new PropertyMetadata(0.0, ClipCornerRadiusPropertyChangedCallback));

        /// <summary>
        /// 设置圆角裁剪
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetClipCornerRadius(UIElement element, double value)
        {
            element.SetValue(ClipCornerRadiusProperty, value);
        }

        /// <summary>
        /// 获取圆角裁剪
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static double GetClipCornerRadius(UIElement element)
        {
            return (double)element.GetValue(ClipCornerRadiusProperty);
        }

        private static void ClipCornerRadiusPropertyChangedCallback(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement source = (UIElement)d;
            double newValue = (double)e.NewValue;

            RectangleGeometry rectangle = source.Clip as RectangleGeometry;
            if (source.Clip != null && rectangle == null)
            {
                throw new InvalidOperationException(
                    $"{typeof(AttachedProperties).FullName}.{ClipCornerRadiusProperty.Name} " +
                    $"属性需要使用到 {source.GetType().FullName}.{UIElement.ClipProperty.Name} " +
                    "属性，请不要在设置此属性的同时设置它。");
            }
            rectangle = rectangle ?? new RectangleGeometry();
            rectangle.RadiusX = newValue;
            rectangle.RadiusY = newValue;
            source.Clip = rectangle;

            MultiBinding multiBinding = BindingOperations.GetMultiBinding(rectangle, RectangleGeometry.RectProperty);
            if (multiBinding == null)
            {
                multiBinding = new MultiBinding
                {
                    Converter = new SizeToRectConverter(),
                };
                multiBinding.Bindings.Add(new Binding(FrameworkElement.ActualWidthProperty.Name)
                {
                    Source = source,
                    Mode = BindingMode.OneWay,
                });
                multiBinding.Bindings.Add(new Binding(FrameworkElement.ActualHeightProperty.Name)
                {
                    Source = source,
                    Mode = BindingMode.OneWay,
                });
                BindingOperations.SetBinding(rectangle, RectangleGeometry.RectProperty, multiBinding);
            }
        }

        #endregion
    }
}
