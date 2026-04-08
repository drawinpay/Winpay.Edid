using System.Collections.ObjectModel;
using Edid.Common;
using Edid.Data;
using Edid.Timing;

namespace Edid.Descriptors.Display;

/// <summary>
/// Established Timings III Descriptor represents the third set of established display timings as defined in the EDID specification,
/// including support for a wide range of resolutions and refresh rates,
/// with some timings marked as reduced blanking (RB) for improved compatibility with modern displays.
/// </summary>
public class EstablishedTimingsIIIDescriptor : DisplayDescriptor
{
    /// <summary>
    /// Timings is a read-only collection of EstablishedTiming objects that represent the various established display timings defined in the EDID specification.
    /// </summary>
    public ReadOnlyCollection<EstablishedTiming> Timings { get; }

    /// <summary>
    /// Gets the byte array representing the data for the Established Timings III Descriptor.
    /// </summary>
    public override byte[] Data
    {
        get
        {
            var data = new byte[18];
            Array.Copy(InitialData, data, InitialData.Length);
            for (var i = 6; i <= 11; i++)
            {
                data[i] = 0;
            }

            foreach (EstablishedTiming timing in Timings)
            {
                if (timing.IsEnable)
                {
                    data[timing.BitMask.ByteIndex] |= (byte)(1 << timing.BitMask.BitIndex);
                }
            }

            return data;
        }
    }

    /// <summary>
    /// Creates a new instance of the EstablishedTimingsIIIDescriptor class using the provided byte array as the descriptor data.
    /// </summary>
    /// <param name="data"></param>
    public EstablishedTimingsIIIDescriptor(byte[] data) : this(data, new ByteRange(0, data.Length))
    {
    }

    public EstablishedTimingsIIIDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
        EstablishedTiming[] establishedTimings = new[]
        {
            // Byte 6
            new EstablishedTiming(640, 350, 85, new BitMask(6, 7)),
            new EstablishedTiming(640, 400, 85, new BitMask(6, 6)),
            new EstablishedTiming(720, 400, 85, new BitMask(6, 5)),
            new EstablishedTiming(640, 480, 85, new BitMask(6, 4)),
            new EstablishedTiming(848, 480, 60, new BitMask(6, 3)),
            new EstablishedTiming(800, 600, 85, new BitMask(6, 2)),
            new EstablishedTiming(1024, 768, 85, new BitMask(6, 1)),
            new EstablishedTiming(1152, 864, 75, new BitMask(6, 0)),

            // Byte 7
            new EstablishedTiming(1280, 768, 60, new BitMask(7, 7), true), // RB     Note: (RB) means reduced blanking
            new EstablishedTiming(1280, 768, 60, new BitMask(7, 6)),
            new EstablishedTiming(1280, 768, 75, new BitMask(7, 5)),
            new EstablishedTiming(1280, 768, 85, new BitMask(7, 4)),
            new EstablishedTiming(1280, 960, 60, new BitMask(7, 3)),
            new EstablishedTiming(1280, 960, 85, new BitMask(7, 2)),
            new EstablishedTiming(1280, 1024, 60, new BitMask(7, 1)),
            new EstablishedTiming(1280, 1024, 85, new BitMask(7, 0)),
            // Byte 8
            new EstablishedTiming(1360, 768, 60, new BitMask(8, 7)),
            new EstablishedTiming(1440, 900, 60, new BitMask(8, 6), true), // RB
            new EstablishedTiming(1440, 900, 60, new BitMask(8, 5)),
            new EstablishedTiming(1440, 900, 75, new BitMask(8, 4)),
            new EstablishedTiming(1440, 900, 85, new BitMask(8, 3)),
            new EstablishedTiming(1400, 1050, 60, new BitMask(8, 2), true), // RB
            new EstablishedTiming(1400, 1050, 60, new BitMask(8, 1)),
            new EstablishedTiming(1400, 1050, 75, new BitMask(8, 0)),
            // Byte 9
            new EstablishedTiming(1400, 1050, 85, new BitMask(9, 7)),
            new EstablishedTiming(1680, 1050, 60, new BitMask(9, 6), true), // RB
            new EstablishedTiming(1680, 1050, 60, new BitMask(9, 5)),
            new EstablishedTiming(1680, 1050, 75, new BitMask(9, 4)),
            new EstablishedTiming(1680, 1050, 85, new BitMask(9, 3)),
            new EstablishedTiming(1600, 1200, 60, new BitMask(9, 2)),
            new EstablishedTiming(1600, 1200, 65, new BitMask(9, 1)),
            new EstablishedTiming(1600, 1200, 70, new BitMask(9, 0)),
            // Byte 10
            new EstablishedTiming(1600, 1200, 75, new BitMask(10, 7)),
            new EstablishedTiming(1600, 1200, 85, new BitMask(10, 6)),
            new EstablishedTiming(1792, 1344, 60, new BitMask(10, 5)),
            new EstablishedTiming(1792, 1344, 75, new BitMask(10, 4)),
            new EstablishedTiming(1856, 1392, 60, new BitMask(10, 3)),
            new EstablishedTiming(1856, 1392, 75, new BitMask(10, 2)),
            new EstablishedTiming(1920, 1200, 60, new BitMask(10, 1), true), // RB
            new EstablishedTiming(1920, 1200, 60, new BitMask(10, 0)),
            // Byte 11
            new EstablishedTiming(1920, 1200, 75, new BitMask(11, 7)),
            new EstablishedTiming(1920, 1200, 85, new BitMask(11, 6)),
            new EstablishedTiming(1920, 1440, 60, new BitMask(11, 5)),
            new EstablishedTiming(1920, 1440, 75, new BitMask(11, 4)),
        };

        Timings = new ReadOnlyCollection<EstablishedTiming>(establishedTimings);
        foreach (var timing in Timings)
        {
            timing.IsEnable = BitReader.ReadBitAsBool(timing.BitMask.ByteIndex, timing.BitMask.BitIndex);
        }
    }
}