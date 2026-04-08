using Edid.Common;
using System.Collections.ObjectModel;

namespace Edid.Timing
{
    /// <summary>
    /// Represents the first set of established display timings as defined in EDID, including support for various
    /// resolutions and refresh rates.
    /// </summary>
    public class EstablishedTimings1 : EdidField
    {
        #region Properties

        /// <summary>
        /// Timings is a read-only collection of EstablishedTiming objects that represent the various established display timings defined in the EDID specification.
        /// </summary>
        public ReadOnlyCollection<EstablishedTiming> Timings { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the EstablishedTimings1 class with the specified data byte.
        /// </summary>
        /// <param name="data">The byte value representing established timings data.</param>
        /// <param name="byteRange">Byte range</param>
        public EstablishedTimings1(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
            var establishedTimings = new[]
            {
                new EstablishedTiming(800, 600, 60, new BitMask(0, 0)),
                new EstablishedTiming(800, 600, 56, new BitMask(0, 1)),
                new EstablishedTiming(640, 480, 75, new BitMask(0, 2)),
                new EstablishedTiming(640, 480, 72, new BitMask(0, 3)),
                new EstablishedTiming(640, 480, 67, new BitMask(0, 4)),
                new EstablishedTiming(640, 480, 60, new BitMask(0, 5)),
                new EstablishedTiming(720, 400, 88, new BitMask(0, 6)),
                new EstablishedTiming(720, 400, 70, new BitMask(0, 7)),
            };

            Timings = new ReadOnlyCollection<EstablishedTiming>(establishedTimings);
            foreach (EstablishedTiming timing in Timings)
            {
                timing.IsEnable = BitReader.ReadBitAsBool(0, timing.BitMask.BitIndex);
                timing.PropertyChanged += Timing_PropertyChanged;
            }
        }

        #endregion

        #region Private Methods

        private void Timing_PropertyChanged(object? sender, EventArgs e)
        {
            byte data = 0;
            foreach (EstablishedTiming timing in Timings)
            {
                if (timing.IsEnable)
                {
                    data |= (byte)(1 << timing.BitMask.BitIndex);
                }
            }

            BitWriter.WriteByte(0, data);
        }

        #endregion
    }
}
