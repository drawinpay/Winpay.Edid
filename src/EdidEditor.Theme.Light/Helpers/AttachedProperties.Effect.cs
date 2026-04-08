using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace EdidEditor.Theme.Light.Helpers
{
    public partial class AttachedProperties
    {
        #region 用于描述：投射阴影效果（DropShadowEffect）属性

        /// <summary>
        /// 阴影深度
        /// </summary>
        public static readonly DependencyProperty EffectShadowDepthProperty = DependencyProperty.RegisterAttached(
            "EffectShadowDepth", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));

        /// <summary />
        public static void SetEffectShadowDepth(DependencyObject element, double value)
        {
            element.SetValue(EffectShadowDepthProperty, value);
        }
        
        /// <summary />
        public static double GetEffectShadowDepth(DependencyObject element)
        {
            return (double)element.GetValue(EffectShadowDepthProperty);
        }

        /// <summary>
        /// 阴影颜色
        /// </summary>
        public static readonly DependencyProperty EffectColorProperty = DependencyProperty.RegisterAttached(
            "EffectColor", typeof(Color), typeof(AttachedProperties), new PropertyMetadata(Colors.Transparent));
        
        /// <summary />
        public static void SetEffectColor(DependencyObject element, Color value)
        {
            element.SetValue(EffectColorProperty, value);
        }
        
        /// <summary />
        public static Color GetEffectColor(DependencyObject element)
        {
            return (Color)element.GetValue(EffectColorProperty);
        }

        /// <summary>
        /// 阴影方向
        /// </summary>
        public static readonly DependencyProperty EffectDirectionProperty =
            DependencyProperty.RegisterAttached("EffectDirection", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static double GetEffectDirection(DependencyObject obj)
        {
            return (double)obj.GetValue(EffectDirectionProperty);
        }
        
        /// <summary />
        public static void SetEffectDirection(DependencyObject obj, double value)
        {
            obj.SetValue(EffectDirectionProperty, value);
        }

        /// <summary>
        /// 阴影透明度
        /// </summary>
        public static readonly DependencyProperty EffectOpacityProperty = DependencyProperty.RegisterAttached(
            "EffectOpacity", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static void SetEffectOpacity(DependencyObject element, double value)
        {
            element.SetValue(EffectOpacityProperty, value);
        }
        
        /// <summary />
        public static double GetEffectOpacity(DependencyObject element)
        {
            return (double)element.GetValue(EffectOpacityProperty);
        }

        /// <summary>
        /// 阴影模糊半径
        /// </summary>
        public static readonly DependencyProperty EffectBlurRadiusProperty = DependencyProperty.RegisterAttached(
            "EffectBlurRadius", typeof(double), typeof(AttachedProperties), new PropertyMetadata(default(double)));
        
        /// <summary />
        public static void SetEffectBlurRadius(DependencyObject element, double value)
        {
            element.SetValue(EffectBlurRadiusProperty, value);
        }
        
        /// <summary />
        public static double GetEffectBlurRadius(DependencyObject element)
        {
            return (double)element.GetValue(EffectBlurRadiusProperty);
        }

        /// <summary>
        /// 渲染注重性能还是质量
        /// </summary>
        public static readonly DependencyProperty EffectRenderingBiasProperty =
            DependencyProperty.RegisterAttached("EffectRenderingBias", typeof(RenderingBias), typeof(AttachedProperties), new PropertyMetadata(default(RenderingBias)));
        
        /// <summary />
        public static RenderingBias GetEffectRenderingBias(DependencyObject obj)
        {
            return (RenderingBias) obj.GetValue(EffectRenderingBiasProperty);
        }
        
        /// <summary />
        public static void SetEffectRenderingBias(DependencyObject obj, RenderingBias value)
        {
            obj.SetValue(EffectRenderingBiasProperty, value);
        }

        #endregion
    }
}
