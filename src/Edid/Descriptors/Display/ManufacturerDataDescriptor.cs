using Edid.Common;

namespace Edid.Descriptors.Display;

public class ManufacturerDataDescriptor : DisplayDescriptor
{
    /// <summary>
    /// Manufacturer Data Descriptor is a type of display descriptor that contains manufacturer-specific data defined by the display manufacturer.
    /// </summary>
    /// <param name="data"></param>
    public ManufacturerDataDescriptor(byte[] data) : base(data)
    {
    }

    public ManufacturerDataDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
    }
}