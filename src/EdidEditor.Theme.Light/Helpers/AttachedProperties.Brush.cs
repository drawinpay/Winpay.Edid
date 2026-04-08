using System.Windows;
using System.Windows.Media;

namespace EdidEditor.Theme.Light.Helpers
{
    /// <summary>
    /// 颜色相关附加属性
    /// </summary>
    public partial class AttachedProperties
    {
        #region 用于描述：控件文本前景色

        /// <summary>
        /// 普通前景色
        /// </summary>
        public static readonly DependencyProperty ForegroundNormalProperty = DependencyProperty.RegisterAttached(
            "ForegroundNormal", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 设置普通前景色
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetForegroundNormal(DependencyObject element, Brush value)
        {
            element.SetValue(ForegroundNormalProperty, value);
        }

        /// <summary>
        /// 获取普通前景色
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Brush GetForegroundNormal(DependencyObject element)
        {
            return (Brush)element.GetValue(ForegroundNormalProperty);
        }

        /// <summary>
        /// 鼠标、手势悬停前景色
        /// </summary>
        public static readonly DependencyProperty ForegroundHoverProperty = DependencyProperty.RegisterAttached(
            "ForegroundHover", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 设置鼠标、手势悬停前景色
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetForegroundHover(DependencyObject element, Brush value)
        {
            element.SetValue(ForegroundHoverProperty, value);
        }

        /// <summary>
        /// 获取鼠标、手势悬停前景色
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Brush GetForegroundHover(DependencyObject element)
        {
            return (Brush)element.GetValue(ForegroundHoverProperty);
        }

        /// <summary>
        /// 鼠标、手势按压前景色 
        /// </summary>
        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.RegisterAttached(
            "ForegroundPressed", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 设置鼠标、手势按压前景色
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetForegroundPressed(DependencyObject element, Brush value)
        {
            element.SetValue(ForegroundPressedProperty, value);
        }

        /// <summary>
        /// 获取鼠标、手势按压前景色
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Brush GetForegroundPressed(DependencyObject element)
        {
            return (Brush)element.GetValue(ForegroundPressedProperty);
        }

        /// <summary>
        /// 选中状态前景色
        /// </summary>
        public static readonly DependencyProperty ForegroundCheckedProperty = DependencyProperty.RegisterAttached(
            "ForegroundChecked", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// 设置选中状态前景色
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetForegroundChecked(DependencyObject element, Brush value)
        {
            element.SetValue(ForegroundCheckedProperty, value);
        }

        /// <summary>
        /// 获取选中状态前景色
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Brush GetForegroundChecked(DependencyObject element)
        {
            return (Brush)element.GetValue(ForegroundCheckedProperty);
        }

        #endregion

        #region 用于描述：提示文本前景色


        /// <summary>
        /// 提示文本颜色
        /// </summary>
        public static readonly DependencyProperty HintTextBrushProperty =
            DependencyProperty.RegisterAttached("HintTextBrush", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));

        /// <summary />
        public static Brush GetHintTextBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HintTextBrushProperty);
        }

        /// <summary />
        public static void SetHintTextBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HintTextBrushProperty, value);
        }

