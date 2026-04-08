using System.Globalization;
using Edid.Utils;

namespace Edid.Descriptors.Display;

public class ColorPoint
{
    #region Fields

    private readonly BitReader _bitReader;
    private readonly BitWriter _bitWriter;

    #endregion

    #region Properties

    public byte[] Data { get; }

    public bool IsUsed => Index != 0;

    public byte Index
    {
        get => _bitReader.ReadByte(0);
        set => _bitWriter.WriteByte(0, value);
    }

    public double WhiteX
    {
        get
        {
            byte msb = _bitReader.ReadByte(2);
            var lsb = (int)_bitReader.ReadBitsAsInt(1, 3, 2);
            return ConvertBitsToChromaticityValue(msb, lsb);
        }
        set
        {
            byte[] bytes = ConvertChromaticityValueToBits(value);
            _bitWriter.WriteByte(2, bytes[0]);
            _bitWriter.WriteInt(1, 3, bytes[1], 2);
        }
    }

    public double WhiteY
    {
        get
        {
            byte msb = _bitReader.ReadByte(3);
            var lsb = (int)_bitReader.ReadBitsAsInt(1, 1, 2);
            return ConvertBitsToChromaticityValue(msb, lsb);
        }
        set
        {
            byte[] bytes = ConvertChromaticityValueToBits(value);
            _bitWriter.WriteByte(3, bytes[0]);
            _bitWriter.WriteInt(1, 1, bytes[1], 2);
        }
    }

    public double Gamma
    {
        get
        {
            byte gammaByte = _bitReader.ReadByte(4);
            return Math.Round((gammaByte + 100) / 100d, 2);
        }
        set
        {
            var gammaByte = (byte)Math.Round(value * 100 - 100);
            _bitWriter.WriteByte(4, gammaByte);
        }
    }

    public bool HasGamma => _bitReader.ReadByte(4) != 0xFF;

    #endregion

    #region Constructors

    public ColorPoint(byte[] data)
    {
        Data = data;

        _bitReader = new BitReader(data);
        _bitWriter = new BitWriter(data);
    }

    #endregion

    #region Private Methods

    private double ConvertBitsToChromaticityValue(int highByte, int lowByte)
    {
        int combinedValue = (highByte << 2) + lowByte;
        return Math.Round(combinedValue / 1024.0, 3);
    }

    public byte[] ConvertChromaticityValueToBits(double chromaticityValue)
    {
        var combinedValue = (int)Math.Round(chromaticityValue * 1024);
        var highByte = (byte)(combinedValue >> 2);
        var lowByte = (byte)(combinedValue & 0x03);
        return new[] { highByte, lowByte };
    }

    public override string ToString()
    {
        if (!IsUsed)
        {
            return "Unused Color Point";
        }
        return $"Color Point {Index}: WhiteX={WhiteX}, WhiteY={WhiteY}, Gamma={(HasGamma ? Gamma.ToString(CultureInfo.InvariantCulture) : "N/A")}";
    }

    #endregion
}