using Edid.Utils;

namespace Edid.UnitTest
{
    [TestClass]
    public sealed class BitWriterTests
    {
        [TestMethod]
        public void WriteBit_ShouldSetCorrectBitValue()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act
            bitWriter.WriteBit(0, 0, 1);
            bitWriter.WriteBit(0, 2, 1);
            bitWriter.WriteBit(0, 4, 1);
            bitWriter.WriteBit(0, 7, 1);

            // Assert
            Assert.AreEqual(0b10010101, data[0]);
        }

        [TestMethod]
        public void WriteBit_ShouldClearCorrectBitValue()
        {
            // Arrange
            byte[] data = { 0b11111111 };
            var bitWriter = new BitWriter(data);

            // Act
            bitWriter.WriteBit(0, 1, 0);
            bitWriter.WriteBit(0, 3, 0);
            bitWriter.WriteBit(0, 5, 0);
            bitWriter.WriteBit(0, 7, 0);

            // Assert
            Assert.AreEqual(0b01010101, data[0]);
        }

        [TestMethod]
        public void WriteBit_ShouldThrowException_WhenByteIndexOutOfRange()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(-1, 0, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(1, 0, 1));
        }

        [TestMethod]
        public void WriteBit_ShouldThrowException_WhenBitIndexOutOfRange()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(0, -1, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(0, 8, 1));
        }

        [TestMethod]
        public void WriteBit_ShouldThrowException_WhenValueIsInvalid()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(0, 0, 2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteBit(0, 0, 255));
        }

        [TestMethod]
        public void WriteInt_SingleByte_ShouldWriteCorrectValue()
        {
            // Arrange        76543210    
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act
            // Write 0b1010 (10) at bits 7-4
            bitWriter.WriteInt(0, 7, 4, 0b1010);

            // Assert
            Assert.AreEqual(0b10100000, data[0]);
        }

        [TestMethod]
        public void WriteInt_SingleByte_OverwriteExistingBits()
        {
            // Arrange        76543210    
            byte[] data = { 0b11110000 };
            var bitWriter = new BitWriter(data);

            // Act
            // Write 0b0101 (5) at bits 3-0, overwriting existing bits
            bitWriter.WriteInt(0, 3, 4, 0b0101);

            // Assert
            Assert.AreEqual(0b11110101, data[0]);
        }

        [TestMethod]
        public void WriteInt_SingleByte_8Bits_ShouldWriteFullByte()
        {
            // Arrange        76543210    
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act
            bitWriter.WriteInt(0, 7, 8, 0xAB);

            // Assert
            Assert.AreEqual(0xAB, data[0]);
        }

        [TestMethod]
        public void WriteInt_MultipleBytes_ShouldWriteCorrectValue()
        {
            // Arrange        76543210    76543210    
            byte[] data = { 0b00000000, 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act
            // Write 12 bits: 0b111100001111 starting from bit 7 of byte 0
            bitWriter.WriteInt(0, 7, 12, 0b111100001111);

            // Assert
            Assert.AreEqual(0b11110000, data[0]);
            Assert.AreEqual(0b11110000, data[1]);
        }

        [TestMethod]
        public void WriteInt_MultipleBytes_SpanThreeBytes()
        {
            // Arrange        76543210    76543210    76543210
            byte[] data = { 0b00000000, 0b00000000, 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act
            // Write 16 bits starting from bit 5 of byte 0
            bitWriter.WriteInt(0, 5, 16, 0xFF00);

            // Assert
            Assert.AreEqual(0b00111111, data[0]);
            Assert.AreEqual(0b11000000, data[1]);
            Assert.AreEqual(0b00000000, data[2]);
        }

        [TestMethod]
        public void WriteInt_ShouldThrowException_WhenByteIndexOutOfRange()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(-1, 0, 4, 0x0F));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(1, 0, 4, 0x0F));
        }

        [TestMethod]
        public void WriteInt_ShouldThrowException_WhenBitIndexOutOfRange()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(0, -1, 4, 0x0F));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(0, 8, 4, 0x0F));
        }

        [TestMethod]
        public void WriteInt_ShouldThrowException_WhenBitCountOutOfRange()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(0, 0, 0, 0x0F));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(0, 0, 65, 0x0F));
        }

        [TestMethod]
        public void WriteInt_ShouldThrowException_WhenValueTooLarge()
        {
            // Arrange
            byte[] data = { 0b00000000 };
            var bitWriter = new BitWriter(data);

            // Act & Assert
            // Value 0x10 (16) requires 5 bits, but we're trying to write 4 bits
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bitWriter.WriteInt(0, 7, 4, 0x10));
        }

        [TestMethod]
        public void WriteInt_RoundTrip_WithBitReader()
        {
            // Arrange
            byte[] data = { 0b00000000, 0b00000000 };
            var bitWriter = new BitWriter(data);
            var bitReader = new BitReader(data);

            // Act
            bitWriter.WriteInt(0, 7, 12, 0x3FF);
            long result = bitReader.ReadBitsAsInt(0, 7, 12);

            // Assert
            Assert.AreEqual(0x3FF, result);
        }

        [TestMethod]
        public void WriteInt_MultipleWrites_PreservesOtherBits()
        {
            // Arrange        76543210    76543210    
            byte[] data = { 0b11111111, 0b11111111 };
            var bitWriter = new BitWriter(data);

            // Act
            // Write 0b0000 (0) at bits 5-2 of byte 0
            bitWriter.WriteInt(0, 5, 4, 0b0000);

            // Assert - bits 7-6 and 1-0 should remain 1
            Assert.AreEqual(0b11000011, data[0]);
            Assert.AreEqual(0b11111111, data[1]);
        }
    }
}