        /// <summary>
        /// 提示文本2颜色
        /// </summary>
        public static readonly DependencyProperty HintText2BrushProperty =
            DependencyProperty.RegisterAttached("HintText2Brush", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));

        /// <summary />
        public static Brush GetHintText2Brush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HintText2BrushProperty);
        }

        /// <summary />
        public static void SetHintText2Brush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HintText2BrushProperty, value);
        }

        /// <summary>
        /// 警告时提示文本2颜色（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty HintText2BrushWarningProperty =
            DependencyProperty.RegisterAttached("HintText2BrushWarning", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));

        /// <summary />
        public static Brush GetHintText2BrushError(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HintText2BrushErrorProperty);
        }

        /// <summary />
        public static void SetHintText2BrushError(DependencyObject obj, Brush value)
        {
            obj.SetValue(HintText2BrushErrorProperty, value);
        }

        /// <summary>
        /// 错误时提示文本2颜色（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty HintText2BrushErrorProperty =
            DependencyProperty.RegisterAttached("HintText2BrushError", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));

        /// <summary />
        public static Brush GetHintText2BrushWarning(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HintText2BrushWarningProperty);
        }

        /// <summary />
        public static void SetHintText2BrushWarning(DependencyObject obj, Brush value)
        {
            obj.SetValue(HintText2BrushWarningProperty, value);
        }

        #endregion

        #region 用于描述：控件背景颜色

        /// <summary>
        /// 普通背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundNormalProperty = DependencyProperty.RegisterAttached(
            "BackgroundNormal", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Transparent));
        
        /// <summary />
        public static void SetBackgroundNormal(DependencyObject element, Brush value)
        {
            element.SetValue(BackgroundNormalProperty, value);
        }
        
        /// <summary />
        public static Brush GetBackgroundNormal(DependencyObject element)
        {
            return (Brush)element.GetValue(BackgroundNormalProperty);
        }

        /// <summary>
        /// 悬停时背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundHoverProperty = DependencyProperty.RegisterAttached(
            "BackgroundHover", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Transparent));
        
        /// <summary />
        public static void SetBackgroundHover(DependencyObject element, Brush value)
        {
            element.SetValue(BackgroundHoverProperty, value);
        }
        
        /// <summary />
        public static Brush GetBackgroundHover(DependencyObject element)
        {
            return (Brush)element.GetValue(BackgroundHoverProperty);
        }

        /// <summary>
        /// 按压时背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundPressedProperty = DependencyProperty.RegisterAttached(
            "BackgroundPressed", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Transparent));
        
        /// <summary />
        public static void SetBackgroundPressed(DependencyObject element, Brush value)
        {
            element.SetValue(BackgroundPressedProperty, value);
        }
        
        /// <summary />
        public static Brush GetBackgroundPressed(DependencyObject element)
        {
            return (Brush)element.GetValue(BackgroundPressedProperty);
        }

        /// <summary>
        /// 选中时背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundCheckedProperty = DependencyProperty.RegisterAttached(
            "BackgroundChecked", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Transparent));
        
        /// <summary />
        public static void SetBackgroundChecked(DependencyObject element, Brush value)
        {
            element.SetValue(BackgroundCheckedProperty, value);
        }
        
        /// <summary />
        public static Brush GetBackgroundChecked(DependencyObject element)
        {
            return (Brush)element.GetValue(BackgroundCheckedProperty);
        }

        /// <summary>
        /// 选中时悬停背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundCheckedHoverProperty =
            DependencyProperty.RegisterAttached("BackgroundCheckedHover", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetBackgroundCheckedHover(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundCheckedHoverProperty);
        }
        
        /// <summary />
        public static void SetBackgroundCheckedHover(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundCheckedHoverProperty, value);
        }

        /// <summary>
        /// 选中时按压背景色
        /// </summary>
        public static readonly DependencyProperty BackgroundCheckedPressedProperty =
            DependencyProperty.RegisterAttached("BackgroundCheckedPressed", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetBackgroundCheckedPressed(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundCheckedPressedProperty);
        }
        
        /// <summary />
        public static void SetBackgroundCheckedPressed(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundCheckedPressedProperty, value);
        }

        #endregion

        #region 用于描述：控件边框颜色

        /// <summary>
        /// 普通边框色 
        /// </summary>
        public static readonly DependencyProperty BorderBrushNormalProperty = DependencyProperty.RegisterAttached(
            "BorderBrushNormal", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));
        
        /// <summary />
        public static void SetBorderBrushNormal(DependencyObject element, Brush value)
        {
            element.SetValue(BorderBrushNormalProperty, value);
        }
        
        /// <summary />
        public static Brush GetBorderBrushNormal(DependencyObject element)
        {
            return (Brush)element.GetValue(BorderBrushNormalProperty);
        }

        /// <summary>
        /// 悬停时边框色 
        /// </summary>
        public static readonly DependencyProperty BorderBrushHoverProperty = DependencyProperty.RegisterAttached(
            "BorderBrushHover", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));
        
        /// <summary />
        public static void SetBorderBrushHover(DependencyObject element, Brush value)
        {
            element.SetValue(BorderBrushHoverProperty, value);
        }
        
        /// <summary />
        public static Brush GetBorderBrushHover(DependencyObject element)
        {
            return (Brush)element.GetValue(BorderBrushHoverProperty);
        }

        /// <summary>
        /// 按压时边框色 
        /// </summary>
        public static readonly DependencyProperty BorderBrushPressedProperty = DependencyProperty.RegisterAttached(
            "BorderBrushPressed", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));
        
        /// <summary />
        public static void SetBorderBrushPressed(DependencyObject element, Brush value)
        {
            element.SetValue(BorderBrushPressedProperty, value);
        }
        
        /// <summary />
        public static Brush GetBorderBrushPressed(DependencyObject element)
        {
            return (Brush)element.GetValue(BorderBrushPressedProperty);
        }

        /// <summary>
        /// 选中时边框色 
        /// </summary>
        public static readonly DependencyProperty BorderBrushCheckedProperty = DependencyProperty.RegisterAttached(
            "BorderBrushChecked", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(Brushes.Black));
        
        /// <summary />
        public static void SetBorderBrushChecked(DependencyObject element, Brush value)
        {
            element.SetValue(BorderBrushCheckedProperty, value);
        }
        
        /// <summary />
        public static Brush GetBorderBrushChecked(DependencyObject element)
        {
            return (Brush)element.GetValue(BorderBrushCheckedProperty);
        }

        /// <summary>
        /// 选中时悬停边框色
        /// </summary>
        public static readonly DependencyProperty BorderBrushCheckedHoverProperty =
            DependencyProperty.RegisterAttached("BorderBrushCheckedHover", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));

        /// <summary />
        public static Brush GetBorderBrushCheckedHover(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderBrushCheckedHoverProperty);
        }
        
        /// <summary />
        public static void SetBorderBrushCheckedHover(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderBrushCheckedHoverProperty, value);
        }

        /// <summary>
        /// 选中时按压边框色
        /// </summary>
        public static readonly DependencyProperty BorderBrushCheckedPressedProperty =
            DependencyProperty.RegisterAttached("BorderBrushCheckedPressed", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetBorderBrushCheckedPressed(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderBrushCheckedPressedProperty);
        }
        
        /// <summary />
        public static void SetBorderBrushCheckedPressed(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderBrushCheckedPressedProperty, value);
        }

        /// <summary>
        /// 警告状态边框色（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty BorderBrushWarningProperty =
            DependencyProperty.RegisterAttached("BorderBrushWarning", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetBorderBrushWarning(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderBrushWarningProperty);
        }
        
        /// <summary />
        public static void SetBorderBrushWarning(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderBrushWarningProperty, value);
        }

        /// <summary>
        /// 错误状态边框色（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty BorderBrushErrorProperty =
            DependencyProperty.RegisterAttached("BorderBrushError", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetBorderBrushError(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BorderBrushErrorProperty);
        }
        
        /// <summary />
        public static void SetBorderBrushError(DependencyObject obj, Brush value)
        {
            obj.SetValue(BorderBrushErrorProperty, value);
        }

        #endregion

        #region 用于描述：光标颜色

        /// <summary>
        /// 警告时光标颜色
        /// </summary>
        public static readonly DependencyProperty CaretBrushWarningProperty =
            DependencyProperty.RegisterAttached("CaretBrushWarning", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetCaretBrushWarning(DependencyObject obj)
        {
            return (Brush)obj.GetValue(CaretBrushWarningProperty);
        }
        
        /// <summary />
        public static void SetCaretBrushWarning(DependencyObject obj, Brush value)
        {
            obj.SetValue(CaretBrushWarningProperty, value);
        }

        /// <summary>
        /// 错误时光标颜色
        /// </summary>
        public static readonly DependencyProperty CaretBrushErrorProperty =
            DependencyProperty.RegisterAttached("CaretBrushError", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetCaretBrushError(DependencyObject obj)
        {
            return (Brush)obj.GetValue(CaretBrushErrorProperty);
        }
        
        /// <summary />
        public static void SetCaretBrushError(DependencyObject obj, Brush value)
        {
            obj.SetValue(CaretBrushErrorProperty, value);
        }

        #endregion

        #region 用于描述：其他颜色

        /// <summary>
        /// 矢量图颜色
        /// </summary>
        public static readonly DependencyProperty GeometryFillProperty = DependencyProperty.RegisterAttached(
            "GeometryFill", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static void SetGeometryFill(DependencyObject element, Brush value)
        {
            element.SetValue(GeometryFillProperty, value);
        }
        
        /// <summary />
        public static Brush GetGeometryFill(DependencyObject element)
        {
            return (Brush)element.GetValue(GeometryFillProperty);
        }

        /// <summary>
        /// 滑块/小部件颜色
        /// </summary>
        public static readonly DependencyProperty ThumbBrushProperty =
            DependencyProperty.RegisterAttached("ThumbBrush", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetThumbBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ThumbBrushProperty);
        }
        
        /// <summary />
        public static void SetThumbBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ThumbBrushProperty, value);
        }

        /// <summary>
        /// 装饰线颜色（仅用于列表框、导航栏）
        /// </summary>
        public static readonly DependencyProperty DecorativeLineBrushProperty =
            DependencyProperty.RegisterAttached("DecorativeLineBrush", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetDecorativeLineBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(DecorativeLineBrushProperty);
        }
        
        /// <summary />
        public static void SetDecorativeLineBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(DecorativeLineBrushProperty, value);
        }

        /// <summary>
        /// 弹出框背景画刷（仅用于下拉列表）
        /// </summary>
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.RegisterAttached("PopupBackground", typeof(Brush), typeof(AttachedProperties), new PropertyMetadata(default(Brush)));
        
        /// <summary />
        public static Brush GetPopupBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PopupBackgroundProperty);
        }
        
        /// <summary />
        public static void SetPopupBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(PopupBackgroundProperty, value);
        }

        #endregion
    }
}
