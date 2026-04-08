using Edid.Common;

namespace Edid.Timing;

public class AspectRatio
{
    public int Horizontal { get; }
    public int Vertical { get; }
    public BitMask BitMask { get; }
    public bool IsEnable { get; set; }

    public AspectRatio(int horizontal, int vertical, BitMask bitMask)
    {
        Horizontal = horizontal;
        Vertical = vertical;
        BitMask = bitMask;
    }

    public AspectRatio(int horizontal, int vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    public override string ToString()
    {
        return $"AspectRatio {Horizontal}:{Vertical}";
    }
}