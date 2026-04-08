using Edid.Common;
using Edid.Utils;

namespace Edid.Descriptors.Display;

public class GtfSecondaryCurve : EdidField
{
    #region Properties

    public byte StartBreakFrequency
    {
        get => BitReader.ReadByte(12);
        set => BitWriter.WriteByte(12, value);
    }

    public byte C
    {
        get => (byte)(BitReader.ReadByte(13) / 2);
        set => BitWriter.WriteByte(13, (byte)(value * 2));
    }

    public ushort M
    {
        get => IntUtil.ToUint16(BitReader.ReadByte(15), BitReader.ReadByte(14));
        set
        {
            BitWriter.WriteByte(14, (byte)(value & 0xFF));
            BitWriter.WriteByte(15, (byte)(value >> 8));
        }
    }

    public byte K
    {
        get => BitReader.ReadByte(16);
        set => BitWriter.WriteByte(16, value);
    }

    public byte J
    {
        get => (byte)(BitReader.ReadByte(17) / 2);
        set => BitWriter.WriteByte(17, (byte)(value * 2));
    }

    #endregion

    #region Constructors

    public GtfSecondaryCurve(byte[] data) : this(data, new ByteRange(0, data.Length))
    {
    }

    public GtfSecondaryCurve(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
        if (data[10] != 0x02 || data[11] != 0)
        {
            throw new InvalidDataException("Not support GTF Secondary Curve.");
        }

        StartBreakFrequency = data[12];
        C = (byte)(data[13] * 2);
        M = IntUtil.ToUint16(data[15], data[14]);
        K = data[16];
        J = (byte)(data[17] * 2);
    }

    #endregion
}