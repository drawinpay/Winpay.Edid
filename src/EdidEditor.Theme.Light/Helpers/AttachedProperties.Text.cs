using System.Windows;

namespace EdidEditor.Theme.Light.Helpers
{
    public partial class AttachedProperties
    {
        #region 用于描述：文本内容

        /// <summary>
        /// 文本
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(AttachedProperties), new PropertyMetadata(default(string)));

        /// <summary />
        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }
        
        /// <summary />
        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        /// <summary>
        /// 提示文本（用于文本框框内提示、下拉框框内提示）
        /// </summary>
        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.RegisterAttached("HintText", typeof(string), typeof(AttachedProperties), new PropertyMetadata(default(string)));
        
        /// <summary />
        public static string GetHintText(DependencyObject obj)
        {
            return (string)obj.GetValue(HintTextProperty);
        }
        
        /// <summary />
        public static void SetHintText(DependencyObject obj, string value)
        {
            obj.SetValue(HintTextProperty, value);
        }

        /// <summary>
        /// 提示文本2（用于文本框下方提示、下拉列表背景提示）
        /// </summary>
        public static readonly DependencyProperty HintText2Property =
            DependencyProperty.RegisterAttached("HintText2", typeof(string), typeof(AttachedProperties), new PropertyMetadata(default(string)));
        
        /// <summary />
        public static string GetHintText2(DependencyObject obj)
        {
            return (string)obj.GetValue(HintText2Property);
        }
        
        /// <summary />
        public static void SetHintText2(DependencyObject obj, string value)
        {
            obj.SetValue(HintText2Property, value);
        }

        /// <summary>
        /// 提示文本3（用于下拉列表滚动范围内底部提示）
        /// </summary>
        public static readonly DependencyProperty HintText3Property =
            DependencyProperty.RegisterAttached("HintText3", typeof(string), typeof(AttachedProperties), new PropertyMetadata(default(string)));
        
        /// <summary />
        public static string GetHintText3(DependencyObject obj)
        {
            return (string)obj.GetValue(HintText3Property);
        }
        
        /// <summary />
        public static void SetHintText3(DependencyObject obj, string value)
        {
            obj.SetValue(HintText3Property, value);
        }


        /// <summary>
        /// 文本自动换行的附加属性
        /// </summary>
        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.RegisterAttached("TextWrapping", typeof(TextWrapping), typeof(AttachedProperties), new PropertyMetadata(TextWrapping.NoWrap));

        /// <summary>
        /// 获取文本自动换行的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TextWrapping GetTextWrapping(DependencyObject obj)
        {
            return (TextWrapping)obj.GetValue(TextWrappingProperty);
        }

        /// <summary>
        /// 设置文本自动换行的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetTextWrapping(DependencyObject obj, TextWrapping value)
        {
            obj.SetValue(TextWrappingProperty, value);
        }

        /// <summary>
        /// 文本溢出裁剪方式的附加属性
        /// </summary>
        public static readonly DependencyProperty TextTrimmingProperty =
            DependencyProperty.RegisterAttached("TextTrimming", typeof(TextTrimming), typeof(AttachedProperties), new PropertyMetadata(TextTrimming.None));

        /// <summary>
        /// 获取文本溢出裁剪方式的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TextTrimming GetTextTrimming(DependencyObject obj)
        {
            return (TextTrimming)obj.GetValue(TextTrimmingProperty);
        }

        /// <summary>
        /// 设置文本溢出裁剪方式的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetTextTrimming(DependencyObject obj, TextTrimming value)
        {
            obj.SetValue(TextTrimmingProperty, value);
        }

        /// <summary>
        /// 文本字号的附加属性
        /// </summary>
        public static readonly DependencyProperty FontSizeProperty = DependencyProperty.RegisterAttached(
            "FontSize", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));

        /// <summary>
        /// 获取文本字号的附加属性
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetFontSize(DependencyObject element, double value)
        {
            element.SetValue(FontSizeProperty, value);
        }
        
        /// <summary>
        /// 设置文本字号的附加属性
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static double GetFontSize(DependencyObject element)
        {
            return (double)element.GetValue(FontSizeProperty);
        }

        /// <summary>
        /// 常规文本字重的附加属性
        /// </summary>
        public static readonly DependencyProperty FontWeightNormalProperty =
            DependencyProperty.RegisterAttached("FontWeightNormal", typeof(FontWeight), typeof(AttachedProperties), new PropertyMetadata(SystemFonts.MessageFontWeight));

        /// <summary>
        /// 获取常规文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static FontWeight GetFontWeightNormal(DependencyObject obj)
        {
            return (FontWeight)obj.GetValue(FontWeightNormalProperty);
        }

        /// <summary>
        /// 设置常规文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetFontWeightNormal(DependencyObject obj, FontWeight value)
        {
            obj.SetValue(FontWeightNormalProperty, value);
        }



        /// <summary>
        /// 按压文本字重的附加属性
        /// </summary>
        public static readonly DependencyProperty FontWeightPressedProperty =
            DependencyProperty.RegisterAttached("FontWeightPressed", typeof(FontWeight), typeof(AttachedProperties), new PropertyMetadata(default));

        /// <summary>
        /// 获取按压文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static FontWeight GetFontWeightPressed(DependencyObject obj)
        {
            return (FontWeight)obj.GetValue(FontWeightPressedProperty);
        }

        /// <summary>
        /// 设置按压文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetFontWeightPressed(DependencyObject obj, FontWeight value)
        {
            obj.SetValue(FontWeightPressedProperty, value);
        }

        /// <summary>
        /// 悬浮文本字重的附加属性
        /// </summary>
        public static readonly DependencyProperty FontWeightHoverProperty =
            DependencyProperty.RegisterAttached("FontWeightHover", typeof(FontWeight), typeof(AttachedProperties), new PropertyMetadata(default));

        /// <summary>
        /// 获取悬浮文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static FontWeight GetFontWeightHover(DependencyObject obj)
        {
            return (FontWeight)obj.GetValue(FontWeightHoverProperty);
        }

        /// <summary>
        /// 设置悬浮文本字重的附加属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetFontWeightHover(DependencyObject obj, FontWeight value)
        {
            obj.SetValue(FontWeightHoverProperty, value);
        }

        #endregion
    }
}
