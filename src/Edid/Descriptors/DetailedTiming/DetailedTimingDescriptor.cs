using Edid.Common;
using Edid.Exceptions;

namespace Edid.Descriptors.DetailedTiming
{
    /// <summary>
    /// Represents an EDID detailed timing descriptor block
    /// </summary>
    public class DetailedTimingDescriptor : EdidField, IDescriptor
    {
        #region Fields

        private readonly bool _isDigital;

        #endregion

        #region Properties

        /// <summary>
        /// Determines the type of the descriptor based on the content of the data. For a valid detailed timing descriptor, this will always return DescriptorType.DetailedTiming.
        /// </summary>
        public DescriptorType DescriptorType => DescriptorType.DetailedTiming;

        /// <summary>
        /// Gets a value indicating whether the current data is valid.
        /// </summary>
        public bool IsValid => BitReader.ReadBitsAsInt(0, 0, 2 * 8) != 0;

        /// <summary>
        /// Gets or sets the pixel clock frequency in hertz. The value must be a multiple of 10,000 and between 10,000 and 655,350,000.
        /// Stored at bytes 0 and 1 as an unsigned integer in units of 10 kHz. A value of 0 indicates that the descriptor is not valid.
        /// </summary>
        public ulong PixelClock
        {
            get
            {
                Valid();
                ulong result = (ulong)(BitReader.ReadByte(0) + (BitReader.ReadByte(1) << 8)) * 10000;
                return result;
            }
            set
            {
                if (value % 10000 != 0 || value / 10000 > 65535)
                {
                    throw new ArgumentException("Pixel clock must be a multiple of 10,000 and between 0.01 and 655.35 MHz.");
                }

                var storedValue = (int)(value / 10000);
                var lsb = (byte)(storedValue & 0xFF);
                var msb = (byte)(storedValue >> 8 & 0xFF);
                BitWriter.WriteByte(0, lsb);
                BitWriter.WriteByte(1, msb);
            }
        }

        /// <summary>
        /// Gets or sets the value of horizontal addressable video in pixels.
        /// Stored at bytes 2(lower 8 bits) and 4 (bits 7-4) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint HorizontalAddressableVideoPixels
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(2);
                var most = (uint)BitReader.ReadBitsAsInt(4, 7, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(2, (byte)(value & 0xFF));
                BitWriter.WriteInt(4, 7, 4, (byte)(value >> 8 & 0x0F));
            }
        }

