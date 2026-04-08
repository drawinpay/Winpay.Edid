namespace Edid.Utils
{
    /// <summary>
    /// Provides functionality for writing individual bits to a byte array.
    /// </summary>
    public class BitWriter
    {
        #region Properties

        /// <summary>
        /// Gets the binary data associated with the object.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Gets the zero-based byte offset within the underlying data source.
        /// </summary>
        public int ByteOffset { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BitWriter class using the specified byte array.
        /// </summary>
        /// <param name="data">The byte array to use for writing bits.</param>
        public BitWriter(byte[] data)
        {
            Data = data;
            ByteOffset = 0;
        }

        public BitWriter(byte[] data, int byteOffset)
        {
            if (byteOffset < 0 || byteOffset >= data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteOffset), "byteOffset is out of range.");
            }

            Data = data;
            ByteOffset = byteOffset;
        }

        #endregion

        #region Private Methods

        private static byte GetBitMask(int bitCounts)
        {
            return bitCounts switch
            {
                1 => 0b1,
                2 => 0b11,
                3 => 0b111,
                4 => 0b1111,
                5 => 0b11111,
                6 => 0b111111,
                7 => 0b1111111,
                8 => 0b11111111,
                _ => throw new ArgumentOutOfRangeException(nameof(bitCounts), "bitCounts must be in range 1-8.")
            };
        }

        private void WriteBitInternal(int byteIndex, int bitIndex, ulong value)
        {
            var mask = (byte)(1 << bitIndex);
            if (value == 1)
            {
                Data[byteIndex] |= mask;
            }
            else
            {
                Data[byteIndex] &= (byte)~mask;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Writes a single bit to the specified byte and bit index.
        /// </summary>
        /// <param name="byteIndex"></param>
        /// <param name="bitIndex"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteBit(int byteIndex, int bitIndex, ulong value)
        {
            if (byteIndex < 0 || byteIndex >= Data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteIndex), "byteIndex is out of range.");
            }

            if (bitIndex < 0 || bitIndex > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(bitIndex), "bitIndex must be in range 0-7.");
            }

            if (value != 0 && value != 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "value must be either 0 or 1.");
            }

            WriteBitInternal(byteIndex, bitIndex, value);
        }

        /// <summary>
        /// Writes a single bit to the specified byte and bit index based on a Boolean value.
        /// </summary>
        /// <param name="byteIndex">The zero-based index of the target byte.</param>
        /// <param name="bitIndex">The zero-based index of the bit within the byte.</param>
        /// <param name="value">The Boolean value to write as a bit.</param>
        public void WriteBitFromBool(int byteIndex, int bitIndex, bool value)
        {
            WriteBit(byteIndex, bitIndex, value ? 1ul : 0ul);
        }

        /// <summary>
        /// Writes an integer value to the specified byte and bit index, spanning across multiple bits if necessary.
        /// </summary>
        /// <param name="byteIndex"></param>
        /// <param name="bitIndex"></param>
        /// <param name="bitCount"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteInt(int byteIndex, int bitIndex, int bitCount, ulong value)
        {
            if (byteIndex < 0 || byteIndex >= Data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteIndex), "byteIndex is out of range.");
            }

            if (bitIndex < 0 || bitIndex > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(bitIndex), "bitIndex must be in range 0-7.");
            }

            if (bitCount < 1 || bitCount > 64)
            {
                throw new ArgumentOutOfRangeException(nameof(bitCount), "bitCounts must be in range 1-64.");
            }

            if (1ul << bitCount <= value)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"value is too large to fit in {bitCount} bits.");
            }

            int maxBitCountInFirstByte = bitIndex + 1;
            if (maxBitCountInFirstByte >= bitCount) // The bits to write fit within the current byte.
            {
                int leftShift = maxBitCountInFirstByte - bitCount;
                var mask = (byte)~(GetBitMask(bitCount) << leftShift);
                Data[byteIndex] = (byte)((ulong)(mask & Data[byteIndex]) + (value << leftShift));
                return;
            }

            int firstBitCount = bitIndex + 1;
            int lastBitCount = bitCount - firstBitCount;
            if (lastBitCount <= 8) // The bits to write fit within the current and the next byte.
            {
                var fistMask = ~GetBitMask(firstBitCount);
                Data[byteIndex] = (byte)((ulong)(fistMask & Data[byteIndex]) + (value >> lastBitCount));

                var secondMask = (byte)~(GetBitMask(lastBitCount) << (8 - lastBitCount));
                Data[byteIndex + 1] = (byte)((ulong)(secondMask & Data[byteIndex + 1]) + ((value & GetBitMask(lastBitCount)) << (8 - lastBitCount)));
                return;
            }

            // The bits to write span across multiple bytes.
            int fistMask1 = ~GetBitMask(firstBitCount);
            Data[byteIndex] = (byte)((ulong)(fistMask1 & Data[byteIndex]) + (value >> (bitCount - firstBitCount)));

            int fullByteCount = (bitCount - firstBitCount) / 8;
            for (int i = 0; i < fullByteCount; i++)
            {
                int rightShift = bitCount - firstBitCount - (i + 1) * 8;
                Data[byteIndex + 1 + i] = (byte)((value >> rightShift) & 255);
            }

            lastBitCount = bitCount - firstBitCount - fullByteCount * 8;
            var lastMask = (byte)~(GetBitMask(lastBitCount) << (8 - lastBitCount));
            Data[byteIndex + fullByteCount + 1] = (byte)(((ulong)(lastMask & Data[byteIndex + fullByteCount + 1])) + ((value & GetBitMask(lastBitCount)) << (8 - lastBitCount)));
        }

        /// <summary>
        /// Writes a byte value at the specified index in the data array.
        /// </summary>
        /// <param name="byteIndex">The zero-based index at which to write the byte.</param>
        /// <param name="value">The byte value to write.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when byteIndex is less than zero or greater than or equal to the length of the data array.</exception>
        public void WriteByte(int byteIndex, byte value)
        {
            if (byteIndex < 0 || byteIndex >= Data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteIndex), "byteIndex is out of range.");
            }

            Data[byteIndex] = value;
        }

        /// <summary>
        /// Writes a byte array starting at the specified index in the data array.
        /// </summary>
        /// <param name="byteIndex"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void WriteBytes(int byteIndex, byte[] value)
        {
            if (byteIndex < 0 || byteIndex + value.Length > Data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(byteIndex), "byteIndex is out of range.");
            }
            Array.Copy(value, 0, Data, byteIndex, value.Length);
        }

        #endregion
    }
}
