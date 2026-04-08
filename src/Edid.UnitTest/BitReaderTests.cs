        using Edid.Utils;

namespace Edid.UnitTest
{
    [TestClass]
    public sealed class BitReaderTests
    {
        [TestMethod]
        public void ReadBit_ShouldReturnCorrectBitValue()
        {
            // Arrange        76543210       
            byte[] data = { 0b10101010 }; // Binary: 10101010
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.AreEqual(0, bitReader.ReadBit(0, 0));  // Bit 0: 0
            Assert.AreEqual(1, bitReader.ReadBit(0, 1));  // Bit 1: 1
            Assert.AreEqual(0, bitReader.ReadBit(0, 2));  // Bit 2: 0
            Assert.AreEqual(1, bitReader.ReadBit(0, 3));  // Bit 3: 1
            Assert.AreEqual(0, bitReader.ReadBit(0, 4));  // Bit 4: 0
            Assert.AreEqual(1, bitReader.ReadBit(0, 5));  // Bit 5: 1
            Assert.AreEqual(0, bitReader.ReadBit(0, 6));  // Bit 6: 0
            Assert.AreEqual(1, bitReader.ReadBit(0, 7));  // Bit 7: 1
        }

        [TestMethod]
        public void ReadBit_ShouldThrowException_WhenBytesOffsetOutOfRange()
        {
            // Arrange        76543210       
            byte[] data = { 0b10101010 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBit(-1, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBit(1, 0));
        }

        [TestMethod]
        public void ReadBit_ShouldThrowException_WhenBitOffsetOutOfRange()
        {
            // Arrange        76543210       
            byte[] data = { 0b10101010 };
            var bitReader = new BitReader(data);
            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBit(0, -1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBit(0, 8));
        }

        [TestMethod]
        public void ReadBitToBoolean_ShouldReturnCorrectBoolean()
        {
            // Arrange        76543210       
            byte[] data = { 0b11110000 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.IsFalse(bitReader.ReadBitAsBool(0, 0));
            Assert.IsFalse(bitReader.ReadBitAsBool(0, 1));
            Assert.IsFalse(bitReader.ReadBitAsBool(0, 2));
            Assert.IsFalse(bitReader.ReadBitAsBool(0, 3));
            Assert.IsTrue(bitReader.ReadBitAsBool(0, 4));
            Assert.IsTrue(bitReader.ReadBitAsBool(0, 5));
            Assert.IsTrue(bitReader.ReadBitAsBool(0, 6));
            Assert.IsTrue(bitReader.ReadBitAsBool(0, 7));
        }

        [TestMethod]
        public void ReadByte_ShouldReturnCorrectByteValue()
        {
            // Arrange
            byte[] data = { 0x12, 0x34, 0x56, 0x78 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.AreEqual((byte)0x12, bitReader.ReadByte(0));
            Assert.AreEqual((byte)0x34, bitReader.ReadByte(1));
            Assert.AreEqual((byte)0x56, bitReader.ReadByte(2));
            Assert.AreEqual((byte)0x78, bitReader.ReadByte(3));
        }

        [TestMethod]
        public void ReadBytes_ShouldReturnCorrectBytes()
        {
            // Arrange
            byte[] data = { 0x01, 0x02, 0x03, 0x04, 0x05 };
            var bitReader = new BitReader(data);

            // Act
            byte[] result = bitReader.ReadBytes(1, 3);

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual((byte)0x02, result[0]);
            Assert.AreEqual((byte)0x03, result[1]);
            Assert.AreEqual((byte)0x04, result[2]);
        }

        [TestMethod]
        public void ReadInt_SingleByte_ShouldReturnCorrectValue()
        {
            // Arrange        76543210    76543210    
            byte[] data = { 0b10101010, 0b11001100 };
            var bitReader = new BitReader(data);

            // Act & Assert
            // Read 4 bits starting from bit 0 (bits 0-3: 1010 = 10)
            Assert.AreEqual(10, bitReader.ReadBitsAsInt(0, 7, 4));
            // Read 4 bits starting from bit 4 (bits 4-7: 1010 = 10)
            Assert.AreEqual(10, bitReader.ReadBitsAsInt(0, 3, 4));
            // Read 8 bits starting from bit 0 (10101010 = 170)
            Assert.AreEqual(170, bitReader.ReadBitsAsInt(0, 7, 8));
        }

        [TestMethod]
        public void ReadInt_MultipleBytes_ShouldReturnCorrectValue()
        {
            // Arrange        76543210    76543210    76543210
            byte[] data = { 0b00001111, 0b11110000, 0b10101010 };
            var bitReader = new BitReader(data);

            // Act & Assert
            // Read 12 bits starting from bit 0 (first 8 bits: 00001111, next 4 bits: 1111)
            Assert.AreEqual(0xFF, bitReader.ReadBitsAsInt(0, 7, 12));
            // Read 16 bits starting from bit 4 (4 bits from first byte + 8 bits from second byte + 4 bits from third byte)
            long result = bitReader.ReadBitsAsInt(0, 3, 16);
            Assert.AreEqual(0xFF0A, result);
        }

        [TestMethod]
        public void ReadInt_ShouldThrowException_WhenBitOffsetOutOfRange()
        {
            // Arrange
            byte[] data = { 0x12 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsInt(0, -1, 8));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsInt(0, 8, 8));
        }

        [TestMethod]
        public void ReadInt_ShouldThrowException_WhenBitCountsOutOfRange()
        {
            // Arrange
            byte[] data = { 0x12 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsInt(0, 0, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsInt(0, 0, 65));
        }

        [TestMethod]
        public void ReadInt_CrossByteBoundary_ShouldWorkCorrectly()
        {
            // Arrange        76543210    76543210  
            byte[] data = { 0b11000000, 0b00000111 };
            var bitReader = new BitReader(data);

            // Act & Assert
            // Read 8 bits starting from bit 6 (1000000 0)
            long result = bitReader.ReadBitsAsInt(0, 6, 8);
            Assert.AreEqual(0x80, result);

            // Read 14 bits starting from bit 6 (11000000 000001)
            result = bitReader.ReadBitsAsInt(0, 7, 14);
            Assert.AreEqual(0x3001, result);
        }

        [TestMethod]
        public void ReadBitsAsByte_SingleByte_ShouldReturnCorrectValue()
        {
            // Arrange        76543210    76543210
            byte[] data = { 0b10101010, 0b11001100 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.AreEqual((byte)10, bitReader.ReadBitsAsByte(0, 7, 4));
            Assert.AreEqual((byte)10, bitReader.ReadBitsAsByte(0, 3, 4));
            Assert.AreEqual((byte)170, bitReader.ReadBitsAsByte(0, 7, 8));
        }

        [TestMethod]
        public void ReadBitsAsByte_CrossByteBoundary_ShouldReturnCorrectValue()
        {
            // Arrange        76543210    76543210
            byte[] data = { 0b10101010, 0b11001100 };
            var bitReader = new BitReader(data);

            // Act
            byte result1 = bitReader.ReadBitsAsByte(0, 3, 8);
            byte result2 = bitReader.ReadBitsAsByte(0, 1, 4);

            // Assert
            Assert.AreEqual((byte)0b10101100, result1);
            Assert.AreEqual((byte)0b1011, result2);
        }

        [TestMethod]
        public void ReadBitsAsByte_ShouldThrowException_WhenByteOffsetOutOfRange()
        {
            // Arrange
            byte[] data = { 0x12 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(-1, 0, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(1, 0, 1));
        }

        [TestMethod]
        public void ReadBitsAsByte_ShouldThrowException_WhenBitOffsetOrBitCountOutOfRange()
        {
            // Arrange
            byte[] data = { 0x12, 0x34 };
            var bitReader = new BitReader(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(0, -1, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(0, 8, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(0, 7, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitReader.ReadBitsAsByte(0, 7, 9));
        }
    }
}
