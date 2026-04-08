namespace Edid.GeneralInfo;

/// <summary>
/// A class to parse ISA (Industry Standard Architecture) Plug and Play Device Identifier.
/// </summary>
public class IsaPnpIdParser
{
    /// <summary>
    /// 3.4.1 Manufacturer ID: 2 Bytes
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static char[] ToIsaPnpId(byte[] data)
    {
        if (data.Length != 2)
        {
            throw new Exception("Insufficient data for ISA PNP ID.");
        }
        var char1 = (char)((data[0] >> 2 & 0x1F) + 64);
        var char2 = (char)((data[0] << 3 & 0x18) + (data[1] >> 5) + 64);
        var char3 = (char)((data[1] & 0x1F) + 64);
        return new[] { char1, char2, char3 };
    }

    /// <summary>
    /// 3.4.1 Manufacturer ID: 2 Bytes
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ToIsaPnpIdString(byte[] data)
    {
        var chars = ToIsaPnpId(data);
        return new string(chars);
    }

    /// <summary>
    /// 3.4.1 Manufacturer ID: 2 Bytes
    /// </summary>
    /// <param name="pnpId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static byte[] FromIsaPnpId(string pnpId)
    {
        if (pnpId.Length != 3)
        {
            throw new Exception("Invalid ISA PNP ID length.");
        }

        byte[] data = new byte[2];
        data[0] = (byte)(pnpId[0] - 64 << 2 | pnpId[1] - 64 >> 3);
        data[1] = (byte)(pnpId[1] - 64 << 5 | pnpId[2] - 64);
        return data;
    }
}