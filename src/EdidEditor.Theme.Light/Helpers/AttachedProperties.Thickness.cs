using System.Windows;

namespace EdidEditor.Theme.Light.Helpers
{
    public partial class AttachedProperties
    {
        #region 用于描述：外边距（Margin）

        /// <summary>
        /// 位图外边距
        /// </summary>
        public static readonly DependencyProperty ImageMarginProperty = DependencyProperty.RegisterAttached(
            "ImageMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));

        /// <summary />
        public static void SetImageMargin(DependencyObject element, Thickness value)
        {
            element.SetValue(ImageMarginProperty, value);
        }
        
        /// <summary />
        public static Thickness GetImageMargin(DependencyObject element)
        {
            return (Thickness)element.GetValue(ImageMarginProperty);
        }

        /// <summary>
        /// 矢量图外边距
        /// </summary>
        public static readonly DependencyProperty GeometryMarginProperty =
            DependencyProperty.RegisterAttached("GeometryMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));

        /// <summary />
        public static Thickness GetGeometryMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(GeometryMarginProperty);
        }
        
        /// <summary />
        public static void SetGeometryMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(GeometryMarginProperty, value);
        }

        /// <summary>
        /// 矢量图2外边距
        /// </summary>
        public static readonly DependencyProperty Geometry2MarginProperty =
            DependencyProperty.RegisterAttached("Geometry2Margin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetGeometry2Margin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(Geometry2MarginProperty);
        }
        
        /// <summary />
        public static void SetGeometry2Margin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(Geometry2MarginProperty, value);
        }

        /// <summary>
        /// 文字外边距
        /// </summary>
        public static readonly DependencyProperty TextMarginProperty = DependencyProperty.RegisterAttached(
            "TextMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static void SetTextMargin(DependencyObject element, Thickness value)
        {
            element.SetValue(TextMarginProperty, value);
        }
        
        /// <summary />
        public static Thickness GetTextMargin(DependencyObject element)
        {
            return (Thickness)element.GetValue(TextMarginProperty);
        }

        /// <summary>
        /// 提示文本外边距
        /// </summary>
        public static readonly DependencyProperty HintTextMarginProperty =
            DependencyProperty.RegisterAttached("HintTextMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetHintTextMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HintTextMarginProperty);
        }
        
        /// <summary />
        public static void SetHintTextMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HintTextMarginProperty, value);
        }

        /// <summary>
        /// 提示文本2外边距
        /// </summary>
        public static readonly DependencyProperty HintText2MarginProperty =
            DependencyProperty.RegisterAttached("HintText2Margin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetHintText2Margin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HintText2MarginProperty);
        }
        
        /// <summary />
        public static void SetHintText2Margin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HintText2MarginProperty, value);
        }

        /// <summary>
        /// 提示文本3外边距
        /// </summary>
        public static readonly DependencyProperty HintText3MarginProperty =
            DependencyProperty.RegisterAttached("HintText3Margin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetHintText3Margin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HintText3MarginProperty);
        }
        
        /// <summary />
        public static void SetHintText3Margin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HintText3MarginProperty, value);
        }

        /// <summary>
        /// 滑块/选中框/小部件外边距
        /// </summary>
        public static readonly DependencyProperty ThumbMarginProperty =
            DependencyProperty.RegisterAttached("ThumbMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetThumbMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ThumbMarginProperty);
        }
        
        /// <summary />
        public static void SetThumbMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ThumbMarginProperty, value);
        }

        /// <summary>
        /// 装饰线外边距
        /// </summary>
        public static readonly DependencyProperty DecorativeLineMarginProperty =
            DependencyProperty.RegisterAttached("DecorativeLineMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetDecorativeLineMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(DecorativeLineMarginProperty);
        }
        
        /// <summary />
        public static void SetDecorativeLineMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(DecorativeLineMarginProperty, value);
        }

        /// <summary>
        /// 分隔线外边距
        /// </summary>
        public static readonly DependencyProperty SeparatorMarginProperty =
            DependencyProperty.RegisterAttached("SeparatorMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetSeparatorMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(SeparatorMarginProperty);
        }
        
        /// <summary />
        public static void SetSeparatorMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(SeparatorMarginProperty, value);
        }

        /// <summary>
        /// 竖向滚动条外边距
        /// </summary>
        public static readonly DependencyProperty VerticalScrollBarMarginProperty =
            DependencyProperty.RegisterAttached("VerticalScrollBarMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));
        
        /// <summary />
        public static Thickness GetVerticalScrollBarMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(VerticalScrollBarMarginProperty);
        }
        
        /// <summary />
        public static void SetVerticalScrollBarMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(VerticalScrollBarMarginProperty, value);
        }

        /// <summary>
        /// 横向滚动条外边距
        /// </summary>
        public static readonly DependencyProperty HorizontalScrollBarMarginProperty =
            DependencyProperty.RegisterAttached("HorizontalScrollBarMargin", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));

        /// <summary />
        public static Thickness GetHorizontalScrollBarMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(HorizontalScrollBarMarginProperty);
        }
        
        /// <summary />
        public static void SetHorizontalScrollBarMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(HorizontalScrollBarMarginProperty, value);
        }

        #endregion

        #region 用于描述：内边距（Padding）

        /// <summary>
        /// 滑块/选中框/小部件内边距
        /// </summary>
        public static readonly DependencyProperty ThumbPaddingProperty =
            DependencyProperty.RegisterAttached("ThumbPadding", typeof(Thickness), typeof(AttachedProperties), new PropertyMetadata(default(Thickness)));

        /// <summary />
        public static Thickness GetThumbPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ThumbPaddingProperty);
        }
        
        /// <summary />
        public static void SetThumbPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ThumbPaddingProperty, value);
        }

        #endregion

    }
}
