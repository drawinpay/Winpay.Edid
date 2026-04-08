using Edid.Common;

namespace Edid.Descriptors.Display;

public class DummyDescriptor : DisplayDescriptor
{
    /// <summary>
    /// DummyDescriptor is a special type of display descriptor that is used as a placeholder for unused descriptor slots in the EDID data.
    /// It contains no meaningful information and is identified by having all bytes from index 5 to 17 set to 0.
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentException"></exception>
    public DummyDescriptor(byte[] data) : base(data)
    {
        for (var i = 5; i < 18; i++)
        {
            if (data[i] != 0)
            {
                throw new ArgumentException("The provided data does not belong to a valid dummy descriptor.", nameof(data));
            }
        }
    }

    public DummyDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
        for (var i = 5; i < 18; i++)
        {
            if (data[byteRange.StartIndex + i] != 0)
            {
                throw new ArgumentException("The provided data does not belong to a valid dummy descriptor.", nameof(data));
            }
        }
    }
}