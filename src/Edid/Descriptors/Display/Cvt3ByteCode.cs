using Edid.Utils;

namespace Edid.Descriptors.Display
{
    public class Cvt3ByteCode
    {
        private readonly BitReader _bitReader;
        private readonly BitWriter _bitWriter;

        public byte[] Data { get; }

        public bool IsUsed => Data.SequenceEqual(new byte[] { 0, 0, 0 });

        public int AddressableVerticalLines
        {
            get
            {
                Validate();

                int storedValue = (int)(_bitReader.ReadByte(0) | (_bitReader.ReadBitsAsInt(1, 7, 4) << 4));
                int addressableLines = (storedValue + 1) * 2;
                return addressableLines;
            }
            set
            {
                var storedValue = (value / 2) - 1;
                _bitWriter.WriteInt(0, 0, 12, (ulong)storedValue);
            }
        }

        public CvtAspectRatio AspectRatio
        {
            get
            {
                Validate();
                return (CvtAspectRatio)_bitReader.ReadBitsAsInt(1, 2, 2);
            }
            set => _bitWriter.WriteInt(1, 2, 2, (ulong)value);
        }

        public CvtRefreshRate PreferredVerticalRate
        {
            get
            {
                Validate();
                return (CvtRefreshRate)_bitReader.ReadBitsAsInt(2, 6, 2);
            }
            set => _bitWriter.WriteInt(2, 6, 2, (ulong)value);
        }

        public CvtRefreshRateAndBlankingStyle SupportedVerticalRate
        {
            get
            {
                Validate();
                return (CvtRefreshRateAndBlankingStyle)_bitReader.ReadBitsAsInt(2, 4, 5);
            }
            set => _bitWriter.WriteInt(2, 4, 5, (ulong)value);
        }

        public Cvt3ByteCode(byte[] data)
        {
            if (data.Length != 3)
            {
                throw new ArgumentException("CVT 3-byte code must be exactly 3 bytes long.", nameof(data));
            }

            Data = data;
            _bitReader = new BitReader(data);
            _bitWriter = new BitWriter(data);
        }

        private void Validate()
        {
            if (!IsUsed)
            {
                throw new InvalidOperationException("The data is not valid.");
            }
        }
    }
}
