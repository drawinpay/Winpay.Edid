using System.Windows.Controls;
using Edid.Common;
using Edid.Descriptors;
using Edid.Descriptors.Display;

namespace EdidEditor.Views
{
    public partial class DisplayRangeLimitsDescriptorView : UserControl
    {
        public DisplayRangeLimitsDescriptorView()
        {
            InitializeComponent();
        }

        public void SetData(DisplayRangeLimitsDescriptor descriptor)
        {
            ResetDescriptorTypeSelection();
            ResetOffsetFlags();
            ResetVideoTimingSupportFlags();
            
            SetDescriptorType(descriptor.DescriptorType);

            if (descriptor is not EdidField edidField)
            {
                ClearValues();
                return;
            }

            int startIndex = edidField.ByteRange.StartIndex;
            byte[] data = edidField.Data;

            byte offsetFlags = data[startIndex + 4];
            int verticalOffsetMode = offsetFlags & 0x03;
            int horizontalOffsetMode = offsetFlags >> 2 & 0x03;

            TtbMinVerticalRate.Text = ReadRate(data[startIndex + 5], verticalOffsetMode is 0x03).ToString();
            TtbMaxVerticalRate.Text = ReadRate(data[startIndex + 6], verticalOffsetMode is 0x02 or 0x03).ToString();
            TtbMinHorizontalRate.Text = ReadRate(data[startIndex + 7], horizontalOffsetMode is 0x03).ToString();
            TtbMaxHorizontalRate.Text = ReadRate(data[startIndex + 8], horizontalOffsetMode is 0x02 or 0x03).ToString();
            TtbMaxPixelClock.Text = (data[startIndex + 9] * 10).ToString();

            SetVerticalOffsetFlags(verticalOffsetMode);
            SetHorizontalOffsetFlags(horizontalOffsetMode);
            SetVideoTimingSupportFlags(data[startIndex + 10]);

            TtbByte2Value.Text = FormatHex(data[startIndex + 2]);
            TtbByte11Value.Text = FormatHex(data[startIndex + 11]);
            TtbByte12Value.Text = FormatHex(data[startIndex + 12]);
            TtbByte13Value.Text = FormatHex(data[startIndex + 13]);
            TtbByte14Value.Text = FormatHex(data[startIndex + 14]);
            TtbByte15Value.Text = FormatHex(data[startIndex + 15]);
            TtbByte16Value.Text = FormatHex(data[startIndex + 16]);
        }

        private void ClearValues()
        {
            TtbMinVerticalRate.Text = string.Empty;
            TtbMaxVerticalRate.Text = string.Empty;
            TtbMinHorizontalRate.Text = string.Empty;
            TtbMaxHorizontalRate.Text = string.Empty;
            TtbMaxPixelClock.Text = string.Empty;
            TtbByte2Value.Text = string.Empty;
            TtbByte11Value.Text = string.Empty;
            TtbByte12Value.Text = string.Empty;
            TtbByte13Value.Text = string.Empty;
            TtbByte14Value.Text = string.Empty;
            TtbByte15Value.Text = string.Empty;
            TtbByte16Value.Text = string.Empty;
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

        private void ResetOffsetFlags()
        {
            RdbVerticalOffsetZero.IsChecked = false;
            RdbVerticalOffsetMaxOnly.IsChecked = false;
            RdbVerticalOffsetMaxMin.IsChecked = false;
            RdbHorizontalOffsetZero.IsChecked = false;
            RdbHorizontalOffsetMaxOnly.IsChecked = false;
            RdbHorizontalOffsetMaxMin.IsChecked = false;
        }

        private void SetVerticalOffsetFlags(int mode)
        {
            switch (mode)
            {
                case 0x00:
                    RdbVerticalOffsetZero.IsChecked = true;
                    break;
                case 0x02:
                    RdbVerticalOffsetMaxOnly.IsChecked = true;
                    break;
                case 0x03:
                    RdbVerticalOffsetMaxMin.IsChecked = true;
                    break;
            }
        }

        private void SetHorizontalOffsetFlags(int mode)
        {
            switch (mode)
            {
                case 0x00:
                    RdbHorizontalOffsetZero.IsChecked = true;
                    break;
                case 0x02:
                    RdbHorizontalOffsetMaxOnly.IsChecked = true;
                    break;
                case 0x03:
                    RdbHorizontalOffsetMaxMin.IsChecked = true;
                    break;
            }
        }

        private void ResetVideoTimingSupportFlags()
        {
            RdbDefaultGtf.IsChecked = false;
            RdbRangeLimitOnly.IsChecked = false;
            RdbSecondaryGtf.IsChecked = false;
            RdbCvt.IsChecked = false;
        }

        private void SetVideoTimingSupportFlags(byte value)
        {
            switch (value)
            {
                case 0x00:
                    RdbDefaultGtf.IsChecked = true;
                    break;
                case 0x01:
                    RdbRangeLimitOnly.IsChecked = true;
                    break;
                case 0x02:
                    RdbSecondaryGtf.IsChecked = true;
                    break;
                case 0x04:
                    RdbCvt.IsChecked = true;
                    break;
            }
        }

        private static int ReadRate(byte value, bool hasOffset)
        {
            return hasOffset ? value + 255 : value;
        }

        private static string FormatHex(byte value)
        {
            return $"{value:X2}h";
        }
    }
}