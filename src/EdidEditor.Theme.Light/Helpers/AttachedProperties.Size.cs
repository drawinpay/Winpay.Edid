using System.Windows;

namespace EdidEditor.Theme.Light.Helpers
{
    public partial class AttachedProperties
    {
        #region 用于描述：部件大小或厚度

        /// <summary>
        /// 位图大小
        /// </summary>
        public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.RegisterAttached(
            "ImageSize", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));

        /// <summary />
        public static void SetImageSize(DependencyObject element, double value)
        {
            element.SetValue(ImageSizeProperty, value);
        }
        
        /// <summary />
        public static double GetImageSize(DependencyObject element)
        {
            return (double)element.GetValue(ImageSizeProperty);
        }

        /// <summary>
        /// 位图高度
        /// </summary>
        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.RegisterAttached(
            "ImageHeight", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static void SetImageHeight(DependencyObject element, double value)
        {
            element.SetValue(ImageHeightProperty, value);
        }
        
        /// <summary />
        public static double GetImageHeight(DependencyObject element)
        {
            return (double)element.GetValue(ImageHeightProperty);
        }

        /// <summary>
        /// 位图宽度
        /// </summary>
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.RegisterAttached(
            "ImageWidth", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static void SetImageWidth(DependencyObject element, double value)
        {
            element.SetValue(ImageWidthProperty, value);
        }
        
        /// <summary />
        public static double GetImageWidth(DependencyObject element)
        {
            return (double)element.GetValue(ImageWidthProperty);
        }

        /// <summary>
        /// 矢量图大小
        /// </summary>
        public static readonly DependencyProperty GeometrySizeProperty =
            DependencyProperty.RegisterAttached("GeometrySize", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetGeometrySize(DependencyObject obj)
        {
            return (double)obj.GetValue(GeometrySizeProperty);
        }
        
        /// <summary />
        public static void SetGeometrySize(DependencyObject obj, double value)
        {
            obj.SetValue(GeometrySizeProperty, value);
        }

        /// <summary>
        /// 滑块/选中框/小部件大小
        /// </summary>
        public static readonly DependencyProperty ThumbSizeProperty =
            DependencyProperty.RegisterAttached("ThumbSize", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetThumbSize(DependencyObject obj)
        {
            return (double)obj.GetValue(ThumbSizeProperty);
        }
        
        /// <summary />
        public static void SetThumbSize(DependencyObject obj, double value)
        {
            obj.SetValue(ThumbSizeProperty, value);
        }

        /// <summary>
        /// 长条厚度（仅用于滚动条、滑动条、分隔线）
        /// </summary>
        public static readonly DependencyProperty BarThicknessProperty =
            DependencyProperty.RegisterAttached("BarThickness", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetBarThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(BarThicknessProperty);
        }
        
        /// <summary />
        public static void SetBarThickness(DependencyObject obj, double value)
        {
            obj.SetValue(BarThicknessProperty, value);
        }

        /// <summary>
        /// 弹出框宽度（仅用于下拉框）
        /// </summary>
        public static readonly DependencyProperty PopupWidthProperty =
            DependencyProperty.RegisterAttached("PopupWidth", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));

        /// <summary />
        public static double GetPopupWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(PopupWidthProperty);
        }

        /// <summary />
        public static void SetPopupWidth(DependencyObject obj, double value)
        {
            obj.SetValue(PopupWidthProperty, value);
        }

        /// <summary>
        /// 弹出框高度（仅用于下拉框）
        /// </summary>
        public static readonly DependencyProperty PopupHeightProperty =
            DependencyProperty.RegisterAttached("PopupHeight", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));

        /// <summary />
        public static double GetPopupHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(PopupHeightProperty);
        }

        /// <summary />
        public static void SetPopupHeight(DependencyObject obj, double value)
        {
            obj.SetValue(PopupHeightProperty, value);
        }

        /// <summary>
        /// 装饰线高度（仅用于列表框）
        /// </summary>
        public static readonly DependencyProperty DecorativeLineHeightProperty =
            DependencyProperty.RegisterAttached("DecorativeLineHeight", typeof(double), typeof(AttachedProperties), new PropertyMetadata(double.NaN));
        
        /// <summary />
        public static double GetDecorativeLineHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(DecorativeLineHeightProperty);
        }
        
        /// <summary />
        public static void SetDecorativeLineHeight(DependencyObject obj, double value)
        {
            obj.SetValue(DecorativeLineHeightProperty, value);
        }

        /// <summary>
        /// 装饰线宽度（仅用于列表框）
        /// </summary>
        public static readonly DependencyProperty DecorativeLineWidthProperty =
            DependencyProperty.RegisterAttached("DecorativeLineWidth", typeof(double), typeof(AttachedProperties), new PropertyMetadata(double.NaN));
        
        /// <summary />
        public static double GetDecorativeLineWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DecorativeLineWidthProperty);
        }
        
        /// <summary />
        public static void SetDecorativeLineWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DecorativeLineWidthProperty, value);
        }

        /// <summary>
        /// 装饰线宽度（仅用于列表框）
        /// </summary>
        public static readonly DependencyProperty TextWidthProperty =
            DependencyProperty.RegisterAttached("TextWidth", typeof(double), typeof(AttachedProperties), new PropertyMetadata(double.NaN));

        /// <summary />
        public static double GetTextWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(TextWidthProperty);
        }

        /// <summary />
        public static void SetTextWidth(DependencyObject obj, double value)
        {
            obj.SetValue(TextWidthProperty, value);
        }

        #endregion
    }
}
