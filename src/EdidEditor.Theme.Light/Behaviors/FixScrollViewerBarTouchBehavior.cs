using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace EdidEditor.Theme.Light.Behaviors
{
    /// <summary>
    /// 修复ScrollViewer内部ScrollBar无法被触摸滑动的行为
    /// </summary>
    internal class FixScrollViewerBarTouchBehavior : Behavior<FrameworkElement>
    {
        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseEnter += OnMouseEnter;
            AssociatedObject.MouseLeave -= OnMouseLeave;
            AssociatedObject.MouseLeave += OnMouseLeave;
        }

        /// <summary>
        /// 关闭所有父级ScrollViewer的触摸滑动
        /// </summary>
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            ForEachParentScrollViewer(scrollViewer => scrollViewer.IsManipulationEnabled = false);
        }

        /// <summary>
        /// 恢复所有父级ScrollViewer的触摸滑动
        /// </summary>
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            ForEachParentScrollViewer(scrollViewer => scrollViewer.IsManipulationEnabled = true);
        }

        /// <summary>
        /// 遍历父级ScrollViewer的辅助函数
        /// </summary>
        private void ForEachParentScrollViewer(Action<ScrollViewer> action)
        {
            DependencyObject? present = VisualTreeHelper.GetParent(AssociatedObject);
            while (present != null)
            {
                if (present is ScrollViewer scrollViewer)
                {
                    action(scrollViewer);
                }
                present = VisualTreeHelper.GetParent(present);
            }
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseLeave -= OnMouseLeave;
        }
    }
}
