namespace Edid.Utils
{
    public class IntUtil
    {
        public static ushort ToUint16(byte msb, byte lsb)
        {
            return (ushort)((msb << 8) | lsb);
        }
    }
}
