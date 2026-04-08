namespace Edid.DisplayInfo
{
    /// <summary>
    /// Analog Display Color Type
    /// </summary>
    public enum AnalogDisplayColorType : uint
    {
        /// <summary>
        /// Monochrome or Grayscale display
        /// </summary>
        Monochrome = 0,

        /// <summary>
        /// RGB color display
        /// </summary>
        RGB = 1,

        /// <summary>
        /// Non-RGB color display
        /// </summary>
        NonRGB = 3,

        /// <summary>
        /// Display color type is undefined
        /// </summary>
        Undefined = 4
    }
}
