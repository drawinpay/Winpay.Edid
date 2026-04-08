using System.Windows.Controls;
using Edid.DisplayInfo;

namespace EdidEditor.Views
{
    public partial class DisplayView : UserControl
    {
        public DisplayView()
        {
            InitializeComponent();
        }

        public void SetData(BasicDisplayInfo basicDisplayInfo)
        {
            if (DataContext is DisplayViewModel viewModel)
            {
                viewModel.SetData(basicDisplayInfo);
            }
        }
    }
}