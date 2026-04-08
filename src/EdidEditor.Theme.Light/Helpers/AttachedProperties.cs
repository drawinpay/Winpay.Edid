using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace EdidEditor.Theme.Light.Helpers
{
    /// <summary>
    /// 控件附加属性辅助类
    /// </summary>
    public partial class AttachedProperties
    {

        #region 用于描述：是否开启某个控件特性

        /// <summary>
        /// 是否拥有清空按钮（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty HasClearButtonProperty =
            DependencyProperty.RegisterAttached("HasClearButton", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(true));

        /// <summary />
        public static bool GetHasClearButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasClearButtonProperty);
        }
        
        /// <summary />
        public static void SetHasClearButton(DependencyObject obj, bool value)
        {
            obj.SetValue(HasClearButtonProperty, value);
        }

        /// <summary>
        /// 是否拥有分隔线（仅用于列表框）
        /// </summary>
        public static readonly DependencyProperty HasSeparatorProperty =
            DependencyProperty.RegisterAttached("HasSeparator", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(true));
        
        /// <summary />
        public static bool GetHasSeparator(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasSeparatorProperty);
        }
        
        /// <summary />
        public static void SetHasSeparator(DependencyObject obj, bool value)
        {
            obj.SetValue(HasSeparatorProperty, value);
        }

        /// <summary>
        /// 是否拥有装饰线（仅用于列表框）
        /// </summary>
        public static readonly DependencyProperty HasDecorativeLineProperty =
            DependencyProperty.RegisterAttached("HasDecorativeLine", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(true));
        
        /// <summary />
        public static bool GetHasDecorativeLine(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasDecorativeLineProperty);
        }
        
        /// <summary />
        public static void SetHasDecorativeLine(DependencyObject obj, bool value)
        {
            obj.SetValue(HasDecorativeLineProperty, value);
        }

        /// <summary>
        /// 当前是否显示装饰线（只读属性）
        /// </summary>
        internal static readonly DependencyProperty ActualHasDecorativeLineProperty =
            DependencyProperty.RegisterAttached("ActualHasDecorativeLine", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false));
        
        /// <summary />
        public static bool GetActualHasDecorativeLine(DependencyObject obj)
        {
            return (bool)obj.GetValue(ActualHasDecorativeLineProperty);
        }
        
        /// <summary />
        internal static void SetActualHasDecorativeLine(DependencyObject obj, bool value)
        {
            obj.SetValue(ActualHasDecorativeLineProperty, value);
        }

        /// <summary>
        /// 是否可自由拖动（仅用于滑动条支持从空白条处开始拖动）（仅内部使用，不支持禁用拖动）
        /// </summary>
        internal static readonly DependencyProperty IsDraggableProperty =
            DependencyProperty.RegisterAttached("IsDraggable", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(OnIsDraggableChanged));
        
        /// <summary />
        public static bool GetIsDraggable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggableProperty);
        }
        
        /// <summary />
        public static void SetIsDraggable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggableProperty, value);
        }

        private static void OnIsDraggableChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                return;
            }

            Slider? slider = obj as Slider;
            if (slider == null)
            {
                return;
            }

            FrameworkElement? parent = slider.Parent as FrameworkElement;
            if (parent == null)
            {
                return;
            }

            bool isMousePressed = false;
            parent.PreviewMouseDown += (sender, args) =>
            {
                if (!slider.IsMouseOver) // 只有鼠标在相关滑条上时点击才有效，避免同一布局下的不同滑条同时激活拖放
                {
                    return;
                }

                isMousePressed = true;
                SetActualIsDragging(slider, true);
            };
            parent.PreviewMouseUp += (sender, args) =>
            {
                isMousePressed = false;
                slider.ReleaseMouseCapture();
                SetActualIsDragging(slider, false);
            };
            slider.MouseMove += (sender, mouseEvent) =>
            {
                if (!isMousePressed ||
                    mouseEvent.LeftButton != MouseButtonState.Pressed)
                {
                    return;
                }

                if (!slider.IsMouseCaptured)
                {
                    slider.CaptureMouse();
                }

                // 利用滑动条开启了IsMoveToPointEnabled特性，在鼠标移动时模拟发生鼠标左键按下事件，来实现拖放
                MouseButtonEventArgs args = new MouseButtonEventArgs(mouseEvent.MouseDevice, mouseEvent.Timestamp, MouseButton.Left)
                {
                    RoutedEvent = UIElement.PreviewMouseLeftButtonDownEvent,
                    Source = mouseEvent.Source,
                };
                slider.RaiseEvent(args);
            };
        }

        /// <summary>
        /// 当前是否正在拖动（仅用于辅助可拖动特性实现，外部不应使用）
        /// </summary>
        internal static readonly DependencyProperty ActualIsDraggingProperty =
            DependencyProperty.RegisterAttached("ActualIsDragging", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false));
        
        /// <summary />
        public static bool GetActualIsDragging(DependencyObject? obj)
        {
            return (bool)obj.GetValue(ActualIsDraggingProperty);
        }
        
        /// <summary />
        public static void SetActualIsDragging(DependencyObject? obj, bool value)
        {
            obj.SetValue(ActualIsDraggingProperty, value);
        }

        /// <summary>
        /// 滑动条是否会在值变化时显示数值提示
        /// </summary>
        public static readonly DependencyProperty IsSliderWillHintOnValueChangedProperty =
            DependencyProperty.RegisterAttached("IsSliderWillHintOnValueChanged", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(OnIsSliderWillHintOnValueChangedChanged));

        /// <summary />
        public static bool GetIsSliderWillHintOnValueChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSliderWillHintOnValueChangedProperty);
        }

        /// <summary />
        public static void SetIsSliderWillHintOnValueChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSliderWillHintOnValueChangedProperty, value);
        }

        private static void OnIsSliderWillHintOnValueChangedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Slider slider = obj as Slider;
            if (slider == null)
            {
                return;
            }

            if (!(bool) e.NewValue)
            {
                slider.ValueChanged -= HandleSliderValueChanged;
                return;
            }

            slider.ValueChanged += HandleSliderValueChanged;
        }

        private static void HandleSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            if (sender is not Slider slider)
            {
                return;
            }

            bool actualIsDragging = GetActualIsDragging(slider);

            // 触发滑动条数值提示
            if (!actualIsDragging) // 如果原本是true，就不要因此变为false
            {
                SetActualIsDragging(slider, true);
                SetActualIsDragging(slider, false);
            }
        }

        #endregion

        #region 用于描述：是否设置控件为某状态

        /// <summary>
        /// 是否为警告状态（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty IsWarningProperty =
            DependencyProperty.RegisterAttached("IsWarning", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false));
        
        /// <summary />
        public static bool GetIsWarning(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsWarningProperty);
        }
        
        /// <summary />
        public static void SetIsWarning(DependencyObject obj, bool value)
        {
            obj.SetValue(IsWarningProperty, value);
        }

        /// <summary>
        /// 是否为错误状态（仅用于文本框）
        /// </summary>
        public static readonly DependencyProperty IsErrorProperty =
            DependencyProperty.RegisterAttached("IsError", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false));
        
        /// <summary />
        public static bool GetIsError(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsErrorProperty);
        }
        
        /// <summary />
        public static void SetIsError(DependencyObject obj, bool value)
        {
            obj.SetValue(IsErrorProperty, value);
        }

        /// <summary>
        /// 是否被选中
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false));
        
        /// <summary />
        public static bool GetIsSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedProperty);
        }
        
        /// <summary />
        public static void SetIsSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedProperty, value);
        }

        #endregion

        #region 用于描述：部件对齐方式

        /// <summary>
        /// 文本水平对齐
        /// </summary>
        public static readonly DependencyProperty TextHorizontalAlignmentProperty =
            DependencyProperty.RegisterAttached("TextHorizontalAlignment", typeof(HorizontalAlignment), typeof(AttachedProperties), new PropertyMetadata(default(HorizontalAlignment)));
        
        /// <summary />
        public static HorizontalAlignment GetTextHorizontalAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(TextHorizontalAlignmentProperty);
        }
        
        /// <summary />
        public static void SetTextHorizontalAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(TextHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// 文本垂直对齐
        /// </summary>
        public static readonly DependencyProperty TextVerticalAlignmentProperty =
            DependencyProperty.RegisterAttached("TextVerticalAlignment", typeof(VerticalAlignment), typeof(AttachedProperties), new PropertyMetadata(default(VerticalAlignment)));
        
        /// <summary />
        public static VerticalAlignment GetTextVerticalAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(TextVerticalAlignmentProperty);
        }
        
        /// <summary />
        public static void SetTextVerticalAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(TextVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// 小部件水平对齐
        /// </summary>
        public static readonly DependencyProperty ThumbHorizontalAlignmentProperty =
            DependencyProperty.RegisterAttached("ThumbHorizontalAlignment", typeof(HorizontalAlignment), typeof(AttachedProperties), new PropertyMetadata(default(HorizontalAlignment)));
        
        /// <summary />
        public static HorizontalAlignment GetThumbHorizontalAlignment(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(ThumbHorizontalAlignmentProperty);
        }
        
        /// <summary />
        public static void SetThumbHorizontalAlignment(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(ThumbHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// 小部件垂直对齐
        /// </summary>
        public static readonly DependencyProperty ThumbVerticalAlignmentProperty =
            DependencyProperty.RegisterAttached("ThumbVerticalAlignment", typeof(VerticalAlignment), typeof(AttachedProperties), new PropertyMetadata(default(VerticalAlignment)));
        
        /// <summary />
        public static VerticalAlignment GetThumbVerticalAlignment(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(ThumbVerticalAlignmentProperty);
        }
        
        /// <summary />
        public static void SetThumbVerticalAlignment(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(ThumbVerticalAlignmentProperty, value);
        }

        #endregion

        #region 用于描述：部件样式

        /// <summary>
        /// 边框样式
        /// </summary>
        public static readonly DependencyProperty BorderStyleProperty =
            DependencyProperty.RegisterAttached("BorderStyle", typeof(Style), typeof(AttachedProperties), new PropertyMetadata(default(Style)));
        
        /// <summary />
        public static Style GetBorderStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(BorderStyleProperty);
        }
        
        /// <summary />
        public static void SetBorderStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(BorderStyleProperty, value);
        }

        /// <summary>
        /// 滑块/小部件样式
        /// </summary>
        public static readonly DependencyProperty ThumbStyleProperty =
            DependencyProperty.RegisterAttached("ThumbStyle", typeof(Style), typeof(AttachedProperties), new PropertyMetadata(default(Style)));

        /// <summary />
        public static Style GetThumbStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(ThumbStyleProperty);
        }
        
        /// <summary />
        public static void SetThumbStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(ThumbStyleProperty, value);
        }

        /// <summary>
        /// 滑块/小部件附加文字的位置
        /// </summary>
        public static readonly DependencyProperty ThumbTextPlacementProperty =
            DependencyProperty.RegisterAttached("ThumbTextPlacement", typeof(TickBarPlacement), typeof(AttachedProperties), new PropertyMetadata(TickBarPlacement.Top));

        /// <summary />
        public static TickBarPlacement GetThumbTextPlacement(DependencyObject obj)
        {
            return (TickBarPlacement)obj.GetValue(ThumbTextPlacementProperty);
        }

        /// <summary />
        public static void SetThumbTextPlacement(DependencyObject obj, TickBarPlacement value)
        {
            obj.SetValue(ThumbTextPlacementProperty, value);
        }

        /// <summary>
        /// 滚动查看器样式
        /// </summary>
        public static readonly DependencyProperty ScrollViewerStyleProperty =
            DependencyProperty.RegisterAttached("ScrollViewerStyle", typeof(Style), typeof(AttachedProperties), new PropertyMetadata(default(Style)));
        
        /// <summary />
        public static Style GetScrollViewerStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(ScrollViewerStyleProperty);
        }
        
        /// <summary />
        public static void SetScrollViewerStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(ScrollViewerStyleProperty, value);
        }

        /// <summary>
        /// 按钮样式（仅用于文本框清空按钮）
        /// </summary>
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.RegisterAttached("ButtonStyle", typeof(Style), typeof(AttachedProperties), new PropertyMetadata(default(Style)));
        
        /// <summary />
        public static Style GetButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(ButtonStyleProperty);
        }
        
        /// <summary />
        public static void SetButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(ButtonStyleProperty, value);
        }

        #endregion

        #region 预置命令

        /// <summary>
        /// 点击控件内部按钮时触发的命令（仅用于文本框清空按钮）
        /// </summary>
        public static readonly DependencyProperty CommandOnClickButtonProperty =
            DependencyProperty.RegisterAttached("CommandOnClickButton", typeof(ICommand), typeof(AttachedProperties), new PropertyMetadata(default(ICommand)));
        
        /// <summary />
        public static ICommand GetCommandOnClickButton(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandOnClickButtonProperty);
        }
        
        /// <summary />
        public static void SetCommandOnClickButton(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandOnClickButtonProperty, value);
        }

        /// <summary>
        /// 滚动查看器滚动到顶部时触发的命令（仅用于下拉框）
        /// </summary>
        public static readonly DependencyProperty CommandOnScrollToTopProperty =
            DependencyProperty.RegisterAttached("CommandOnScrollToTop", typeof(ICommand), typeof(AttachedProperties), new PropertyMetadata(default(ICommand)));
        
        /// <summary />
        public static ICommand GetCommandOnScrollToTop(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandOnScrollToTopProperty);
        }
        
        /// <summary />
        public static void SetCommandOnScrollToTop(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandOnScrollToTopProperty, value);
        }

        /// <summary>
        /// 滚动查看器滚动到底部时触发的命令（仅用于下拉框）
        /// </summary>
        public static readonly DependencyProperty CommandOnScrollToEndProperty =
            DependencyProperty.RegisterAttached("CommandOnScrollToEnd", typeof(ICommand), typeof(AttachedProperties), new PropertyMetadata(default(ICommand)));
        
        /// <summary />
        public static ICommand GetCommandOnScrollToEnd(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandOnScrollToEndProperty);
        }
        
        /// <summary />
        public static void SetCommandOnScrollToEnd(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandOnScrollToEndProperty, value);
        }

        #endregion

        #region 杂项

        /// <summary>
        /// 文本样式（下划线、删除线等）
        /// </summary>
        public static readonly DependencyProperty TextDecorationsProperty = DependencyProperty.RegisterAttached(
            "TextDecorations", typeof(TextDecorationCollection), typeof(AttachedProperties), new PropertyMetadata(default(TextDecorationCollection)));
        
        /// <summary />
        public static void SetTextDecorations(DependencyObject element, TextDecorationCollection value)
        {
            element.SetValue(TextDecorationsProperty, value);
        }
        
        /// <summary />
        public static TextDecorationCollection GetTextDecorations(DependencyObject element)
        {
            return (TextDecorationCollection)element.GetValue(TextDecorationsProperty);
        }
        
        /// <summary>
        /// 图片填充方式
        /// </summary>
        public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.RegisterAttached(
            "ImageStretch", typeof(Stretch), typeof(AttachedProperties), new PropertyMetadata(Stretch.Uniform));
        
        /// <summary />
        public static void SetImageStretch(DependencyObject element, Stretch value)
        {
            element.SetValue(ImageStretchProperty, value);
        }
        
        /// <summary />
        public static Stretch GetImageStretch(DependencyObject element)
        {
            return (Stretch)element.GetValue(ImageStretchProperty);
        }

        /// <summary>
        /// 布局方向
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.RegisterAttached("Orientation", typeof(Orientation), typeof(AttachedProperties), new PropertyMetadata(default(Orientation)));
        
        /// <summary />
        public static Orientation GetOrientation(DependencyObject obj)
        {
            return (Orientation)obj.GetValue(OrientationProperty);
        }
        
        /// <summary />
        public static void SetOrientation(DependencyObject obj, Orientation value)
        {
            obj.SetValue(OrientationProperty, value);
        }

        /// <summary>
        /// 当前动画进度（只读属性，用于辅助动画实现）
        /// </summary>
        internal static readonly DependencyProperty AnimationProgressProperty =
            DependencyProperty.RegisterAttached("AnimationProgress", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetAnimationProgress(DependencyObject obj)
        {
            return (double)obj.GetValue(AnimationProgressProperty);
        }
        
        /// <summary />
        internal static void SetAnimationProgress(DependencyObject obj, double value)
        {
            obj.SetValue(AnimationProgressProperty, value);
        }

        /// <summary>
        /// 进度值
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetValue(DependencyObject obj)
        {
            return (double)obj.GetValue(ValueProperty);
        }
        
        /// <summary />
        public static void SetValue(DependencyObject obj, double value)
        {
            obj.SetValue(ValueProperty, value);
        }

        /// <summary>
        /// 显示隐藏的附加属性
        /// </summary>
        public static readonly DependencyProperty VisibilityProperty =
            DependencyProperty.RegisterAttached("Visibility", typeof(Visibility), typeof(AttachedProperties), new PropertyMetadata(default));

        /// <summary />
        public static Visibility GetVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(VisibilityProperty);
        }

        /// <summary />
        public static void SetVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(VisibilityProperty, value);
        }


        #endregion
    }
}
