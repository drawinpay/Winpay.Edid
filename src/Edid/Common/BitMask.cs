namespace Edid.Common
{
    /// <summary>
    /// BitMask struct represents the position of a specific bit within a byte array, defined by its byte index and bit index.
    /// It is used to identify the location of a particular feature or timing in the EDID data structure.
    /// </summary>
    public struct BitMask
    {
        /// <summary>
        /// Gets the zero-based index of the byte within the source data.
        /// </summary>
        public int ByteIndex { get; }

        /// <summary>
        /// Gets the zero-based index of the bit within the underlying data structure.
        /// </summary>
        public int BitIndex { get; }

        /// <summary>
        /// Initializes a new instance of the BitMask struct with the specified byte and bit indices.
        /// </summary>
        /// <param name="byteIndex">The zero-based index of the byte containing the bit.</param>
        /// <param name="bitIndex">The zero-based index of the bit within the byte.</param>
        public BitMask(int byteIndex, int bitIndex)
        {
            ByteIndex = byteIndex;
            BitIndex = bitIndex;
        }
    }
}
