namespace Edid.Common
{
    /// <summary>
    /// Represents a range of bytes in the EDID data, defined by a starting index and a length.
    /// </summary>
    public struct ByteRange
    {
        /// <summary>
        /// Gets or sets the starting index of the byte range in the EDID data.
        /// </summary>
        public int StartIndex { get; }
        /// <summary>
        /// Gets or sets the length of the byte range, indicating how many bytes are included in this range.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Initializes a new instance of the DataByteRange class with the specified starting index and length.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        public ByteRange(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }
    }
}
