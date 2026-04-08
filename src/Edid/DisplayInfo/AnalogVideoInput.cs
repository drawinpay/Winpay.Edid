namespace Edid.DisplayInfo;

/// <summary>
/// Analog Video Input Parameters
/// </summary>
public class AnalogVideoInput
{
    /// <summary>
    /// Signal level standard. On bit 6 & 5.
    /// </summary>
    public AnalogVideoWhiteLevel SignalLevelStandard { get; set; }

    /// <summary>
    /// Indicates whether a blank-to-black setup level is expected. On bit 4.
    /// </summary>
    public bool IsBlankToBlackExpected { get; set; }

    /// <summary>
    /// Indicating that the separate sync is supported. On bit 3.
    /// </summary>
    public bool IsSeparateSyncSupported { get; set; }

    /// <summary>
    /// Indicating if the composite sync (on HSync) is supported. On bit 2.
    /// </summary>
    public bool IsCompositeSyncSupported { get; set; }

    /// <summary>
    /// Indicating that sync on green is supported. On bit 1.
    /// </summary>
    public bool IsSyncOnGreenSupported { get; set; }

    /// <summary>
    ///  Indicating that VSync pulse must be serrated when composite or sync-on-green is used. On bit 0.
    /// </summary>
    public bool IsVSyncSerratedOnComposite { get; set; }
}