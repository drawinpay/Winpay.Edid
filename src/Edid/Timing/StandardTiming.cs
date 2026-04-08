using Edid.Common;

namespace Edid.Timing
{
    /// <summary>
    /// Standard Timing
    /// </summary>
    public class StandardTiming : EdidField
    {
        #region Fields

        private readonly AspectRatio[] _aspectRatios;

        #endregion

        #region Properties

        /// <summary>
        /// Horizontal addressable pixels, calculated from the first byte of the standard timing data.
        /// The value is derived by taking the byte value, adding 31, and then multiplying by 8.
        /// This results in a range of horizontal resolutions that can be represented, starting from 256 pixels (when the byte value is 0) up to 2288 pixels (when the byte value is 255).
        /// The horizontal resolution must be a multiple of 8, as specified in the EDID standard.
        /// </summary>
        public uint Width
        {
            get => (uint)((BitReader.ReadByte(0) + 31) * 8);
            set
            {
                if (value < 256 || value > 2288 || value % 8 != 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Horizontal addressable pixels must be between 256 and 2288, and a multiple of 8.");
                }

                var storedValue = (byte)(value / 8 - 31);
                BitWriter.WriteByte(0, storedValue);
            }
        }

        /// <summary>
        /// Gets or sets the aspect ratio associated with the current byte range.
        /// </summary>
        public AspectRatio AspectRatio
        {
            get
            {
                var aspectRatioValue = BitReader.ReadBitsAsInt(1, 7, 2);
                return _aspectRatios[aspectRatioValue];
            }
            set
            {
                int aspectRatioIndex = -1;
                for (var i = 0; i < _aspectRatios.Length; i++)
                {
                    if (Math.Abs(_aspectRatios[i].Horizontal - value.Horizontal) < 1e-6
                        && Math.Abs(_aspectRatios[i].Vertical - value.Vertical) < 1e-6)
                    {
                        aspectRatioIndex = i;
                        break;
                    }
                }

                if (aspectRatioIndex == -1)
                {
                    throw new ArgumentException("Invalid aspect ratio.", nameof(value));
                }
                BitWriter.WriteInt(1, 7, 2, (byte)aspectRatioIndex);
            }
        }

        /// <summary>
        /// Gets or sets the frequency in hertz (Hz).
        /// </summary>
        /// <remarks>Valid values range from 60 to 123 Hz. Setting a value outside this range throws an
        /// ArgumentOutOfRangeException.</remarks>
        public uint Frequency
        {
            get => BitReader.ReadBitsAsByte(1, 5, 6) + 60u;
            set
            {
                var storedValue = (byte)(value - 60);
                if (storedValue > 0b00111111)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Frequency must be between 60 and 123 Hz.");
                }

                BitWriter.WriteInt(1, 5, 6, storedValue);
            }
        }

        /// <summary>
        /// Gets the height calculated based on the width and aspect ratio.
        /// </summary>
        public uint Height => (uint)((double)Width / AspectRatio.Horizontal * AspectRatio.Vertical);

        /// <summary>
        /// Gets or sets a value indicating whether the associated bytes are marked as unused.
        /// </summary>
        /// <remarks>Setting this property to false is not supported and will throw an
        /// exception.</remarks>
        public bool IsUnused
        {
            get => BitReader.ReadBytes(0, 2).SequenceEqual(new byte[] { 1, 1 });
            set
            {
                if (!value)
                {
                    throw new ArgumentException("IsUnused can only be set to true.", nameof(IsUnused));
                }

                BitWriter.WriteBytes(0, new byte[] { 1, 1 });
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the StandardTiming class using the specified 2-byte data array and byte range.
        /// </summary>
        /// <param name="data">A 2-byte array containing the standard timing data.</param>
        /// <param name="byteRange">The range of bytes within the data array to use.</param>
        /// <exception cref="ArgumentException">Thrown when data is null or not exactly 2 bytes in length.</exception>
        public StandardTiming(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {

            _aspectRatios = new[]
            {
                new AspectRatio(16, 10),
                new AspectRatio(4, 3),
                new AspectRatio(5, 4),
                new AspectRatio(16, 9)
            };
        }

        /// <summary>
        /// Initializes a new instance of the StandardTiming class with default values.
        /// </summary>
        public StandardTiming() : this(new byte[] { 1, 1 }, new ByteRange(0, 2))
        {
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            if (IsUnused)
            {
                return "Unused";
            }

            return $"{Width}x{Height} @ {Frequency}Hz ({AspectRatio})";
        }

        #endregion
    }
}
