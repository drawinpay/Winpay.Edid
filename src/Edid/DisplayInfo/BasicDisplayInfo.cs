using Edid.Common;
using Edid.Services;

namespace Edid.DisplayInfo
{
    /// <summary>
    /// Basic Display Parameters & Features
    /// </summary>
    public class BasicDisplayInfo : EdidField
    {
        #region Properties

        /// <summary>
        /// Indicates the type of video input interface(Analog or Digital).
        /// </summary>
        public VideoInputType InputType
        {
            get => BitReader.ReadBitAsBool(0, 7) ? VideoInputType.Digital : VideoInputType.Analog;
            set
            {
                if (value != VideoInputType.Analog && value != VideoInputType.Digital)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "InputType must be Analog or Digital.");
                }

                BitWriter.WriteBitFromBool(0, 7, value == VideoInputType.Digital);
            }
        }

        /// <summary>
        /// Digital Video Input Parameters
        /// </summary>
        public DigitalVideoInput DigitalInput
        {
            get
            {
                if (InputType != VideoInputType.Digital)
                {
                    throw new InvalidOperationException("Cannot get DigitalInput when InputType is not Digital.");
                }

                var colorBitDepth = (DigitalColorBitDepth)BitReader.ReadBitsAsInt(0, 6, 3);
                var videoInterfaceStandard = (DigitalVideoInterface)BitReader.ReadBitsAsInt(0, 3, 4);
                return new DigitalVideoInput(colorBitDepth, videoInterfaceStandard);
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                InputType = VideoInputType.Digital;
                BitWriter.WriteInt(0, 6, 3, (ulong)value.ColorBitDepth);
                BitWriter.WriteInt(0, 3, 4, (ulong)value.VideoInterfaceStandard);
            }
        }

        /// <summary>
        /// Analog Video Input Parameters
        /// </summary>
        public AnalogVideoInput? AnalogInput
        {
            get
            {
                if (InputType != VideoInputType.Analog)
                {
                    return null;
                }

                return new AnalogVideoInput
                {
                    SignalLevelStandard = (AnalogVideoWhiteLevel)BitReader.ReadBitsAsInt(0, 6, 2),
                    IsBlankToBlackExpected = BitReader.ReadBitAsBool(0, 4),
                    IsSeparateSyncSupported = BitReader.ReadBitAsBool(0, 3),
                    IsCompositeSyncSupported = BitReader.ReadBitAsBool(0, 2),
                    IsSyncOnGreenSupported = BitReader.ReadBitAsBool(0, 1),
                    IsVSyncSerratedOnComposite = BitReader.ReadBitAsBool(0, 0)
                };
            }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                InputType = VideoInputType.Analog;
                BitWriter.WriteInt(0, 6, 2, (ulong)value.SignalLevelStandard);
                BitWriter.WriteBitFromBool(0, 4, value.IsBlankToBlackExpected);
                BitWriter.WriteBitFromBool(0, 3, value.IsSeparateSyncSupported);
                BitWriter.WriteBitFromBool(0, 2, value.IsCompositeSyncSupported);
                BitWriter.WriteBitFromBool(0, 1, value.IsSyncOnGreenSupported);
                BitWriter.WriteBitFromBool(0, 0, value.IsVSyncSerratedOnComposite);
            }
        }

        /// <summary>
        /// Data Type
        /// </summary>
        public ScreenSizeType ScreenSizeType
        {
            get
            {
                byte width = BitReader.ReadByte(1);
                byte height = BitReader.ReadByte(2);

                if (width != 0 && height != 0)
                {
                    return ScreenSizeType.WidthAndHeight;
                }

                if (width != 0)
                {
                    return ScreenSizeType.LandscapeAspectRatio;
                }

                if (height != 0)
                {
                    return ScreenSizeType.PortraitAspectRatio;
                }

                return ScreenSizeType.Unknown;
            }
            set
            {
                switch (value)
                {
                    case ScreenSizeType.Unknown:
                        BitWriter.WriteByte(1, 0);
                        BitWriter.WriteByte(2, 0);
                        break;

                    case ScreenSizeType.WidthAndHeight:
                        if (BitReader.ReadByte(1) == 0)
                        {
                            BitWriter.WriteByte(1, 1);
                        }

                        if (BitReader.ReadByte(2) == 0)
                        {
                            BitWriter.WriteByte(2, 1);
                        }
                        break;

                    case ScreenSizeType.LandscapeAspectRatio:
                        if (BitReader.ReadByte(1) == 0)
                        {
                            BitWriter.WriteByte(1, 1);
                        }

                        BitWriter.WriteByte(2, 0);
                        break;

                    case ScreenSizeType.PortraitAspectRatio:
                        BitWriter.WriteByte(1, 0);

                        if (BitReader.ReadByte(2) == 0)
                        {
                            BitWriter.WriteByte(2, 1);
                        }
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        /// <summary>
        /// Width in centimeters
        /// </summary>
        public int PhysicalWidth
        {
            get => ScreenSizeType == ScreenSizeType.WidthAndHeight ? BitReader.ReadByte(1) : 0;
            set
            {
                if (value < 0 || value > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "PhysicalWidth must be in range 0-255.");
                }

                BitWriter.WriteByte(1, (byte)value);
            }
        }

        /// <summary>
        /// Height in centimeters
        /// </summary>
        public int PhysicalHeight
        {
            get => ScreenSizeType == ScreenSizeType.WidthAndHeight ? BitReader.ReadByte(2) : 0;
            set
            {
                if (value < 0 || value > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "PhysicalHeight must be in range 0-255.");
                }

                BitWriter.WriteByte(2, (byte)value);
            }
        }

        /// <summary>
        /// Aspect Ratio
        /// </summary>
        public double AspectRatio
        {
            get
            {
                byte width = BitReader.ReadByte(1);
                byte height = BitReader.ReadByte(2);

                if (width != 0 && height == 0)
                {
                    return Math.Round((width + 99) / 100d, 2);
                }

                if (width == 0 && height != 0)
                {
                    return Math.Round(100d / (height + 99), 2);
                }

                return 0;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "AspectRatio must be greater than 0.");
                }

                switch (ScreenSizeType)
                {
                    case ScreenSizeType.LandscapeAspectRatio:
                        {
                            int encodedValue = (int)Math.Round(value * 100d - 99);
                            if (encodedValue < 1 || encodedValue > byte.MaxValue)
                            {
                                throw new ArgumentOutOfRangeException(nameof(value), "AspectRatio is out of supported landscape range.");
                            }

                            BitWriter.WriteByte(1, (byte)encodedValue);
                            BitWriter.WriteByte(2, 0);
                            break;
                        }

                    case ScreenSizeType.PortraitAspectRatio:
                        {
                            int encodedValue = (int)Math.Round(100d / value - 99);
                            if (encodedValue < 1 || encodedValue > byte.MaxValue)
                            {
                                throw new ArgumentOutOfRangeException(nameof(value), "AspectRatio is out of supported portrait range.");
                            }

                            BitWriter.WriteByte(1, 0);
                            BitWriter.WriteByte(2, (byte)encodedValue);
                            break;
                        }

                    default:
                        throw new InvalidOperationException("Set ScreenSizeType to LandscapeAspectRatio or PortraitAspectRatio before setting AspectRatio.");
                }
            }
        }

        /// <summary>
        /// Display Transfer Characteristics (GAMMA)
        /// </summary>
        public double Gamma
        {
            get => Math.Round((BitReader.ReadByte(3) + 100) / 100d, 2);
            set
            {
                int gammaValue = (int)Math.Round(value * 100d - 100);
                if (gammaValue < 0 || gammaValue > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Gamma is out of supported range.");
                }

                BitWriter.WriteByte(3, (byte)gammaValue);
            }
        }

        /// <summary>
        /// Gets a boolean value indicating if the Standby Mode is supported.
        /// </summary>
        public bool IsStandbySupported
        {
            get => BitReader.ReadBitAsBool(4, 7);
            set => BitWriter.WriteBitFromBool(4, 7, value);
        }

        /// <summary>
        /// Gets a boolean value indicating if the Suspend Mode is supported.
        /// </summary>
        public bool IsSuspendSupported
        {
            get => BitReader.ReadBitAsBool(4, 6);
            set => BitWriter.WriteBitFromBool(4, 6, value);
        }

        /// <summary>
        /// Gets a boolean value indicating if the Active Off = Very Low Power is supported.
        /// </summary>
        public bool IsActiveOffSupported
        {
            get => BitReader.ReadBitAsBool(4, 5);
            set => BitWriter.WriteBitFromBool(4, 5, value);
        }

        /// <summary>
        /// Indicates the display color type of the analog video input interface.
        /// </summary>
        public AnalogDisplayColorType AnalogColorType
        {
            get => (AnalogDisplayColorType)BitReader.ReadBitsAsInt(4, 4, 2);
            set
            {
                if ((ulong)value > 0b11)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "AnalogColorType must fit in 2 bits.");
                }

                BitWriter.WriteInt(4, 4, 2, (ulong)value);
            }
        }

        /// <summary>
        /// Indicates the color format of the digital video input interface.
        /// </summary>
        public DigitalColorFormat DigitalColorFormat
        {
            get => (DigitalColorFormat)BitReader.ReadBitsAsInt(4, 4, 2);
            set
            {
                if ((ulong)value > 0b11)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "DigitalColorFormat must fit in 2 bits.");
                }

                BitWriter.WriteInt(4, 4, 2, (ulong)value);
            }
        }

        /// <summary>
        /// Gets a boolean value indicating if sRGB Standard is the default color space.
        /// </summary>
        public bool IsDefaultSRgbStandard
        {
            get => BitReader.ReadBitAsBool(4, 2);
            set => BitWriter.WriteBitFromBool(4, 2, value);
        }

        /// <summary>
        /// Gets a boolean value indicating if the Preferred Timing Mode includes the native pixel format and preferred refresh rate of the display device.
        /// </summary>
        public bool IsPreferredTimingModeIncludesNativeInfo
        {
            get => BitReader.ReadBitAsBool(4, 1);
            set => BitWriter.WriteBitFromBool(4, 1, value);
        }

        /// <summary>
        /// Gets a boolean value indicating if the display is continuous frequency.
        /// </summary>
        public bool IsDisplayContinuousFrequency
        {
            get => BitReader.ReadBitAsBool(4, 0);
            set => BitWriter.WriteBitFromBool(4, 0, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteRange"></param>
        public BasicDisplayInfo(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public BasicDisplayInfo(byte[] data) : base(data, BaseEdidDataSplitter.GetBasicDisplayInfoBytesRange())
        {
        }

        #endregion
    }
}
