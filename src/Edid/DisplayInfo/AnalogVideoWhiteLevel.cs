namespace Edid.DisplayInfo;

/// <summary>
/// Analog Video White Level
/// </summary>
public enum AnalogVideoWhiteLevel : uint
{
    /// <summary>
    /// +0.7/−0.3 V
    /// </summary>
    V07OnMinus03 = 0,

    /// <summary>
    /// +0.714/−0.286 V
    /// </summary>
    V0714OnMinus0286 = 1,

    /// <summary>
    /// +1.0/−0.4 V
    /// </summary>
    V1OnMinus04 = 2,

    /// <summary>
    /// +0.7/0 V
    /// </summary>
    V07On0 = 3
}