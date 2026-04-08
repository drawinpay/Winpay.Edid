using Edid.Common;

namespace Edid.GeneralInfo
{
    /// <summary>
    /// EDID Version
    /// </summary>
    public class EdidVersion : EdidField
    {
        #region Properties

        /// <summary>
        /// The version number of the EDID structure.
        /// </summary>
        public int Version
        {
            get => BitReader.ReadByte(0);
            set
            {
                if (value < 0 || value > 0xFF)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Version must be in range 0-255.");
                }

                BitWriter.WriteByte(0, (byte)value);
            }
        }

        /// <summary>
        /// The revision number of the EDID structure.
        /// </summary>
        public int Revision
        {
            get => BitReader.ReadByte(1);
            set
            {
                if (value < 0 || value > 0xFF)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Revision must be in range 0-255.");
                }

                BitWriter.WriteByte(1, (byte)value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the EdidVersion class using the specified data and byte range.
        /// </summary>
        /// <param name="data">The byte array containing EDID data.</param>
        /// <param name="byteRange">The range of bytes representing the EDID version.</param>
        public EdidVersion(byte[] data, ByteRange byteRange) : base(data, byteRange)
        {
        }

        /// <summary>
        /// Initializes a new instance of the EdidVersion class using the specified EDID data.
        /// </summary>
        /// <param name="data">A byte array containing the EDID data.</param>
        public EdidVersion(byte[] data) : base(data)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a string that represents the EDID version.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Version}.{Revision}";
        }

        #endregion
    }
}
