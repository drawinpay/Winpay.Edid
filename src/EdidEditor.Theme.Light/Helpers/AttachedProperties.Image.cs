using System.Windows;
using System.Windows.Media;

namespace EdidEditor.Theme.Light.Helpers
{
    public partial class AttachedProperties
    {
        #region 用于描述：图片

        /// <summary>
        /// 普通图片
        /// </summary>
        public static readonly DependencyProperty ImageNormalProperty = DependencyProperty.RegisterAttached(
            "ImageNormal", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(default(ImageSource)));

        /// <summary />
        public static void SetImageNormal(DependencyObject element, ImageSource value)
        {
            element.SetValue(ImageNormalProperty, value);
        }
        
        /// <summary />
        public static ImageSource GetImageNormal(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImageNormalProperty);
        }

        /// <summary>
        /// 悬停时图片
        /// </summary>
        public static readonly DependencyProperty ImageHoverProperty = DependencyProperty.RegisterAttached(
            "ImageHover", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(default(ImageSource)));
        
        /// <summary />
        public static void SetImageHover(DependencyObject element, ImageSource value)
        {
            element.SetValue(ImageHoverProperty, value);
        }
        
        /// <summary />
        public static ImageSource GetImageHover(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImageHoverProperty);
        }

        /// <summary>
        /// 按压时图片
        /// </summary>
        public static readonly DependencyProperty ImagePressedProperty = DependencyProperty.RegisterAttached(
            "ImagePressed", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(default(ImageSource)));
        
        /// <summary />
        public static void SetImagePressed(DependencyObject element, ImageSource value)
        {
            element.SetValue(ImagePressedProperty, value);
        }
        
        /// <summary />
        public static ImageSource GetImagePressed(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImagePressedProperty);
        }

        /// <summary>
        /// 选中时图片
        /// </summary>
        public static readonly DependencyProperty ImageCheckedProperty = DependencyProperty.RegisterAttached(
            "ImageChecked", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(default(ImageSource)));

        /// <summary />
        public static void SetImageChecked(DependencyObject element, ImageSource value)
        {
            element.SetValue(ImageCheckedProperty, value);
        }

        /// <summary />
        public static ImageSource GetImageChecked(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImageCheckedProperty);
        }

        /// <summary>
        /// 不可用状态图片
        /// </summary>
        public static readonly DependencyProperty ImageDisableProperty = DependencyProperty.RegisterAttached(
            "ImageDisable", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(default(ImageSource)));

        /// <summary />
        public static void SetImageDisable(DependencyObject element, ImageSource value)
        {
            element.SetValue(ImageDisableProperty, value);
        }

        /// <summary />
        public static ImageSource GetImageDisable(DependencyObject element)
        {
            return (ImageSource)element.GetValue(ImageDisableProperty);
        }

        #endregion

        #region 用于描述：图形

        /// <summary>
        /// 图形
        /// </summary>
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
            "Geometry", typeof(Geometry), typeof(AttachedProperties), new PropertyMetadata(default(Geometry)));
        
        /// <summary />
        public static void SetGeometry(DependencyObject element, Geometry value)
        {
            element.SetValue(GeometryProperty, value);
        }
        
        /// <summary />
        public static Geometry GetGeometry(DependencyObject element)
        {
            return (Geometry)element.GetValue(GeometryProperty);
        }

        #endregion
    }
}
