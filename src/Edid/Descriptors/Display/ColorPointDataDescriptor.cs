using Edid.Common;

namespace Edid.Descriptors.Display;

public class ColorPointDataDescriptor : DisplayDescriptor
{
    public override byte[] Data
    {
        get
        {
            Valid();

            var data = new byte[18];
            Array.Copy(InitialData, data, 18);

            List<ColorPoint> colorPoints = ColorPoints;
            for (var i = 0; i < 2; i++)
            {
                if (i < colorPoints.Count)
                {
                    ColorPoint colorPoint = colorPoints[i];
                    Array.Copy(colorPoint.Data, 0, data, 5 + i * 5, 5);
                }
                else
                {
                    Array.Copy(new byte[5], 0, data, 5 + i * 5, 5);
                }
            }

            return data;
        }
    }

    public List<ColorPoint> ColorPoints
    {
        get
        {
            Valid();

            var colorPoints = new List<ColorPoint>();
            for (var i = 5; i < 17; i += 5)
            {
                byte[] data = BitReader.ReadBytes(i, 5);
                var colorPoint = new ColorPoint(data);
                if (colorPoint.IsUsed)
                {
                    colorPoints.Add(colorPoint);
                }
            }

            return colorPoints;
        }
    }

    public ColorPointDataDescriptor(byte[] data) : base(data)
    {
    }

    public ColorPointDataDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
        if (data[3] != (byte)DescriptorType.ColorPointData)
        {
            throw new InvalidDataException("Not support Color Point Data Descriptor.");
        }
    }
}