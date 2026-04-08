using Edid.Common;

namespace Edid.Descriptors.Display
{
    public class DisplayRangeLimitsDescriptor : DisplayDescriptor
    {
        #region Fields

        private readonly ByteRange _byteRange;
        private readonly bool _isContinuousFrequency;

        #endregion

        #region Properties

        public int MinVerticalRate
        {
            get
            {
                long offsetFlat = BitReader.ReadBitsAsInt(4, 1, 2);
                if (offsetFlat == 0b11)
                {
                    return BitReader.ReadByte(5) + 255;
                }

                return BitReader.ReadByte(5);
            }
            set
            {
                long offsetFlat = BitReader.ReadBitsAsInt(4, 1, 2);
                if (offsetFlat == 0b11)
                {
                    if (value < 256 || value > 510)
                    {
                        const string message = "The min vertical rate must in range of 256 - 510.";
                        throw new ArgumentOutOfRangeException(paramName: message);
                    }
                    BitWriter.WriteByte(5, (byte)(value - 255));
                    return;
                }

                if (value < 1 || value > 255)
                {
                    const string message = "The min vertical rate must in range of 1 - 255.";
                    throw new ArgumentOutOfRangeException(paramName: message);
                }
                BitWriter.WriteByte(5, (byte)value);
            }
        }

        public int MaxVerticalRate
        {
            get
            {
                bool offsetFlat = BitReader.ReadBitAsBool(4, 1);
                if (offsetFlat)
                {
                    return BitReader.ReadByte(6) + 255;
                }

                return BitReader.ReadByte(6);
            }
            set
            {
                bool offsetFlat = BitReader.ReadBitAsBool(4, 1);
                if (offsetFlat)
                {
                    if (value < 256 || value > 510)
                    {
                        const string message = "The max vertical rate must in range of 256 - 510.";
                        throw new ArgumentOutOfRangeException(paramName: message);
                    }
                    BitWriter.WriteByte(6, (byte)(value - 255));
                    return;
                }

                if (value < 1 || value > 255)
                {
                    const string message = "The max vertical rate must in range of 1 - 255.";
                    throw new ArgumentOutOfRangeException(paramName: message);
                }
                BitWriter.WriteByte(6, (byte)value);
            }
        }

        public int MinHorizontalRate
        {
            get
            {
                long offsetFlat = BitReader.ReadBitsAsInt(4, 3, 2);
                if (offsetFlat == 0b11)
                {
                    return BitReader.ReadByte(7) + 255;
                }

                return BitReader.ReadByte(7);
            }
            set
            {
                long offsetFlat = BitReader.ReadBitsAsInt(4, 3, 2);
                if (offsetFlat == 0b11)
                {
                    if (value < 256 || value > 510)
                    {
                        const string message = "The min horizontal rate must in range of 256 - 510.";
                        throw new ArgumentOutOfRangeException(paramName: message);
                    }
                    BitWriter.WriteByte(7, (byte)(value - 255));
                    return;
                }

                if (value < 1 || value > 255)
                {
                    const string message = "The min horizontal rate must in range of 1 - 255.";
                    throw new ArgumentOutOfRangeException(paramName: message);
                }
                BitWriter.WriteByte(7, (byte)value);
            }
        }

        public int MaxHorizontalRate
        {
            get
            {
                bool offsetFlag = BitReader.ReadBitAsBool(4, 1);
                if (offsetFlag)
                {
                    return BitReader.ReadByte(8) + 255;
                }

                return BitReader.ReadByte(8);
            }
            set
            {
                bool offsetFlag = BitReader.ReadBitAsBool(4, 1);
                if (offsetFlag)
                {
                    if (value < 256 || value > 510)
                    {
                        const string message = "The max horizontal rate must in range of 256 - 510.";
                        throw new ArgumentOutOfRangeException(paramName: message);
                    }
                    BitWriter.WriteByte(8, (byte)(value - 255));
                    return;
                }

                if (value < 1 || value > 255)
                {
                    const string message = "The max horizontal rate must in range of 1 - 255.";
                    throw new ArgumentOutOfRangeException(paramName: message);
                }
                BitWriter.WriteByte(8, (byte)value);
            }
        }

        public int MaxPixelClock
        {
            get => BitReader.ReadByte(9) * 10;
            set => BitWriter.WriteByte(9, (byte)Math.Round(value / 10d));
        }

        public VideoTimingSupport VideoTimingSupportFlag
        {
            get
            {
                byte flag = BitReader.ReadByte(10);
                if (flag == 1)
                {
                    return VideoTimingSupport.RangLimitOnly;
                }

                if (!_isContinuousFrequency)
                {
                    throw new InvalidDataException("When video timing support flag is not 0x01, then bit 0 of the Feature Support Byte at address 18h shall not be set to 0 ");
                }

                return (VideoTimingSupport)flag;
            }
            set
            {
                var flag = (byte)value;
                if (!_isContinuousFrequency && flag != 1)
                {
                    throw new InvalidDataException("When the Feature Support Byte at address 18h is set to 0, then video support flag shall only be set to 1.");
                }

                BitWriter.WriteByte(10, flag);
            }
        }

        public GtfSecondaryCurve GtfSecondaryCurve
        {
            get
            {
                if (VideoTimingSupportFlag != VideoTimingSupport.SecondaryGtf)
                {
                    throw new InvalidDataException("Not support GTF Secondary Curve.");
                }

                return new GtfSecondaryCurve(Data);
            }
        }

        public CvtSupport CVTSupport
        {
            get
            {
                if (VideoTimingSupportFlag != VideoTimingSupport.Cvt)
                {
                    throw new InvalidDataException("Not support CVT.");
                }

                return new CvtSupport(Data, _byteRange);
            }
        }

        #endregion

        #region Constructors

        public DisplayRangeLimitsDescriptor(byte[] data, ByteRange byteRange, bool isContinuousFrequency) : base(data, byteRange)
        {
            _byteRange = byteRange;
            _isContinuousFrequency = isContinuousFrequency;
        }

        public DisplayRangeLimitsDescriptor(byte[] data, bool isContinuousFrequency) : base(data)
        {
            _byteRange = new ByteRange(0, data.Length);
            _isContinuousFrequency = isContinuousFrequency;
        }

        #endregion
    }
}
