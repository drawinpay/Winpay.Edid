namespace Edid.DisplayInfo;

/// <summary>
/// Digital Video Input Parameters
/// </summary>
public struct DigitalVideoInput
{
    /// <summary>
    /// Indicates the color depth of the video input interface.
    /// </summary>
    public DigitalColorBitDepth ColorBitDepth { get; }

    /// <summary>
    /// Indicates the digital video interface standard.
    /// </summary>
    public DigitalVideoInterface VideoInterfaceStandard { get; }

    /// <summary>
    /// Initializes a new instance of the DigitalVideoInput class with the specified color bit depth and video interface standard.
    /// </summary>
    /// <param name="colorBitDepth">The digital color bit depth.</param>
    /// <param name="videoInterface">The digital video interface standard.</param>
    public DigitalVideoInput(DigitalColorBitDepth colorBitDepth, DigitalVideoInterface videoInterface)
    {
        ColorBitDepth = colorBitDepth;
        VideoInterfaceStandard = videoInterface;
    }
}