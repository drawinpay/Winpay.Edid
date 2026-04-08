using Edid.Exceptions;
using System.Text;
using Edid.Common;

namespace Edid.Descriptors.Display
{
    /// <summary>
    /// Represents an EDID string descriptor block
    /// </summary>
    public class StringDescriptor : DisplayDescriptor
    {
        #region Properties

        /// <summary>
        ///     Gets the string data
        /// </summary>
        public string Text
        {
            get
            {
                Valid();
                byte[] bytes = BitReader.ReadBytes(5, 13);
                return Encoding.ASCII.GetString(bytes).Trim();
            }
        }

        #endregion

        #region Constructors

        public StringDescriptor(byte[] data) : base(data)
        {
            DescriptorType type = DescriptorType;
            if (type != DescriptorType.DisplayProductName
               && type != DescriptorType.DisplayProductSerialNumber
               && type != DescriptorType.AlphanumericDataString)
            {
                throw new InvalidDescriptorException("The provided data does not belong to a valid string descriptor.");
            }
        }

        public StringDescriptor(byte[] data, ByteRange dataRange) : base(data, dataRange)
        {
            DescriptorType type = DescriptorType;
            if (type != DescriptorType.DisplayProductName
               && type != DescriptorType.DisplayProductSerialNumber
               && type != DescriptorType.AlphanumericDataString)
            {
                throw new InvalidDescriptorException("The provided data does not belong to a valid string descriptor.");
            }
        }

        #endregion
        
        #region public Methods

        /// <inheritdoc />
        public override string ToString()
        {
            Valid();
            return $"StringDescriptor({DescriptorType}: {Text})";
        }

        #endregion
    }
}
