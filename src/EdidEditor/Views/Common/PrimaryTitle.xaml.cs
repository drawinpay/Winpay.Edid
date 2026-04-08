using System.Windows;
using System.Windows.Controls;

namespace EdidEditor.Views.Common
{
    /// <summary>
    /// PrimaryTitle.xaml 的交互逻辑
    /// </summary>
    public partial class PrimaryTitle : UserControl
    {
        /// <summary>
        /// 标题头名称
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string Tips
        {
            get => (string)GetValue(TipsProperty);
            set => SetValue(TipsProperty, value);
        }

        /// <summary>
        /// Title
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(PrimaryTitle), new PropertyMetadata(""));

        /// <summary>
        /// Tips 
        /// </summary>
        public static readonly DependencyProperty TipsProperty =
            DependencyProperty.Register(nameof(Tips), typeof(string), typeof(PrimaryTitle), new PropertyMetadata(""));

        /// <summary>
        /// Constructor
        /// </summary>
        public PrimaryTitle()
        {
            InitializeComponent();
        }
    }
}
