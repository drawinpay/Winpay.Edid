namespace Edid.Services;

public class EdidValidator
{
    /// <summary>
    /// Fixed Header
    /// </summary>
    public static readonly byte[] FixedHeader = { 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00 };

    /// <summary>
    /// Determines whether the specified header matches the expected fixed header sequence.
    /// </summary>
    /// <param name="header">The byte array to validate against the fixed header.</param>
    /// <returns>true if the header matches the fixed header; otherwise, false.</returns>
    private static bool IsValidFixedHeader(byte[] header)
    {
        if (header.Length < FixedHeader.Length)
        {
            return false;
        }

        for (var i = 0; i < FixedHeader.Length; i++)
        {
            if (header[i] != FixedHeader[i])
            {
                return false;
            }
        }

        return true;
    }

    private static byte CalcChecksum(byte[] data, int index, int count)
    {
        byte sum = 0;
        for (int i = index; i < index + count; i++)
        {
            sum += data[i];
        }

        return (byte)(256 - sum);
    }

    public static bool IsValidCheckSum(byte[] data)
    {
        byte checksum = CalcChecksum(data, 0, 127);
        return checksum == data[127];
    }

    public static void ValidBaseEdidBlock(byte[] edidData)
    {
        if (edidData.Length != 128)
        {
            throw new Exception("EDID base block must be 128 bytes.");
        }

        bool isValidHeader = IsValidFixedHeader(edidData);
        if (!isValidHeader)
        {
            throw new Exception("Invalid EDID fixed header.");
        }

        if (!IsValidCheckSum(edidData))
        {
            throw new Exception("Invalid EDID checksum.");
        }
    }
}