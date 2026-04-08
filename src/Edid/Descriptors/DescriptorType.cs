namespace Edid.Descriptors;

public enum DescriptorType : byte
{
    /// <summary>
    /// Unknown descriptor type. The value of the first byte of the descriptor is not recognized as a valid descriptor type.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Detailed Timing Descriptor
    /// </summary>
    DetailedTiming = 1,

    /// <summary>
    /// Display Product Serial Number:
    /// </summary>
    DisplayProductSerialNumber = 0xFF,

    /// <summary>
    /// Alphanumeric Data String (ASCII):  
    /// </summary>
    AlphanumericDataString = 0xFE,

    /// <summary>
    /// Display Range Limits: Includes optional timing information --- GTF using default parameters, GTF Secondary Curve or CVT Descriptor. 
    /// </summary>
    DisplayRangeLimits = 0xFD,

    /// <summary>
    /// Display Product Name
    /// </summary>
    DisplayProductName = 0xFC,

    /// <summary>
    /// Color Point Data
    /// </summary>
    ColorPointData = 0xFB,

    /// <summary>
    /// Standard Timing Identifications
    /// </summary>
    StandardTiming = 0xFA,

    /// <summary>
    /// Display Color Management (DCM) Data
    /// </summary>
    DisplayColorManagementData = 0xF9,

    /// <summary>
    /// CVT 3 Byte Timing Codes
    /// </summary>
    Cvt3ByteTimingCode = 0xF8,

    /// <summary>
    /// Established Timings III 
    /// </summary>
    EstablishedTimingsIII = 0xF7,

    /// <summary>
    /// Dummy Descriptor:
    /// </summary>
    DummyDescriptor = 0x10,

    /// <summary>
    /// Manufacturer Specified Display Descriptors: 
    /// </summary>
    ManufacturerSpecified = 0x0F,
}