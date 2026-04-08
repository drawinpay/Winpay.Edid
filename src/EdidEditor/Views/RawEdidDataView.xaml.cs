using System.Windows.Controls;
using Edid.Common;

namespace EdidEditor.Views
{
    public partial class RawEdidDataView : UserControl
    {
        public RawEdidDataView()
        {
            InitializeComponent();
        }

        public void SetData(byte[]? edidData)
        {
            if (DataContext is RawEdidDataViewModel viewModel)
            {
                viewModel.SetData(edidData);
            }
        }

        public void SetSelectedBytes(ByteRange byteRange)
        {
            if (DataContext is RawEdidDataViewModel viewModel)
            {
                viewModel.SetSelectedBytes(byteRange);
            }
        }
    }
}