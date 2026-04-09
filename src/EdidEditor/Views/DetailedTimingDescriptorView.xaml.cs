using System.Windows.Controls;
using Edid.Descriptors.DetailedTiming;

namespace EdidEditor.Views
{
    public partial class DetailedTimingDescriptorView : UserControl
    {
        public DetailedTimingDescriptorView()
        {
            InitializeComponent();
        }

        public void SetData(DetailedTimingDescriptor descriptor, bool isDigital)
        {
            TtbPixelClock.Text = (descriptor.PixelClock / 1000).ToString();
            TtbHorizontalAddressableVideoPixels.Text = descriptor.HorizontalAddressableVideoPixels.ToString();
            TtbVerticalAddressableVideoLines.Text = descriptor.VerticalAddressableVideoLines.ToString();
            TtbHorizontalBlankingPixels.Text = descriptor.HorizontalBlankingPixels.ToString();
            TtbVerticalBlankingLines.Text = descriptor.VerticalBlankingLines.ToString();
            TtbHorizontalFrontPorchPixels.Text = descriptor.HorizontalFrontPorchPixels.ToString();
            TtbVerticalFrontPorchLines.Text = descriptor.VerticalFrontPorchLines.ToString();
            TtbHorizontalSyncPulseWidth.Text = descriptor.HorizontalSyncPulseWidth.ToString();
            TtbVerticalSyncPulseWidth.Text = descriptor.VerticalSyncPulseWidth.ToString();
            TtbHorizontalAddressableVideoImageSize.Text = descriptor.HorizontalAddressableVideoImageSize.ToString();
            TtbVerticalAddressableVideoImageSize.Text = descriptor.VerticalAddressableVideoImageSize.ToString();
            TtbHorizontalBorderPixels.Text = descriptor.HorizontalBorderPixels.ToString();
            TtbVerticalBorderLines.Text = descriptor.VerticalBorderLines.ToString();
            ChkInterlaced.IsChecked = descriptor.IsInterlaced;

            ResetStereoOptions();
            switch (descriptor.StereoMode)
            {
                case StereoViewingMode.NoStereo:
                    RdbStereoNoStereo.IsChecked = true;
                    break;
                case StereoViewingMode.FieldSequentialRightImage:
                    RdbStereoFieldSequentialRightImage.IsChecked = true;
                    break;
                case StereoViewingMode.FieldSequentialLeftImage:
                    RdbStereoFieldSequentialLeftImage.IsChecked = true;
                    break;
                case StereoViewingMode.Stereo2WayInterleavedRightImage:
                    RdbStereo2WayInterleavedRightImage.IsChecked = true;
                    break;
                case StereoViewingMode.Stereo2WayInterleavedLeftImage:
                    RdbStereo2WayInterleavedLeftImage.IsChecked = true;
                    break;
                case StereoViewingMode.Stereo4WayInterleaved:
                    RdbStereo4WayInterleaved.IsChecked = true;
                    break;
                case StereoViewingMode.SideBySide:
                    RdbStereoSideBySide.IsChecked = true;
                    break;
            }

            ResetSyncOptions();
            if (isDigital)
            {
                RdbSyncDigital.IsChecked = true;

                if (descriptor.DigitalSyncType == DigitalSyncType.DigitalCompositeSync)
                {
                    RdbDigitalCompositeSync.IsChecked = true;
                    RdbDigitalWithSerrations.IsChecked = descriptor.IsDigitalSyncWithSerrations;
                    RdbDigitalWithoutSerrations.IsChecked = !descriptor.IsDigitalSyncWithSerrations;
                }
                else
                {
                    RdbDigitalSeparateSync.IsChecked = true;
                    ChkDigitalVerticalSyncPositive.IsChecked = descriptor.DigitalVerticalSyncPolarity == DigitalSyncPolarity.Positive;
                    ChkDigitalHorizontalSyncPositive.IsChecked = descriptor.DigitalHorizontalSyncPolarity == DigitalSyncPolarity.Positive;
                }
            }
            else
            {
                RdbSyncAnalog.IsChecked = true;
                RdbAnalogCompositeSync.IsChecked = descriptor.AnalogSyncType == AnalogSyncType.AnalogCompositeSync;
                RdbAnalogBipolarCompositeSync.IsChecked = descriptor.AnalogSyncType == AnalogSyncType.BipolarAnalogCompositeSync;
                RdbAnalogWithSerrations.IsChecked = descriptor.IsAnalogSyncWithSerrations;
                RdbAnalogWithoutSerrations.IsChecked = !descriptor.IsAnalogSyncWithSerrations;
                RdbAnalogSyncOnAllRgbVideoSignals.IsChecked = descriptor.IsAnalogSyncOnAllRgbVideoSignals;
                RdbAnalogSyncOnGreenOnly.IsChecked = !descriptor.IsAnalogSyncOnAllRgbVideoSignals;
            }
        }

        private static bool IsDigital(DetailedTimingDescriptor descriptor)
        {
            int index = descriptor.ByteRange.StartIndex + 17;
            return (descriptor.Data[index] & 0x10) != 0;
        }

        private void ResetStereoOptions()
        {
            RdbStereoNoStereo.IsChecked = false;
            RdbStereoFieldSequentialRightImage.IsChecked = false;
            RdbStereoFieldSequentialLeftImage.IsChecked = false;
            RdbStereo2WayInterleavedRightImage.IsChecked = false;
            RdbStereo2WayInterleavedLeftImage.IsChecked = false;
            RdbStereo4WayInterleaved.IsChecked = false;
            RdbStereoSideBySide.IsChecked = false;
        }

        private void ResetSyncOptions()
        {
            RdbSyncAnalog.IsChecked = false;
            RdbSyncDigital.IsChecked = false;

            RdbAnalogCompositeSync.IsChecked = false;
            RdbAnalogBipolarCompositeSync.IsChecked = false;
            RdbAnalogWithoutSerrations.IsChecked = false;
            RdbAnalogWithSerrations.IsChecked = false;
            RdbAnalogSyncOnGreenOnly.IsChecked = false;
            RdbAnalogSyncOnAllRgbVideoSignals.IsChecked = false;

            RdbDigitalCompositeSync.IsChecked = false;
            RdbDigitalWithoutSerrations.IsChecked = false;
            RdbDigitalWithSerrations.IsChecked = false;
            RdbDigitalSeparateSync.IsChecked = false;
            ChkDigitalVerticalSyncPositive.IsChecked = false;
            ChkDigitalHorizontalSyncPositive.IsChecked = false;
        }
    }
}