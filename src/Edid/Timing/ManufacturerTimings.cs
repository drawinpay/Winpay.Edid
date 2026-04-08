using Edid.Common;
using System.Collections.ObjectModel;

namespace Edid.Timing
{
    /// <summary>
    /// Represents manufacturer-specific display timings as defined in EDID, including custom
    /// resolutions and refresh rates specific to particular display manufacturers.
    /// </summary>

    public class ManufacturerTimings : EdidField
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
        public ManufacturerTimings(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
            var establishedTimings = new[]
            {
                new EstablishedTiming(1152, 870, 75, new BitMask(0, 7)),
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
