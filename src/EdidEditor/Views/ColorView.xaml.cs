using System.Windows.Controls;
using Edid.Data;

namespace EdidEditor.Views
{
    public partial class ColorView : UserControl
    {
        public ColorView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo)
        {
            if (DataContext is ColorViewModel viewModel)
            {
                viewModel.SetData(edidInfo);
            }
        }
    }
}