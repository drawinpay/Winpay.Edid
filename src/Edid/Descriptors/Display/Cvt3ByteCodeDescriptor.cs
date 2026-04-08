using Edid.Common;

namespace Edid.Descriptors.Display;

public class Cvt3ByteCodeDescriptor : DisplayDescriptor
{
    public List<Cvt3ByteCode> Cvt3ByteCodes
    {
        get
        {
            Valid();

            var cvt3ByteCodes = new List<Cvt3ByteCode>();
            for (var i = 0; i < 4; i++)
            {
                byte[] data = BitReader.ReadBytes(6 + 3 * i, 3);
                var cvt3ByteCode = new Cvt3ByteCode(data);
                if (cvt3ByteCode.IsUsed)
                {
                    cvt3ByteCodes.Add(cvt3ByteCode);
                }
            }
            return cvt3ByteCodes;
        }
    }

    public Cvt3ByteCodeDescriptor(byte[] data) : base(data)
    {

    }

    public Cvt3ByteCodeDescriptor(byte[] data, ByteRange byteRange) : base(data, byteRange)
    {

    }
}