        /// <summary>
        /// Gets or sets the value of horizontal blanking in pixels.
        /// Stored at bytes 3(lower 8 bits) and 4 (bits 3-0) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint HorizontalBlankingPixels
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(3);
                var most = (uint)BitReader.ReadBitsAsInt(4, 3, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(3, (byte)(value & 0xFF));
                BitWriter.WriteInt(4, 3, 4, (byte)(value >> 8 & 0x0F));
            }
        }

        /// <summary>
        /// Gets or sets the value of vertical addressable video lines as specified in the descriptor.
        /// Stored at bytes 5(lower 8 bits) and 7 (bits 7-4) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint VerticalAddressableVideoLines
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(5);
                var most = (uint)BitReader.ReadBitsAsInt(7, 7, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(5, (byte)(value & 0xFF));
                BitWriter.WriteInt(7, 7, 4, (byte)(value >> 8 & 0x0F));
            }
        }

        /// <summary>
        /// Gets or sets the number of vertical blanking lines as specified in the descriptor.
        /// Stored at bytes 6(lower 8 bits) and 7 (bits 3-0) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint VerticalBlankingLines
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(6);
                var most = (uint)BitReader.ReadBitsAsInt(7, 3, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(6, (byte)(value & 0xFF));
                BitWriter.WriteInt(7, 3, 4, (byte)(value >> 8 & 0x0F));
            }
        }

        /// <summary>
        /// Gets or sets the value of horizontal front porch in pixels.
        /// Stored at bytes 8(lower 8 bits) and 11 (bits 7-6) as an unsigned integer. The value must be between 0 and 1023.
        /// </summary>
        public uint HorizontalFrontPorchPixels
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(8);
                var most = (uint)BitReader.ReadBitsAsInt(11, 7, 2);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(8, (byte)(value & 0xFF));
                BitWriter.WriteInt(11, 7, 2, (byte)(value >> 8 & 0x03));
            }
        }

        /// <summary>
        /// Gets or sets the horizontal sync pulse with in pixels.
        /// Stored at bytes 9(lower 8 bits) and 11 (bits 5-4) as an unsigned integer. The value must be between 0 and 1023.
        /// </summary>
        public uint HorizontalSyncPulseWidth
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(9);
                var most = (uint)BitReader.ReadBitsAsInt(11, 5, 2);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(9, (byte)(value & 0xFF));
                BitWriter.WriteInt(11, 5, 2, (byte)(value >> 8 & 0x03));
            }
        }

        /// <summary>
        /// Gets or sets the value of vertical front porch in lines.
        /// Stored at bytes 10(lower 4 bits) and 11 (bits 3-2) as an unsigned integer. The value must be between 0 and 63.
        /// </summary>
        public uint VerticalFrontPorchLines
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadBitsAsInt(10, 7, 4);
                var most = (uint)BitReader.ReadBitsAsInt(11, 3, 2);
                return most << 4 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteInt(10, 7, 4, (byte)(value & 0x0F));
                BitWriter.WriteInt(11, 3, 2, (byte)(value >> 4 & 0x03));
            }
        }

        /// <summary>
        /// Gets or sets the vertical sync pulse width in lines.
        /// Stored at bytes 10(lower 4 bits) and 11 (bits 1-0) as an unsigned integer. The value must be between 0 and 63.
        /// </summary>
        public uint VerticalSyncPulseWidth
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadBitsAsInt(10, 3, 4);
                var most = (uint)BitReader.ReadBitsAsInt(11, 1, 2);
                return most << 4 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteInt(10, 3, 4, (byte)(value & 0x0F));
                BitWriter.WriteInt(11, 1, 2, (byte)(value >> 4 & 0x03));
            }
        }

        /// <summary>
        /// Gets or sets the horizontal display size, mm (0–4095 mm, 161 in)
        /// Stored at bytes 12(lower 8 bits) and 14 (bits 7-4) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint HorizontalAddressableVideoImageSize
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(12);
                var most = (uint)BitReader.ReadBitsAsInt(14, 7, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(12, (byte)(value & 0xFF));
                BitWriter.WriteInt(14, 7, 4, (byte)(value >> 8 & 0x0F));
            }
        }

        /// <summary>
        /// Gets or sets the vertical display size, mm
        /// Stored at bytes 13(lower 8 bits) and 14 (bits 3-0) as an unsigned integer. The value must be between 0 and 4095.
        /// </summary>
        public uint VerticalAddressableVideoImageSize
        {
            get
            {
                Valid();
                var least = (uint)BitReader.ReadByte(13);
                var most = (uint)BitReader.ReadBitsAsInt(14, 3, 4);
                return most << 8 | least;
            }
            set
            {
                Valid();
                BitWriter.WriteByte(13, (byte)(value & 0xFF));
                BitWriter.WriteInt(14, 3, 4, (byte)(value >> 8 & 0x0F));
            }
        }
        /// <summary>
        /// Gets or sets the horizontal border pixels.
        /// Stored at byte 15 as an unsigned integer. The value must be between 0 and 255.
        /// The value represents the number of pixels in the horizontal border on each side.
        /// </summary>
        public uint HorizontalBorderPixels
        {
            get
            {
                Valid();
                return BitReader.ReadByte(15);
            }
            set
            {
                Valid();
                BitWriter.WriteByte(15, (byte)(value & 0xFF));
            }
        }

        /// <summary>
        /// Gets or sets the value of vertical border in lines.
        /// Stored at byte 16 as an unsigned integer. The value must be between 0 and 255.
        /// </summary>
        public uint VerticalBorderLines
        {
            get
            {
                Valid();
                return BitReader.ReadByte(16);
            }
            set
            {
                Valid();
                BitWriter.WriteByte(16, (byte)(value & 0xFF));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the video is interlaced.
        /// Stored at byte 17, bit 7. A value of 1 indicates interlaced video, and a value of 0 indicates non-interlaced video.
        /// </summary>
        public bool IsInterlaced
        {
            get
            {
                Valid();
                return BitReader.ReadBitAsBool(17, 7);
            }
            set
            {
                Valid();
                BitWriter.WriteBit(17, 7, (ulong)(value ? 1 : 0));
            }
        }

        /// <summary>
        /// Gets or sets the stereo viewing mode supported by the display. A value of 0 indicates that the display does not support stereo viewing.
        /// Stored at byte 17, bits 6-5 and bit 0.
        /// </summary>
        public StereoViewingMode StereoMode
        {
            get
            {
                Valid();
                var most = (uint)BitReader.ReadBitsAsInt(17, 6, 2);
                if (most == 0)
                {
                    return StereoViewingMode.NoStereo;
                }

                int least = BitReader.ReadBit(17, 0);
                return (StereoViewingMode)((most << 1) + least);
            }
            set
            {
                Valid();
                var intValue = (uint)value;
                uint most = intValue >> 1 & 0x03;
                uint least = intValue & 0x01;
                BitWriter.WriteInt(17, 6, 2, most);
                BitWriter.WriteBit(17, 0, least);
            }
        }

        /// <summary>
        /// Gets or sets the type of analog sync signal.
        /// Stored at byte 17, bits 4-3.
        /// </summary>
        public AnalogSyncType AnalogSyncType
        {
            get
            {
                Valid();
                ValidAnalog();

                var syncType = (AnalogSyncType)BitReader.ReadBit(17, 3);
                return syncType;
            }
            set
            {
                Valid();
                BitWriter.WriteInt(17, 4, 2, (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the vertical sync is serrated (HSync during VSync) for analog signals.
        /// Stored at byte 17, bit 2. A value of 1 indicates that the vertical sync is serrated, and a value of 0 indicates that it is not serrated.
        /// </summary>
        public bool IsAnalogSyncWithSerrations
        {
            get
            {
                Valid();
                ValidAnalog();
                return BitReader.ReadBitAsBool(17, 2);
            }
            set
            {
                Valid();
                ValidAnalog();
                BitWriter.WriteBit(17, 2, (ulong)(value ? 1 : 0));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sync is on all 3 RGB lines (else green only) for analog signals.
        /// Stored at byte 17, bit 1. A value of 1 indicates that the sync is on all RGB lines, and a value of 0 indicates that the sync is on the green line only.
        /// </summary>
        public bool IsAnalogSyncOnAllRgbVideoSignals
        {
            get
            {
                Valid();
                ValidAnalog();
                return BitReader.ReadBitAsBool(17, 1);
            }
            set
            {
                Valid();
                ValidAnalog();
                BitWriter.WriteBit(17, 1, (ulong)(value ? 1 : 0));
            }
        }

        /// <summary>
        /// Gets or sets the type of digital sync signal.
        /// Stored at byte 17, bits 4-3. 
        /// </summary>
        public DigitalSyncType DigitalSyncType
        {
            get
            {
                Valid();
                ValidDigital();
                var syncType = (DigitalSyncType)BitReader.ReadBit(17, 3);
                return syncType;
            }
            set
            {
                Valid();
                BitWriter.WriteInt(17, 4, 2, 2ul + (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the vertical sync is serrated (HSync during VSync) for digital signals.
        /// Stored at byte 17, bit 2. A value of 1 indicates that the vertical sync is serrated, and a value of 0 indicates that it is not serrated.
        /// </summary>
        public bool IsDigitalSyncWithSerrations
        {
            get
            {
                Valid();
                ValidDigital();
                if (DigitalSyncType == DigitalSyncType.DigitalSeparateSync)
                {
                    throw new Exception("Serrations are not applicable for digital separate sync.");
                }
                return BitReader.ReadBitAsBool(17, 2);
            }
            set
            {
                Valid();
                ValidDigital();
                if (DigitalSyncType == DigitalSyncType.DigitalSeparateSync)
                {
                    throw new Exception("Serrations are not applicable for digital separate sync.");
                }
                BitWriter.WriteBit(17, 2, (ulong)(value ? 1 : 0));
            }
        }

        /// <summary>
        /// Gets or sets the digital display's vertical sync polarity.
        /// Stored at byte 17, bit 2. A value of 1 indicates positive polarity, and a value of 0 indicates negative polarity.
        /// </summary>
        public DigitalSyncPolarity DigitalVerticalSyncPolarity
        {
            get
            {
                Valid();
                ValidDigital();
                if (DigitalSyncType != DigitalSyncType.DigitalSeparateSync)
                {
                    throw new Exception("Vertical sync polarity is only applicable for digital separate sync.");
                }

                return (DigitalSyncPolarity)BitReader.ReadBitsAsInt(17, 2, 1);
            }
            set
            {
                Valid();
                ValidDigital();
                if (DigitalSyncType != DigitalSyncType.DigitalSeparateSync)
                {
                    throw new Exception("Vertical sync polarity is only applicable for digital separate sync.");
                }

                BitWriter.WriteInt(17, 2, 1, (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets the digital display's horizontal sync polarity.
        /// Stored at byte 17, bit 1. A value of 1 indicates positive polarity, and a value of 0 indicates negative polarity.
        /// </summary>
        public DigitalSyncPolarity DigitalHorizontalSyncPolarity
        {
            get
            {
                Valid();
                ValidDigital();
                return (DigitalSyncPolarity)BitReader.ReadBitsAsInt(17, 1, 1);
            }
            set
            {
                Valid();
                ValidDigital();
                BitWriter.WriteInt(17, 1, 1, (byte)value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DetailedTimingDescriptor class using the specified data and signal type.
        /// </summary>
        /// <param name="data">A byte array containing the detailed timing descriptor data. Must be exactly 18 bytes long.</param>
        /// <param name="byteRange"></param>
        /// <param name="isDigital">true if the timing descriptor is for a digital display; otherwise, false.</param>
        /// <exception cref="ArgumentException">Thrown when the data array is not exactly 18 bytes long.</exception>
        public DetailedTimingDescriptor(byte[] data, ByteRange byteRange, bool isDigital) : base(data, byteRange)
        {
            DescriptorType descriptorType = DescriptorParser.ParseDescriptorType(data, byteRange);
            if (descriptorType != DescriptorType.DetailedTiming)
            {
                throw new InvalidDescriptorException("The provided data does not belong to a detailed timing descriptor.");
            }

            _isDigital = isDigital;
            ValidSignalType(isDigital);
        }

        #endregion

        #region Private Methods

        private void Valid()
        {
            if (!IsValid)
            {
                throw new InvalidDescriptorException("The provided data does not belong to this descriptor.");
            }
        }

        private void ValidSignalType(bool isDigital)
        {
            if (isDigital)
            {
                if (!BitReader.ReadBitAsBool(17, 4))
                {
                    throw new InvalidDescriptorException("The provided data does not belong to a digital signal descriptor.");
                }
            }
            else
            {
                if (BitReader.ReadBitAsBool(17, 4))
                {
                    //throw new InvalidDescriptorException("The provided data does not belong to an analog signal descriptor.");
                }
            }
        }

        private void ValidAnalog()
        {
            if (_isDigital)
            {
                throw new Exception("The device is not analog.");
            }
        }

        private void ValidDigital()
        {
            if (!_isDigital)
            {
                throw new Exception("The device is not digital.");
            }
        }

        #endregion
    }
}
