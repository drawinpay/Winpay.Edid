using System.Windows.Controls;
using Edid.Common;
using Edid.Descriptors;
using Edid.Descriptors.Display;

namespace EdidEditor.Views
{
    public partial class SerialNumberDescriptorView : UserControl
    {
        public SerialNumberDescriptorView()
        {
            InitializeComponent();
        }

        public void SetData(StringDescriptor descriptor)
        {
            ResetDescriptorTypeSelection();
            
            TtbSerialNumber.Text = descriptor.Text;

            SetDescriptorType(descriptor.DescriptorType);

            if (descriptor is EdidField edidField)
            {
                byte byte2 = edidField.Data[edidField.ByteRange.StartIndex + 2];
                byte byte4 = edidField.Data[edidField.ByteRange.StartIndex + 4];

                TtbByte2Value.Text = FormatHex(byte2);
                TtbByte4Value.Text = FormatHex(byte4);
            }
            else
            {
                TtbByte2Value.Text = string.Empty;
                TtbByte4Value.Text = string.Empty;
            }
        }

        private void ResetDescriptorTypeSelection()
        {
            RdbDisplayProductSerialNumber.IsChecked = false;
            RdbAlphanumericDataString.IsChecked = false;
            RdbDisplayRangeLimits.IsChecked = false;
            RdbDisplayProductName.IsChecked = false;
            RdbColorPointData.IsChecked = false;
            RdbStandardTiming.IsChecked = false;
            RdbDisplayColorManagementData.IsChecked = false;
            RdbCvt3ByteTimingCode.IsChecked = false;
            RdbEstablishedTimingsIii.IsChecked = false;
        }

        private void SetDescriptorType(DescriptorType descriptorType)
        {
            switch (descriptorType)
            {
                case DescriptorType.DisplayProductSerialNumber:
                    RdbDisplayProductSerialNumber.IsChecked = true;
                    break;
                case DescriptorType.AlphanumericDataString:
                    RdbAlphanumericDataString.IsChecked = true;
                    break;
                case DescriptorType.DisplayRangeLimits:
                    RdbDisplayRangeLimits.IsChecked = true;
                    break;
                case DescriptorType.DisplayProductName:
                    RdbDisplayProductName.IsChecked = true;
                    break;
                case DescriptorType.ColorPointData:
                    RdbColorPointData.IsChecked = true;
                    break;
                case DescriptorType.StandardTiming:
                    RdbStandardTiming.IsChecked = true;
                    break;
                case DescriptorType.DisplayColorManagementData:
                    RdbDisplayColorManagementData.IsChecked = true;
                    break;
                case DescriptorType.Cvt3ByteTimingCode:
                    RdbCvt3ByteTimingCode.IsChecked = true;
                    break;
                case DescriptorType.EstablishedTimingsIII:
                    RdbEstablishedTimingsIii.IsChecked = true;
                    break;
            }
        }

        private static string FormatHex(byte value)
        {
            return $"{value:X2}h";
        }
    }
}