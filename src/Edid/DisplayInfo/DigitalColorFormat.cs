namespace Edid.DisplayInfo
{
    /// <summary>
    /// Supported Color Encoding Format/s 
    /// </summary>
    public enum DigitalColorFormat : uint
    {
        /// <summary>
        /// RGB 4:4:4
        /// </summary>
        RGB444 = 0,

        /// <summary>
        /// RGB 4:4:4 & YCrCb 4:4:4
        /// </summary>
        RGB444YCrCb444 = 1,

        /// <summary>
        /// RGB 4:4:4 & YCrCb 4:2:2
        /// </summary>
        RGB444CrCb422 = 2,

        /// <summary>
        /// RGB 4:4:4 & YCrCb 4:4:4 & YCrCb 4:2:2
        /// </summary>
        RGB444YCrCb444YCrCb422 = 3
    }
}
