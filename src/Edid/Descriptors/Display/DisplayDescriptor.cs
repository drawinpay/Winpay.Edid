using Edid.Common;
using Edid.Exceptions;
using Edid.Utils;

namespace Edid.Descriptors.Display
{
    /// <summary>
    /// DisplayDescriptor is an abstract base class for all display descriptor types defined in the EDID specification.
    /// </summary>
    public abstract class DisplayDescriptor : EdidField, IDescriptor
    {
        #region Properties

        protected byte[] InitialData { get; set; }

        /// <summary>
        /// Gets a value indicating whether the descriptor data is valid for a display descriptor.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return BitReader.ReadBytes(0, 3).SequenceEqual(new byte[] { 0x00, 0x00, 0x00 });
            }
        }

        /// <summary>
        /// Gets or sets the type of the display descriptor.
        /// The descriptor type is determined by the value of the fourth byte of the descriptor data.
        /// Valid values are defined in the DescriptorType enum.
        /// Setting the DescriptorType will update the fourth byte of the descriptor data accordingly.
        /// Note that setting DescriptorType to Unknown or DetailedTiming is not allowed for a DisplayDescriptor, as these values are reserved for other descriptor types.
        /// </summary>
        public DescriptorType DescriptorType
        {
            get
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot determine descriptor type from invalid data.");
                }

                return DescriptorParser.ParseDescriptorType(Data, ByteRange);
            }
            set
            {
                if (value == DescriptorType.Unknown || value == DescriptorType.DetailedTiming)
                {
                    throw new ArgumentException("DescriptorType cannot be set to Unknown or DetailedTiming for a DisplayDescriptor.");
                }

                BitWriter.WriteBytes(0, new byte[] { 0x00, 0x00, 0x00 });
                BitWriter.WriteByte(3, (byte)value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the DisplayDescriptor class using the provided byte array as the descriptor data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteRange"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected DisplayDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
            if (byteRange.Length != 18)
            {
                throw new ArgumentException("Display descriptor data must be exactly 18 bytes long.");
            }

            InitialData = data;
        }

        /// <summary>
        /// Creates a new instance of the DisplayDescriptor class using the provided byte array as the descriptor data.
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected DisplayDescriptor(byte[] data) : this(data, new ByteRange(0, 18))
        {
        }

        #endregion

        #region Protected Methods

        protected void Valid()
        {
            if (!IsValid)
            {
                throw new InvalidDescriptorException("The provided data does not belong to a valid display descriptor.");
            }
        }

        #endregion
    }
}
