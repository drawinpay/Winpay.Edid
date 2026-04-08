namespace Edid.Descriptors.DetailedTiming;

/// <summary>
/// Specifies the polarity of a digital synchronization signal.
/// </summary>
public enum DigitalSyncPolarity : uint
{
    /// <summary>
    /// Negative sync polarity
    /// </summary>
    Negative = 0,

    /// <summary>
    /// Positive sync polarity
    /// </summary>
    Positive = 1
}