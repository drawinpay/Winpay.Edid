using Edid.Common;

namespace Edid.Descriptors.Display;

public class DisplayColorManagementDescriptor : DisplayDescriptor
{
    public int RedA3
    {
        get => GetColorCoefficient(6);
        set => SetColorCoefficient(6, value);
    }

    public int RedA2
    {
        get => GetColorCoefficient(8);
        set => SetColorCoefficient(8, value);
    }

    public int GreenA3
    {
        get => GetColorCoefficient(10);
        set => SetColorCoefficient(10, value);
    }

    public int GreenA2
    {
        get => GetColorCoefficient(12);
        set => SetColorCoefficient(12, value);
    }

    public int BlueA3
    {
        get => GetColorCoefficient(14);
        set => SetColorCoefficient(14, value);
    }

    public int BlueA2
    {
        get => GetColorCoefficient(16);
        set => SetColorCoefficient(16, value);
    }

    public int Version
    {
        get
        {
            if (BitReader.ReadByte(5) != 0x03)
            {
                throw new InvalidDataException("Invalid version data.");
            }

            return 0x03;
        }
    }

    public DisplayColorManagementDescriptor(byte[] data) : base(data) { }

    public DisplayColorManagementDescriptor(byte[] data, ByteRange dataRange) : base(data, dataRange) { }

    private int GetColorCoefficient(int byteIndex)
    {
        return BitReader.ReadByte(byteIndex) + (BitReader.ReadByte(byteIndex + 1) << 8);
    }

    private void SetColorCoefficient(int byteIndex, int value)
    {
        byte lsb = (byte)(value & 0xFF);
        byte msb = (byte)((value >> 8) * 0xFF);
        BitWriter.WriteByte(byteIndex, lsb);
        BitWriter.WriteByte(byteIndex + 1, msb);
    }

    public override string ToString()
    {
        return $"DisplayColorManagementDescriptor(Version={Version}, RedA3={RedA3}, RedA2={RedA2}, GreenA3={GreenA3}, GreenA2={GreenA2}, BlueA3={BlueA3}, BlueA2={BlueA2})";
    }
}