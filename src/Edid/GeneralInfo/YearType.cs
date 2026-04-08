namespace Edid.GeneralInfo;

/// <summary>
/// Indicates whether the year is Manufacture year or Model year.
/// </summary>
public enum YearType
{
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// Manufacture Year
    /// </summary>
    Manufacture = 1,
    /// <summary>
    /// Model Year
    /// </summary>
    Model = 2
}