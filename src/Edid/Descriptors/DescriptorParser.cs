using Edid.Common;
using Edid.Descriptors.DetailedTiming;
using Edid.Descriptors.Display;
using Edid.Services;
using Edid.Utils;

namespace Edid.Descriptors
{
    /// <summary>
    /// 18 byte descriptor type parser. Parses the descriptor type from the given 18-byte descriptor data.
    /// </summary>
    public class DescriptorParser
    {
        private readonly bool _isDigital;
        private readonly bool _isContinuousFrequency;
        private const int DescriptorLength = 18;

        public DescriptorParser(bool isDigital, bool isContinuousFrequency)
        {
            _isDigital = isDigital;
            _isContinuousFrequency = isContinuousFrequency;
        }

        /// <summary>
        /// Parse the descriptor type from the given 18-byte descriptor data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteRange"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DescriptorType ParseDescriptorType(byte[] data, ByteRange byteRange)
        {
            var bitReader = new BitReader(data, byteRange.StartIndex);

            if (bitReader.ReadByte(0) != 0x00 || bitReader.ReadByte(1) != 0x00)
            {
                return DescriptorType.DetailedTiming;
            }

            byte tagValue = bitReader.ReadByte(3);
            if (tagValue <= 0x0F)
            {
                return DescriptorType.ManufacturerSpecified;
            }

            if (Enum.IsDefined(typeof(DescriptorType), tagValue))
            {
                return (DescriptorType)tagValue;
            }

            return DescriptorType.Unknown;
        }

        /// <summary>
        /// Parse the descriptor type from the given 18-byte descriptor data and return the corresponding descriptor object.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteRange"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IDescriptor ParseDescriptor(byte[] data, ByteRange byteRange)
        {
            DescriptorType descriptorType = ParseDescriptorType(data, byteRange);
            return descriptorType switch
            {
                DescriptorType.DetailedTiming => new DetailedTimingDescriptor(data, byteRange, _isDigital),
                DescriptorType.DisplayProductSerialNumber => new StringDescriptor(data, byteRange),
                DescriptorType.AlphanumericDataString => new StringDescriptor(data, byteRange),
                DescriptorType.DisplayRangeLimits => new DisplayRangeLimitsDescriptor(data, byteRange, _isContinuousFrequency),
                DescriptorType.DisplayProductName => new StringDescriptor(data, byteRange),
                DescriptorType.ColorPointData => new ColorPointDataDescriptor(data, byteRange),
                DescriptorType.StandardTiming => new StandardTimingDescriptor(data, byteRange),
                DescriptorType.DisplayColorManagementData => new DisplayColorManagementDescriptor(data, byteRange),
                DescriptorType.Cvt3ByteTimingCode => new Cvt3ByteCodeDescriptor(data, byteRange),
                DescriptorType.EstablishedTimingsIII => new EstablishedTimingsIIIDescriptor(data, byteRange),
                DescriptorType.ManufacturerSpecified => new ManufacturerDataDescriptor(data, byteRange),
                DescriptorType.DummyDescriptor => new DummyDescriptor(data, byteRange),
                _ => throw new InvalidOperationException($"Unsupported descriptor type: {descriptorType}")
            };
        }

        public IDescriptor[] ParseDescriptors(byte[] baseBlock)
        {
            var descriptors = new IDescriptor[4];
            for (var i = 0; i < 4; i++)
            {
                var dataRange = BaseEdidDataSplitter.GetDescriptorBlockBytesRange(i);
                descriptors[i] = ParseDescriptor(baseBlock, dataRange);

            }

            return descriptors;
        }
    }
}
