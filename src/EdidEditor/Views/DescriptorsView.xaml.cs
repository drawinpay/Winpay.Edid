using System.Windows;
using System.Windows.Controls;
using Edid.Data;
using Edid.Descriptors;
using Edid.Descriptors.DetailedTiming;
using Edid.Descriptors.Display;

namespace EdidEditor.Views
{
    public partial class DescriptorsView : UserControl
    {
        private IDescriptor[]? descriptors;

        public DescriptorsView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo)
        {
            descriptors = edidInfo.Descriptors;
            ShowDescriptor(0);
        }

        public void ShowDescriptor(int index)
        {
            ContentDescriptor.Content = BuildDescriptorContent(descriptors, index);
        }

        private static UIElement BuildDescriptorContent(IDescriptor[]? descriptors, int index)
        {
            if (descriptors == null || index < 0 || descriptors.Length <= index || descriptors[index] == null)
            {
                return new TextBlock
                {
                    Margin = new Thickness(16),
                    Text = "No descriptor."
                };
            }

            return BuildDescriptorView(descriptors[index]);
        }

        private static UserControl BuildDescriptorView(IDescriptor descriptor)
        {
            if (descriptor is DetailedTimingDescriptor detailedTimingDescriptor)
            {
                var detailedTimingView = new DetailedTimingDescriptorView();
                detailedTimingView.SetData(detailedTimingDescriptor);
                return detailedTimingView;
            }

            if (descriptor is DisplayRangeLimitsDescriptor displayRangeLimitsDescriptor)
            {
                var displayRangeLimitsView = new DisplayRangeLimitsDescriptorView();
                displayRangeLimitsView.SetData(displayRangeLimitsDescriptor);
                return displayRangeLimitsView;
            }

            if (descriptor is StringDescriptor stringDescriptor)
            {
                if (descriptor.DescriptorType == DescriptorType.DisplayProductSerialNumber)
                {
                    var serialNumberView = new SerialNumberDescriptorView();
                    serialNumberView.SetData(stringDescriptor);
                    return serialNumberView;
                }

                if (descriptor.DescriptorType == DescriptorType.DisplayProductName)
                {
                    var displayProductNameView = new DisplayProductNameDescriptorView();
                    displayProductNameView.SetData(stringDescriptor);
                    return displayProductNameView;
                }
            }

            var summaryView = new DescriptorSummaryView();
            summaryView.SetData(descriptor);
            return summaryView;
        }
    }
}