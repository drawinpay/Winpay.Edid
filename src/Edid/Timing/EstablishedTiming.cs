using Edid.Common;

namespace Edid.Timing
{
    /// <summary>
    /// Common Timing
    /// </summary>
    public class EstablishedTiming
    {
        private bool _isEnable;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event EventHandler? PropertyChanged;

        /// <summary>
        /// Gets the width in pixels.
        /// </summary>
        public uint Width { get; }

        /// <summary>
        /// Gets the height in pixels.
        /// </summary>
        public uint Height { get; }

        /// <summary>
        /// Gets the frequency value in hertz.
        /// </summary>
        public uint Frequency { get; }

        /// <summary>
        /// Gets a value indicating whether reduced blanking is enabled.
        /// </summary>
        public bool IsReducedBlanking { get; }

        /// <summary>
        /// The bit mask of current timing in byte data.
        /// </summary>
        public BitMask BitMask { get; }

        /// <summary>
        /// Indicates whether the feature is enabled.
        /// </summary>
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                PropertyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initializes a new instance of the EstablishedTiming class with the specified display parameters.
        /// </summary>
        /// <param name="width">The width of the display in pixels.</param>
        /// <param name="height">The height of the display in pixels.</param>
        /// <param name="frequency">The refresh frequency of the display in hertz.</param>
        /// <param name="bitMask"></param>
        /// <param name="isReducedBlanking"></param>
        public EstablishedTiming(uint width, uint height, uint frequency, BitMask bitMask, bool isReducedBlanking = false)
        {
            Width = width;
            Height = height;
            Frequency = frequency;
            BitMask = bitMask;
            IsReducedBlanking = isReducedBlanking;
        }

        /// <summary>
        /// Returns a string representation of the display resolution and refresh rate.
        /// </summary>
        /// <returns>A string formatted as "Width x Height @ Frequency Hz".</returns>
        public override string ToString()
        {
            return $"{Width} x {Height} @ {Frequency} Hz, Reduced Blanking:{IsReducedBlanking} ";
        }
    }
}
