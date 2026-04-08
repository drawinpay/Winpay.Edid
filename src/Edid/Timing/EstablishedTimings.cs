using Edid.Common;

namespace Edid.Timing
{
    /// <summary>
    /// Represents established display timings, including standard and manufacturer-specific timing information.
    /// </summary>
    public class EstablishedTimings : EdidField
    {
        /// <summary>
        /// Gets the established timing information.
        /// </summary>
        public EstablishedTimings1 EstablishedTimings1 { get; }

        /// <summary>
        /// Gets the established timing information for the second instance.
        /// </summary>
        public EstablishedTimings2 EstablishedTimings2 { get; }

        /// <summary>
        /// Gets the manufacturer-specific timing information.
        /// </summary>
        public ManufacturerTimings ManufacturerTimings { get; }

        /// <summary>
        /// Initializes a new instance of the EstablishedTimings class using the specified byte array.
        /// </summary>
        /// <param name="byteData">A three-byte array containing established timings data.</param>
        /// <param name="byteRange"></param>
        /// <exception cref="ArgumentException">Thrown when byteData is not exactly three bytes long.</exception>
        public EstablishedTimings(byte[] byteData, ByteRange byteRange) : base(byteData, byteRange)
        {
            EstablishedTimings1 = new EstablishedTimings1(byteData, new ByteRange(byteRange.StartIndex, 1));
            EstablishedTimings2 = new EstablishedTimings2(byteData, new ByteRange(byteRange.StartIndex + 1, 1));
            ManufacturerTimings = new ManufacturerTimings(byteData, new ByteRange(byteRange.StartIndex + 2, 1));
        }

        /// <summary>
        /// Initializes a new instance of the EstablishedTimings class using the specified byte array.
        /// </summary>
        /// <param name="byteData">The byte array containing timing data.</param>
        public EstablishedTimings(byte[] byteData) : this(byteData, new ByteRange(0, byteData.Length))
        {
        }
    }
}
