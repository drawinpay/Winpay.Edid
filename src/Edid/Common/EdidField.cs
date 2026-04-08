using Edid.Utils;

namespace Edid.Common
{
    /// <summary>
    /// EDID Field represents a specific section of the EDID data, containing the raw byte data and its corresponding byte range within the EDID structure.
    /// </summary>
    public class EdidField
    {
        #region Properties

        /// <summary>
        /// Gets the binary data associated with the object.
        /// </summary>
        public virtual byte[] Data { get; }

        /// <summary>
        /// Gets the range of bytes represented by the object.
        /// </summary>
        public ByteRange ByteRange { get; }

        /// <summary>
        /// Provides access to the underlying bit-level reader.
        /// </summary>
        protected BitReader BitReader { get; }

        /// <summary>
        /// Provides access to the underlying BitWriter for writing bits to the output stream.
        /// </summary>
        protected BitWriter BitWriter { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the EdidField class with the specified data and byte range.
        /// </summary>
        /// <param name="data">The byte array containing the field data.</param>
        /// <param name="byteRange">The range of bytes representing the field within the data.</param>
        public EdidField(byte[] data, ByteRange byteRange)
        {
            if (byteRange.StartIndex + byteRange.Length > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteRange), "Byte range exceeds the length of the data array.");
            }

            Data = data;
            ByteRange = byteRange;
            BitReader = new BitReader(data, byteRange.StartIndex);
            BitWriter = new BitWriter(data, byteRange.StartIndex);
        }

        /// <summary>
        /// Initializes a new instance of the EdidField class using the specified data buffer.
        /// </summary>
        /// <param name="data">The byte array containing the EDID data.</param>
        public EdidField(byte[] data) : this(data, new ByteRange(0, data.Length))
        {
        }

        #endregion
    }
}
