namespace Edid.Descriptors
{
    public interface IDescriptor
    {
        public byte[] Data { get; }
        public DescriptorType DescriptorType { get; }
        public bool IsValid { get; }
    }
}
