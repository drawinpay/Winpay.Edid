using System.Linq;
using System.Windows.Controls;
using Edid.Common;
using Edid.Descriptors;
using Edid.Descriptors.Display;
using Edid.Utils;

namespace EdidEditor.Views
{
    public partial class DescriptorSummaryView : UserControl
    {
        public DescriptorSummaryView()
        {
            InitializeComponent();
        }

        public void SetData(IDescriptor descriptor)
        {
            TtbDescriptorType.Text = descriptor.DescriptorType.ToString();
            TtbIsValid.Text = descriptor.IsValid ? "Yes" : "No";
            TtbDescription.Text = GetDescription(descriptor);
            TtbRawData.Text = GetRawData(descriptor);
        }

        private static string GetDescription(IDescriptor descriptor)
        {
            if (descriptor is StringDescriptor stringDescriptor)
            {
                return stringDescriptor.Text;
            }

            return "No specialized view available for this descriptor type.";
        }

        private static string GetRawData(IDescriptor descriptor)
        {
            if (descriptor is not EdidField edidField)
            {
                return string.Empty;
            }

            byte[] data = edidField.Data
                .Skip(edidField.ByteRange.StartIndex)
                .Take(edidField.ByteRange.Length)
                .ToArray();

            return data.BytesToHexString(" ", false);
        }
    }
}