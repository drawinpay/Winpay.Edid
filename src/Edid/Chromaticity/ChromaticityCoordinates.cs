using Edid.Common;

namespace Edid.Chromaticity
{
    /// <summary>
    /// Chromaticity coordinates.
    /// </summary>
    public class ChromaticityCoordinates : EdidField
    {
        #region Properties

        /// <summary>
        /// Red x value
        /// </summary>
        public double RedX
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(2), (byte)BitReader.ReadBitsAsInt(0, 7, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(2, bytes[1]);
                BitWriter.WriteInt(0, 7, 2, bytes[0]);
            }
        }

        /// <summary>
        /// Red y value
        /// </summary>
        public double RedY
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(3), (byte)BitReader.ReadBitsAsInt(0, 5, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(3, bytes[1]);
                BitWriter.WriteInt(0, 5, 2, bytes[0]);
            }
        }

        /// <summary>
        /// Green x value
        /// </summary>
        public double GreenX
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(4), (byte)BitReader.ReadBitsAsInt(0, 3, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(4, bytes[1]);
                BitWriter.WriteInt(0, 3, 2, bytes[0]);
            }
        }

        /// <summary>
        /// Green y value
        /// </summary>
        public double GreenY
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(5), (byte)BitReader.ReadBitsAsInt(0, 1, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(5, bytes[1]);
                BitWriter.WriteInt(0, 1, 2, bytes[0]);
            }
        }

        /// <summary>
        /// Blue x value
        /// </summary>
        public double BlueX
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(6), (byte)BitReader.ReadBitsAsInt(0 + 1, 7, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(6, bytes[1]);
                BitWriter.WriteInt(0 + 1, 7, 2, bytes[0]);
            }
        }

        /// <summary>
        /// Blue y value
        /// </summary>
        public double BlueY
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(7), (byte)BitReader.ReadBitsAsInt(0 + 1, 5, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(7, bytes[1]);
                BitWriter.WriteInt(0 + 1, 5, 2, bytes[0]);
            }
        }

        /// <summary>
        /// White x value
        /// </summary>
        public double WhiteX
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(8), (byte)BitReader.ReadBitsAsInt(0 + 1, 3, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(8, bytes[1]);
                BitWriter.WriteInt(0 + 1, 3, 2, bytes[0]);
            }
        }

        /// <summary>
        /// White y value
        /// </summary>
        public double WhiteY
        {
            get => ConvertToChromaticityValue(BitReader.ReadByte(9), (byte)BitReader.ReadBitsAsInt(0 + 1, 1, 2));
            set
            {
                byte[] bytes = ConvertToBytes(value);
                BitWriter.WriteByte(9, bytes[1]);
                BitWriter.WriteInt(0 + 1, 1, 2, bytes[0]);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteRange"></param>
        public ChromaticityCoordinates(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public ChromaticityCoordinates(byte[] data) : base(data)
        {
        }

        #endregion

        #region Private Methods

        private double ConvertToChromaticityValue(int highByte, int lowByte)
        {
            int combinedValue = (highByte << 2) + lowByte;
            return combinedValue / 1024.0;
        }

        private byte[] ConvertToBytes(double chromaticityValue)
        {
            var intValue = (int)Math.Round(chromaticityValue * 1024);
            var bytes = new byte[2];
            bytes[0] = (byte)((intValue >> 2) & 0xFF);
            bytes[1] = (byte)(intValue & 0x03);

            return bytes;
        }

        #endregion

    }
}
