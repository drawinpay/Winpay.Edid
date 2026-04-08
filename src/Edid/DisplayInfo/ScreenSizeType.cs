namespace Edid.DisplayInfo;

/// <summary>
/// Screen Size Data Type
/// </summary>
public enum ScreenSizeType
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// Screen width and height in centimeters
    /// </summary>
    WidthAndHeight = 1,
    /// <summary>
    /// Landscape aspect ratio
    /// </summary>
    LandscapeAspectRatio = 2,
    /// <summary>
    /// Portrait aspect ratio
    /// </summary>
    PortraitAspectRatio = 3
}