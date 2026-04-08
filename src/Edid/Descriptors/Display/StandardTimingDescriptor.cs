using Edid.Common;
using Edid.Exceptions;
using Edid.Timing;

namespace Edid.Descriptors.Display
{
    /// <summary>
    /// Standard Timing Descriptor: Contains up to 6 standard timing entries, each represented by a 2-byte code that specifies the horizontal resolution, aspect ratio, and refresh rate of a supported video mode.
    /// The descriptor can include fewer than 6 entries if some of the timing codes are set to 0x01, which indicates an unused entry.
    /// </summary>
    public class StandardTimingDescriptor : DisplayDescriptor
    {
        public StandardTimingDescriptor(byte[] data) : base(data)
        {
            DescriptorType type = DescriptorType;
            if (type != DescriptorType.StandardTiming)
            {
                throw new InvalidDescriptorException("The provided data does not belong to a valid standard timing descriptor.");
            }
        }

        public StandardTimingDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {

        }

        /// <summary>
        /// Gets or sets the standard timing entries contained in the descriptor.
        /// Each entry is represented by a StandardTiming object that can be constructed from the corresponding 2-byte code in the descriptor data.
        /// </summary>
        public IEnumerable<StandardTiming> Timings
        {
            get
            {
                Valid();

                for (var i = 5; i < 17; i += 2)
                {
                    var standardTiming = new StandardTiming(Data, new ByteRange(i, 2));
                    if (!standardTiming.IsUnused)
                    {
                        yield return standardTiming;
                    }
                }
            }
            set
            {
                Valid();

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Timings cannot be set to null.");
                }

                List<StandardTiming> timingsList = value.ToList();
                if (timingsList.Count > 6)
                {
                    throw new ArgumentException("Timings cannot contain more than 6 entries.", nameof(value));
                }

                for (var i = 0; i < 6; i++)
                {
                    if (i < timingsList.Count)
                    {
                        StandardTiming timing = timingsList[i];
                        BitWriter.WriteBytes(5 + i * 2, timing.Data);
                    }
                    else
                    {
                        // Set remaining entries to unused
                        BitWriter.WriteBytes(5 + i * 2, new byte[] { 1, 1 });
                    }
                }
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            Valid();
            return $"StandardTimingDescriptor(StandardTiming[{string.Concat(Timings.Select(p => p.ToString()), "----")}])";
        }
    }
}
