using System.Windows.Controls;
using Edid.Data;
using Edid.GeneralInfo;

namespace EdidEditor.Views
{
    public partial class GeneralInfoView : UserControl
    {
        public GeneralInfoView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo, byte[] edidData)
        {
            if (DataContext is GeneralInfoViewModel viewModel)
            {
                viewModel.SetData(edidInfo);
            }
        }
    }
}