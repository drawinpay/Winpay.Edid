using Edid.Common;

namespace Edid.GeneralInfo
{
    /// <summary>
    /// Product Information about the display, including Manufacturer ID, Product Code, Serial Number, Manufacture Date.
    /// </summary>
    public class ProductInfo : EdidField
    {
        #region Properties

        /// <summary>
        /// Manufacturer ID
        /// </summary>
        public string? ManufacturerId
        {
            get
            {
                byte[] manufacturerIdData = BitReader.ReadBytes(0, 2);
                return IsaPnpIdParser.ToIsaPnpIdString(manufacturerIdData);
            }
            set
            {
                if (value?.Length != 3)
                {
                    throw new ArgumentException("Manufacturer ID must be a 3-character string.");
                }

                if (!value.All(char.IsAscii))
                {
                    throw new ArgumentException("Manufacturer ID must contain only ASCII characters.");
                }

                byte[] manufacturerIdData = IsaPnpIdParser.FromIsaPnpId(value);
                BitWriter.WriteBytes(0, manufacturerIdData);
            }
        }

        /// <summary>
        /// Product Code
        /// </summary>
        public ushort ProductCode
        {
            get
            {
                byte[] productCodeData = BitReader.ReadBytes(2, 2);
                return BitConverter.ToUInt16(productCodeData, 0);
            }
            set
            {
                byte[] productCodeData = BitConverter.GetBytes(value);
                BitWriter.WriteBytes(2, productCodeData);
            }
        }

        /// <summary>
        /// Gets a value indicating whether a serial number is present in the data.
        /// "If this field is not used, then enter “00h, 00h, 00h, 00h”"
        /// </summary>
        public bool HasSerialNumber
        {
            get
            {
                byte[] serialNumberData = BitReader.ReadBytes(4, 4);
                return serialNumberData.Any(b => b != 0);
            }
        }

        /// <summary>
        /// The ID serial number is a 32-bit serial number used to differentiate between individual instances of the same display model.
        /// Its use is optional. The range of this serial number is 0 to 4,294,967,295. 
        /// </summary>
        public uint SerialNumber
        {
            get
            {
                byte[] serialNumberData = BitReader.ReadBytes(4, 4);
                return BitConverter.ToUInt32(serialNumberData, 0);
            }
            set
            {
                byte[] serialNumberData = BitConverter.GetBytes(value);
                BitWriter.WriteBytes(4, serialNumberData);
            }
        }

        /// <summary>
        /// Manufacture Date
        /// </summary>
        public EdidTime ManufactureDate
        {
            get
            {
                byte[] data = BitReader.ReadBytes(8, 2);
                if (data[0] >= 0x37 && data[0] <= 0xFE)
                {
                    throw new Exception("Invalid week value.");
                }

                if (data[1] <= 0x0F || data[1] >= 0xFF)
                {
                    throw new Exception("Invalid year value.");
                }

                YearType type;
                if (data[0] == 0xFF)
                {
                    type = YearType.Model;
                }
                else
                {
                    type = YearType.Manufacture;
                }

                int year = 1990 + data[1];
                int week = type == YearType.Manufacture ? data[0] : 0;

                return new EdidTime(type, year, week);
            }
            set
            {
                if (value.Year < 1990 || value.Year > 1990 + 0xFE)
                {
                    throw new ArgumentException("Year must be in range 1990 to 1990 + 0xFE.");
                }

                var data = new byte[2];
                if (value.Type == YearType.Model)
                {
                    data[0] = 0xFF;
                }
                else
                {
                    data[0] = (byte)value.Week;
                }
                data[1] = (byte)(value.Year - 1990);
                BitWriter.WriteBytes(8, data);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ProductInfo class with the specified data and byte range.
        /// </summary>
        /// <param name="data">The product data as a byte array.</param>
        /// <param name="byteRange">The byte range associated with the product data.</param>
        public ProductInfo(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ProductInfo class using the specified byte array.
        /// </summary>
        /// <param name="data">The byte array containing product information data.</param>
        public ProductInfo(byte[] data) : base(data)
        {
        }

        #endregion
    }
}
