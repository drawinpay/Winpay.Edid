using System.Collections.ObjectModel;
using Edid.Common;
using Edid.Timing;
using Edid.Utils;

namespace Edid.Descriptors.Display;

public class CvtSupport : EdidField
{
    #region Properties

    public byte Version
    {
        get => BitReader.ReadByte(11);
        set
        {
            if ((value >> 1) == 0)
            {
                throw new InvalidDataException("The major version shall greater than 0.");
            }

            BitWriter.WriteByte(11, value);
        }
    }

    public double AdditionalPixelClockPrecision
    {
        get => BitReader.ReadBitsAsInt(12, 7, 6) * 0.25;
        set
        {
            var precision = (byte)(value / 0.25);
            BitWriter.WriteInt(12, precision, 7, 6);
        }
    }

    public double MaxPixelClock => BitReader.ReadByte(9) * 10 - AdditionalPixelClockPrecision;

    public bool IsNoLimitOnHorizontalPixels => BitReader.ReadByte(13) == 0;

    public int MaxHorizontalActivePixels
    {
        get
        {
            if (IsNoLimitOnHorizontalPixels)
            {
                return ushort.MaxValue;
            }

            byte lsb = BitReader.ReadByte(13);
            byte msb = BitReader.ReadBitsAsByte(12, 1, 2);
            return IntUtil.ToUint16(msb, lsb) * 8;
        }
        set
        {
            var lsb = (byte)(value & 0xFF);
            var msb = (byte)((value >> 8) & 0x03);
            BitWriter.WriteByte(13, lsb);
            BitWriter.WriteInt(12, msb, 1, 2);
        }
    }

    public ReadOnlyCollection<AspectRatio> SupportedAspectRatios { get; }

    public AspectRatio PreferredAspectRatio
    {
        get
        {
            byte aspectRatioType = BitReader.ReadBitsAsByte(15, 7, 3);
            if (aspectRatioType > 0b100)
            {
                throw new InvalidDataException("The aspect ratio type shall be in range of 0 - 4.");
            }
            return SupportedAspectRatios[aspectRatioType];
        }
    }

    public bool IsSupportStandardCvtBlanking
    {
        get => BitReader.ReadBitAsBool(15, 3);
        set => BitWriter.WriteBit(15, 3, (ulong)(value ? 1 : 0));
    }

    public bool IsSupportReducedCvtBlanking
    {
        get => BitReader.ReadBitAsBool(15, 4);
        set => BitWriter.WriteBit(15, 4, (ulong)(value ? 1 : 0));
    }

    public bool HorizontalShrink
    {
        get => BitReader.ReadBitAsBool(16, 7);
        set => BitWriter.WriteBit(16, 7, (ulong)(value ? 1 : 0));
    }

    public bool HorizontalStretch
    {
        get => BitReader.ReadBitAsBool(16, 6);
        set => BitWriter.WriteBit(16, 6, (ulong)(value ? 1 : 0));
    }

    public bool VerticalShrink
    {
        get => BitReader.ReadBitAsBool(16, 5);
        set => BitWriter.WriteBit(16, 5, (ulong)(value ? 1 : 0));
    }

    public bool VerticalStretch
    {
        get => BitReader.ReadBitAsBool(16, 4);
        set => BitWriter.WriteBit(16, 4, (ulong)(value ? 1 : 0));
    }

    public byte PreferredVerticalRefreshRate
    {
        get => BitReader.ReadByte(17);
        set => BitWriter.WriteByte(17, value);
    }

    private readonly AspectRatio[] _aspectRatioTypes = new AspectRatio[]
    {
        new(4, 3, new BitMask(14, 7)),
        new(16, 9, new BitMask(14, 6)),
        new(16, 10, new BitMask(14, 5)),
        new(5, 4, new BitMask(14, 4)),
        new(15, 9, new BitMask(14, 3)),
    };

    #endregion

    public CvtSupport(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {
        if (data[10] != 0x04)
        {
            throw new InvalidDataException("Not support CVT.");
        }

        SupportedAspectRatios = new ReadOnlyCollection<AspectRatio>(_aspectRatioTypes);
        foreach (AspectRatio supportedAspectRatio in SupportedAspectRatios)
        {
            supportedAspectRatio.IsEnable = BitReader.ReadBitAsBool(supportedAspectRatio.BitMask.ByteIndex, supportedAspectRatio.BitMask.BitIndex);
        }
    }
}