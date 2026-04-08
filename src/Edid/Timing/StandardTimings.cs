using System.Collections.ObjectModel;
using Edid.Common;

namespace Edid.Timing
{
    /// <summary>
    /// Standard Timings Parser
    /// </summary>
    public class StandardTimings : EdidField
    {
        #region Properties

        /// <summary>
        /// Timings is a read-only collection of StandardTiming objects that represent the various standard display timings defined in the EDID specification.
        /// Each StandardTiming object encapsulates information about a specific standard timing, including its horizontal resolution, aspect ratio, and refresh rate.
        /// The collection provides a convenient way to access and manage the standard timings supported by a display device as defined in its EDID data.
        /// </summary>
        public ReadOnlyCollection<StandardTiming> Timings { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="standardTimingBytes"></param>
        /// <param name="byteRange"></param>
        public StandardTimings(byte[] standardTimingBytes, ByteRange byteRange) : base(standardTimingBytes, byteRange)
        {
            if (byteRange.Length != 16)
            {
                throw new ArgumentException("Byte range must be 16 bytes long.", nameof(byteRange));
            }

            var timings = new StandardTiming[8];
            for (var i = 0; i < 8; i++)
            {
                timings[i] = new StandardTiming(standardTimingBytes, new ByteRange(byteRange.StartIndex + i * 2, 2));
            }
            Timings = new ReadOnlyCollection<StandardTiming>(timings);
        }

        #endregion
    }
}
