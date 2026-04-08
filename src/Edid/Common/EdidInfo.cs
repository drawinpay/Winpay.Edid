using Edid.Chromaticity;
using Edid.Descriptors;
using Edid.DisplayInfo;
using Edid.GeneralInfo;
using Edid.Services;
using Edid.Timing;

namespace Edid.Data
{
    /// <summary>
    /// EDID: Extended Display Identification Data.
    /// E-EDID: Enhanced Extended Display Identification Data.
    /// EDID 1.0: 1994.08
    /// EDID 1.1: 1996.04
    /// EDID 1.2: 1997
    /// EDID 1.3: 2000.02
    /// EDID 1.4: 2006.09
    /// </summary>
    public class EdidInfo
    {
        #region Properties

        /// <summary>
        /// Vendor & Product information, including Manufacturer ID, Product Code, Serial Number, Manufacture Date.
        /// </summary>
        public ProductInfo ProductInfo { get; }

        /// <summary>
        /// EDID Version
        /// </summary>
        public EdidVersion Version { get; set; }

        /// <summary>
        /// Basic Display Parameters and Features
        /// </summary>
        public BasicDisplayInfo BasicDisplayInfo { get; set; }

        /// <summary>
        /// Chromaticity Coordinates
        /// </summary>
        public ChromaticityCoordinates ChromaticityCoordinates { get; }

        /// <summary>
        /// Gets or sets the established timings associated with the entity.
        /// </summary>
        public EstablishedTimings EstablishedTimings { get; set; }

        /// <summary>
        /// Standard Timings
        /// </summary>
        public StandardTimings StandardTimings { get; set; }

        /// <summary>
        /// Gets or sets the collection of descriptors associated with the object.
        /// </summary>
        public IDescriptor[]? Descriptors { get; set; }

        #endregion

        #region Constructors

        public EdidInfo(byte[] data)
        {
            byte[] baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(data);
            ProductInfo = new ProductInfo(baseEdidBlock, BaseEdidDataSplitter.GetVendorProductInfoBytesRange());
            Version = new EdidVersion(baseEdidBlock, BaseEdidDataSplitter.GetVersionBytesRange());
            BasicDisplayInfo = new BasicDisplayInfo(baseEdidBlock, BaseEdidDataSplitter.GetBasicDisplayInfoBytesRange());
            ChromaticityCoordinates = new ChromaticityCoordinates(baseEdidBlock, BaseEdidDataSplitter.GetChromaticityCoordinatesBytesRange());
            EstablishedTimings = new EstablishedTimings(baseEdidBlock, BaseEdidDataSplitter.GetEstablishedTimingsBytesRange());
            StandardTimings = new StandardTimings(baseEdidBlock, BaseEdidDataSplitter.GetStandardTimingsBytesRange());
            
            var descriptorParser = new DescriptorParser(BasicDisplayInfo.InputType == VideoInputType.Digital, BasicDisplayInfo.IsDisplayContinuousFrequency);
            Descriptors = descriptorParser.ParseDescriptors(data);
        }

        #endregion
    }
}
