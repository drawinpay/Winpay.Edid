namespace Edid.Descriptors.DetailedTiming;

/// <summary>
/// Specifies available stereo display modes.
/// </summary>
public enum StereoViewingMode : uint
{
    /// <summary>
    /// Normal Display – No Stereo. The value of bit 0 is "don't care"
    /// </summary>
    NoStereo = 0,

    /// <summary>
    /// Field sequential stereo, right image when stereo sync signal = 1 
    /// </summary>
    FieldSequentialRightImage = 0b010,

    /// <summary>
    /// Field sequential stereo, left image when stereo sync signal = 1 
    /// </summary>
    FieldSequentialLeftImage = 0b100,

    /// <summary>
    /// 2-way interleaved stereo, right image on even lines 
    /// </summary>
    Stereo2WayInterleavedRightImage = 0b011,

    /// <summary>
    /// 2-way interleaved stereo, left image on even lines
    /// </summary>
    Stereo2WayInterleavedLeftImage = 0b101,

    /// <summary>
    /// 4-way interleaved stereo
    /// </summary>
    Stereo4WayInterleaved = 0b110,

    /// <summary>
    /// Side-by-Side interleaved stereo
    /// </summary>
    SideBySide = 0b111
}