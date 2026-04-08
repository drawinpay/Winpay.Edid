using Edid.Common;

namespace Edid.Services
{
    /// <summary>
    /// Provides methods for retrieving byte ranges of various EDID (Extended Display Identification Data) fields according to the EDID specification.
    /// </summary>
    public class BaseEdidDataSplitter
    {
        /// <summary>
        /// 3.3 EDID Header: 8 Bytes (00h-07h)
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetHeaderBytesRange()
        {
            return new ByteRange(0x00, 8);
        }

        /// <summary>
        /// Gets the byte range representing the general information section.
        /// </summary>
        /// <returns>A ByteRange starting at offset 0x08 with a length of 12 bytes.</returns>
        public static ByteRange GetGeneralInfoBytesRange()
        {
            return new ByteRange(0x08, 12);
        }

        /// <summary>
        /// Gets the byte range containing the vendor product information.
        /// </summary>
        /// <returns>A ByteRange representing the start offset and length of the vendor product information.</returns>
        public static ByteRange GetVendorProductInfoBytesRange()
        {
            return new ByteRange(0x08, 10);
        }

        /// <summary>
        /// 3.4.1 ID Manufacturer Name: 2 Bytes
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetManufacturerIdBytesRange()
        {
            return new ByteRange(0x08, 2);
        }

        /// <summary>
        /// 3.4.2 ID Product Code: 2 Bytes 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetProductCodeBytesRange()
        {
            return new ByteRange(0x0A, 2);
        }

        /// <summary>
        /// 3.4.3 ID Serial Number: 4 Bytes 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetSerialNumberBytesRange()
        {
            return new ByteRange(0x0C, 4);
        }

        /// <summary>
        /// 3.4.4 Week and Year of Manufacture or Model Year: 2 Bytes
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetWeekYearBytesRange()
        {
            return new ByteRange(0x10, 2);
        }

        /// <summary>
        /// 3.5 EDID Structure Version & Revision: 2 Bytes 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetVersionBytesRange()
        {
            return new ByteRange(0x12, 2);
        }

        /// <summary>
        /// 3.6 Basic Display Parameters and Features: 5 Bytes(14h-18h)
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetBasicDisplayInfoBytesRange()
        {
            return new ByteRange(0x14, 5);
        }

        /// <summary>
        /// 3.6.1 Video Input Definition: 1 Byte 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetVideoInputParametersBytesRange()
        {
            return new ByteRange(0x14, 1);
        }

        /// <summary>
        /// 3.6.2 Horizontal and Vertical Screen Size or Aspect Ratio: 2 Bytes
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetScreenSizeBytesRange()
        {
            return new ByteRange(0x15, 2);
        }

        /// <summary>
        /// 3.6.3 Display Transfer Characteristics (GAMMA): 1 Byte
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetGammaBytesRange()
        {
            return new ByteRange(0x17, 1);
        }

        /// <summary>
        /// 3.6.4 Feature Support: 1 Byte 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetFeatureSupportBytesRange()
        {
            return new ByteRange(0x18, 1);
        }

        /// <summary>
        /// 3.7 Display x, y Chromaticity Coordinates: 10 Bytes 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetChromaticityCoordinatesBytesRange()
        {
            return new ByteRange(0x19, 10);
        }

        /// <summary>
        /// 3.8 Established Timings I & II: 3 bytes  
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetEstablishedTimingsBytesRange()
        {
            return new ByteRange(0x23, 3);
        }

        /// <summary>
        /// 3.9 Standard Timings: 16 Bytes 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetStandardTimingsBytesRange()
        {
            return new ByteRange(0x26, 16);
        }

        /// <summary>
        /// 3.10 The 18 Byte Descriptor 
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetDescriptorBlockBytesRange(int blockIndex)
        {
            return new ByteRange(0x36 + blockIndex * 18, 18);
        }
        
        /// <summary>
        /// 3.11 EXTENSION Flag and Checksum
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetExtensionFlagBytesRange()
        {
            return new ByteRange(0x7E, 1);
        }

        /// <summary>
        /// 3.11 EXTENSION Flag and Checksum
        /// </summary>
        /// <returns></returns>
        public static ByteRange GetChecksumBytesRange()
        {
            return new ByteRange(0x7F, 1);
        }
    }
}
