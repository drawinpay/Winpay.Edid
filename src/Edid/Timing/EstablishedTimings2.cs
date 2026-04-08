using Edid.Common;
using System.Collections.ObjectModel;

namespace Edid.Timing
{
    /// <summary>
    /// Represents the second set of established display timings as defined in EDID, including support for various
    /// resolutions and refresh rates.
    /// </summary>

    public class EstablishedTimings2 : EdidField
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
        public EstablishedTimings2(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
            var establishedTimings = new[]
            {
                new EstablishedTiming(800, 600, 72,   new BitMask(0, 7)),
                new EstablishedTiming(800, 600, 75,   new BitMask(0, 6)),
                new EstablishedTiming(832, 624, 75,   new BitMask(0, 5)),
                new EstablishedTiming(1024, 768, 87,  new BitMask(0, 4)),
                new EstablishedTiming(1024, 768, 60,  new BitMask(0, 3)),
                new EstablishedTiming(1024, 768, 70,  new BitMask(0, 2)),
                new EstablishedTiming(1024, 768, 75,  new BitMask(0, 1)),
                new EstablishedTiming(1280, 1024, 75, new BitMask(0, 0)),
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
