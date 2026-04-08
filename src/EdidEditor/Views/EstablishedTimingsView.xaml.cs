using System.Windows.Controls;
using Edid.Data;

namespace EdidEditor.Views
{
    public partial class EstablishedTimingsView : UserControl
    {
        public EstablishedTimingsView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo)
        {
            if (DataContext is EstablishedTimingsViewModel viewModel)
            {
                viewModel.SetData(edidInfo);
            }
        }
    }
}