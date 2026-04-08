using System.Collections.ObjectModel;
using Edid.Data;
using Edid.Descriptors;
using Edid.Descriptors.DetailedTiming;
using Edid.Descriptors.Display;
using Edid.DisplayInfo;
using Edid.Timing;
using Edid.Utils;

namespace EdidParser1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string edidText = File.ReadAllText("digital_edid.txt");
            byte[] edidData = edidText.ParseHexString(new[] { " ", "\r", "\n" });

            EdidInfo edidInfo = new EdidInfo(edidData);
            //byte[] baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(edidData);
            //EdidValidator.ValidBaseEdidBlock(baseEdidBlock);
            //var baseEdidParser = new BaseEdidParser(baseEdidBlock);
            //EdidInfo edidInfo = baseEdidParser.Parse();
            PrintEdidInfo(edidInfo);

            Console.ReadLine();
        }

        private static void PrintEdidInfo(EdidInfo edidInfo)
        {
            PrintGeneralInfo(edidInfo);
            PrintBasicDisplayInfo(edidInfo);
            PrintChromaticityCoordinates(edidInfo);
            PrintEstablishedTimings(edidInfo);
            PrintStandardTimings(edidInfo);

            foreach (IDescriptor descriptor in edidInfo.Descriptors!)
            {
                if (descriptor.DescriptorType == DescriptorType.DetailedTiming)
                {
                    PrintDetailedTimingDescriptor(edidInfo, descriptor);
                    continue;
                }

                if (descriptor.DescriptorType == DescriptorType.DisplayProductSerialNumber)
                {
                    PrintSerialNumberDescriptor(descriptor);
                    continue;
                }

                if (descriptor.DescriptorType == DescriptorType.DisplayProductName)
                {
                    PrinteProductNameDescriptor(descriptor);
                    continue;
                }

                if (descriptor.DescriptorType == DescriptorType.AlphanumericDataString)
                {
                    StringDescriptor stringDescriptor = (descriptor as StringDescriptor)!;
                    Console.WriteLine($"Alphanumeric Data String: {stringDescriptor.Text}");
                    Console.WriteLine();
                }

                if (descriptor.DescriptorType == DescriptorType.DisplayRangeLimits)
                {
                    DisplayRangeLimitsDescriptor displayRangeLimitsDescriptor =
                        (descriptor as DisplayRangeLimitsDescriptor)!;
                    Console.WriteLine("Display Range Limits:");
                    Console.WriteLine(
                        $"--Minimum Vertical Field Rate: {displayRangeLimitsDescriptor.MinVerticalRate} Hz");
                    Console.WriteLine(
                        $"--Maximum Vertical Field Rate: {displayRangeLimitsDescriptor.MaxVerticalRate} Hz");
                    Console.WriteLine(
                        $"--Minimum Horizontal Field Rate: {displayRangeLimitsDescriptor.MinHorizontalRate} kHz");
                    Console.WriteLine(
                        $"--Maximum Horizontal Field Rate: {displayRangeLimitsDescriptor.MaxHorizontalRate} kHz");
                    Console.WriteLine($"--Maximum Pixel Clock Rate: {displayRangeLimitsDescriptor.MaxPixelClock} MHz");
                }

                if (descriptor.DescriptorType == DescriptorType.ColorPointData)
                {
                    ColorPointDataDescriptor colorPointDataDescriptor = (descriptor as ColorPointDataDescriptor)!;
                    Console.WriteLine("Color Point Data:");
                    foreach (ColorPoint colorPoint in colorPointDataDescriptor.ColorPoints)
                    {
                        Console.WriteLine($"--{colorPoint}");
                    }
                }

                if (descriptor.DescriptorType == DescriptorType.StandardTiming)
                {
                    StandardTimingDescriptor standardTimingDescriptor = (descriptor as StandardTimingDescriptor)!;
                    Console.WriteLine("Standard Timing:");
                    foreach (StandardTiming timing in standardTimingDescriptor.Timings)
                    {
                        Console.WriteLine($"--{timing}");
                    }
                }

                if (descriptor.DescriptorType == DescriptorType.DisplayColorManagementData)
                {
                    DisplayColorManagementDescriptor displayColorManagementDataDescriptor =
                        (descriptor as DisplayColorManagementDescriptor)!;
                    Console.WriteLine("Display Color Management Data:");
                    Console.WriteLine($"--{displayColorManagementDataDescriptor}");
                }

                if (descriptor.DescriptorType == DescriptorType.Cvt3ByteTimingCode)
                {
                    Cvt3ByteCodeDescriptor cvt3ByteTimingCodeDescriptor = (descriptor as Cvt3ByteCodeDescriptor)!;
                    Console.WriteLine("CVT 3-Byte Timing Codes:");
                    foreach (Cvt3ByteCode timingCode in cvt3ByteTimingCodeDescriptor.Cvt3ByteCodes)
                    {
                        Console.WriteLine($"-- Addressable lines per Field:{timingCode.AddressableVerticalLines}");
                        Console.WriteLine($"--Aspect Ratio:{timingCode.AspectRatio}");
                        Console.WriteLine($"--Preferred Vertical Rate:{timingCode.PreferredVerticalRate}");
                        Console.WriteLine(
                            $"--Supported Vertical Rate and Blanking Style:{timingCode.SupportedVerticalRate}");
                    }
                }

                if (descriptor.DescriptorType == DescriptorType.EstablishedTimingsIII)
                {
                    EstablishedTimingsIIIDescriptor establishedTimingsIIIDescriptor =
                        (descriptor as EstablishedTimingsIIIDescriptor)!;
                    Console.WriteLine("Established Timings III:");
                    foreach (EstablishedTiming timing in establishedTimingsIIIDescriptor.Timings)
                    {
                        Console.WriteLine($"--{timing}, Enabled:{timing.IsEnable}");
                    }
                }

                if (descriptor.DescriptorType == DescriptorType.DummyDescriptor)
                {
                    Console.WriteLine("Dummy Descriptor");
                }

                if (descriptor.DescriptorType == DescriptorType.ManufacturerSpecified)
                {
                    Console.WriteLine("Manufacturer Specified Data Block");
                }
            }
        }

        private static void PrinteProductNameDescriptor(IDescriptor descriptor)
        {
            StringDescriptor stringDescriptor = (descriptor as StringDescriptor)!;
            Console.WriteLine($"Display Product Name: {stringDescriptor.Text}");
            Console.WriteLine();
        }

        private static void PrintSerialNumberDescriptor(IDescriptor descriptor)
        {
            StringDescriptor stringDescriptor = (descriptor as StringDescriptor)!;
            Console.WriteLine($"Display Product Serial Number: {stringDescriptor.Text}");
            Console.WriteLine();
        }

        private static void PrintDetailedTimingDescriptor(EdidInfo edidInfo, IDescriptor descriptor)
        {
            Console.WriteLine("Detailed Timing Descriptors:");
            DetailedTimingDescriptor detailedTimingDescriptor = (descriptor as DetailedTimingDescriptor)!;
            Console.WriteLine($"--Pixel Clock: {detailedTimingDescriptor.PixelClock} Hz");
            Console.WriteLine(
                $"--Horizontal Addressable Video Pixels: {detailedTimingDescriptor.HorizontalAddressableVideoPixels} pixels");
            Console.WriteLine($"--Horizontal Blanking Pixels: {detailedTimingDescriptor.HorizontalBlankingPixels} pixels");
            Console.WriteLine(
                $"--Vertical Addressable Video Lines: {detailedTimingDescriptor.VerticalAddressableVideoLines} lines");
            Console.WriteLine($"--Vertical Blanking Lines: {detailedTimingDescriptor.VerticalBlankingLines} lines");
            Console.WriteLine($"--Horizontal Front Porch Pixels: {detailedTimingDescriptor.HorizontalFrontPorchPixels} pixels");
            Console.WriteLine($"--Horizontal Sync Pulse Width: {detailedTimingDescriptor.HorizontalSyncPulseWidth} pixels");
            Console.WriteLine($"--Vertical Front Porch Lines: {detailedTimingDescriptor.VerticalFrontPorchLines} lines");
            Console.WriteLine($"--Vertical Sync Pulse Width: {detailedTimingDescriptor.VerticalSyncPulseWidth} lines");
            Console.WriteLine(
                $"--Horizontal Addressable Video Image Size: {detailedTimingDescriptor.HorizontalAddressableVideoImageSize} mm");
            Console.WriteLine(
                $"--Vertical Addressable Video Image Size: {detailedTimingDescriptor.VerticalAddressableVideoImageSize} mm");
            Console.WriteLine($"--Horizontal Border Pixels: {detailedTimingDescriptor.HorizontalBorderPixels} pixels");
            Console.WriteLine($"--Vertical Border Lines: {detailedTimingDescriptor.VerticalBorderLines} lines");
            Console.WriteLine($"--Is Interlaced: {detailedTimingDescriptor.IsInterlaced}");
            Console.WriteLine($"--Stereo Viewing Mode: {detailedTimingDescriptor.StereoMode}");
            if (edidInfo.BasicDisplayInfo.InputType == VideoInputType.Analog)
            {
                Console.WriteLine($"--Analog Sync Type: {detailedTimingDescriptor.AnalogSyncType}");
                Console.WriteLine($"--Is Analog Sync With Serrations: {detailedTimingDescriptor.IsAnalogSyncWithSerrations}");
                Console.WriteLine(
                    $"--Is Analog Sync On All RGB Video Signals: {detailedTimingDescriptor.IsAnalogSyncOnAllRgbVideoSignals}");
            }
            else
            {
                Console.WriteLine($"--Digital Sync Type: {detailedTimingDescriptor.DigitalSyncType}");
                if (detailedTimingDescriptor.DigitalSyncType == DigitalSyncType.DigitalCompositeSync)
                {
                    Console.WriteLine(
                        $"--Is Digital Sync With Serrations: {detailedTimingDescriptor.IsDigitalSyncWithSerrations}");
                }

                if (detailedTimingDescriptor.DigitalSyncType == DigitalSyncType.DigitalSeparateSync)
                {
                    Console.WriteLine(
                        $"--Digital Vertical Sync Polarity: {detailedTimingDescriptor.DigitalVerticalSyncPolarity}");
                }

                Console.WriteLine(
                    $"--Digital Horizontal Sync Polarity: {detailedTimingDescriptor.DigitalHorizontalSyncPolarity}");
            }

            Console.WriteLine();
        }

        private static void PrintStandardTimings(EdidInfo edidInfo)
        {
            Console.WriteLine("Standard Timings:");
            StandardTimings standardTimings = edidInfo.StandardTimings;
            foreach (StandardTiming timing in standardTimings.Timings)
            {
                Console.WriteLine($"--{timing}");
            }

            Console.WriteLine();
        }

        private static void PrintEstablishedTimings(EdidInfo edidInfo)
        {
            Console.WriteLine("Established timing I:");
            ReadOnlyCollection<EstablishedTiming> establishedTiming1 = edidInfo.EstablishedTimings.EstablishedTimings1.Timings;
            foreach (var timing in establishedTiming1)
            {
                Console.WriteLine($"--{timing}, Enabled:{timing.IsEnable}");
            }

            Console.WriteLine();

            Console.WriteLine("Established timing II:");
            ReadOnlyCollection<EstablishedTiming> establishedTiming2 = edidInfo.EstablishedTimings.EstablishedTimings2.Timings;
            foreach (var timing in establishedTiming2)
            {
                Console.WriteLine($"--{timing}, Enabled:{timing.IsEnable}");
            }

            Console.WriteLine();

            Console.WriteLine("Manufacturer's Timings:");
            ReadOnlyCollection<EstablishedTiming>
                manufacturerTimings = edidInfo.EstablishedTimings.ManufacturerTimings.Timings;
            foreach (var timing in manufacturerTimings)
            {
                Console.WriteLine($"--{timing}, Enabled:{timing.IsEnable}");
            }

            Console.WriteLine();
        }

        private static void PrintChromaticityCoordinates(EdidInfo edidInfo)
        {
            Console.WriteLine("Display x, y Chromaticity Coordinates:");
            Console.WriteLine($"--Red x: {Math.Round(edidInfo.ChromaticityCoordinates.RedX, 4)}");
            Console.WriteLine($"--Red y: {Math.Round(edidInfo.ChromaticityCoordinates.RedY, 4)}");
            Console.WriteLine($"--Green x: {Math.Round(edidInfo.ChromaticityCoordinates.GreenX, 4)}");
            Console.WriteLine($"--Green y: {Math.Round(edidInfo.ChromaticityCoordinates.GreenY, 4)}");
            Console.WriteLine($"--Blue x: {Math.Round(edidInfo.ChromaticityCoordinates.BlueX, 4)}");
            Console.WriteLine($"--Blue y: {Math.Round(edidInfo.ChromaticityCoordinates.BlueY, 4)}");
            Console.WriteLine($"--White x: {Math.Round(edidInfo.ChromaticityCoordinates.WhiteX, 4)}");
            Console.WriteLine($"--White y: {Math.Round(edidInfo.ChromaticityCoordinates.WhiteY, 4)}");
            Console.WriteLine();
        }

        private static void PrintBasicDisplayInfo(EdidInfo edidInfo)
        {
            Console.WriteLine("Basic Display Parameters & Features:");
            Console.WriteLine($"--Video input type: {edidInfo.BasicDisplayInfo.InputType}");
            if (edidInfo.BasicDisplayInfo.InputType == VideoInputType.Digital)
            {
                Console.WriteLine(
                    $"--Digital color bit depth: {edidInfo.BasicDisplayInfo.DigitalInput.ColorBitDepth}");
                Console.WriteLine(
                    $"--Digital video interface standard: {edidInfo.BasicDisplayInfo.DigitalInput.VideoInterfaceStandard}");
            }

            Console.WriteLine();

            Console.WriteLine($"--Screen size data type: {edidInfo.BasicDisplayInfo.ScreenSizeType}");
            if (edidInfo.BasicDisplayInfo.ScreenSizeType == ScreenSizeType.WidthAndHeight)
            {
                Console.WriteLine(
                    $"--Screen size: {edidInfo.BasicDisplayInfo.PhysicalWidth} cm x {edidInfo.BasicDisplayInfo.PhysicalHeight} cm");
            }
            else
            {
                Console.WriteLine($"--Aspect ratio: {edidInfo.BasicDisplayInfo.AspectRatio}");
            }

            Console.WriteLine($"--Gamma: {edidInfo.BasicDisplayInfo.Gamma}");

            Console.WriteLine($"--Is Standby Mode supported:{edidInfo.BasicDisplayInfo.IsStandbySupported}");
            Console.WriteLine($"--Is Suspend Mode supported:{edidInfo.BasicDisplayInfo.IsSuspendSupported}");
            Console.WriteLine($"--Is Active Off = Very Low Power supported:{edidInfo.BasicDisplayInfo.IsActiveOffSupported}");

            if (edidInfo.BasicDisplayInfo.InputType == VideoInputType.Digital)
            {
                Console.WriteLine(
                    $"--Digital Supported Color Encoding Format/s:{edidInfo.BasicDisplayInfo.DigitalColorFormat}");
            }
            else if (edidInfo.BasicDisplayInfo.InputType == VideoInputType.Analog)
            {
                Console.WriteLine($"--Analog Display Color Type: {edidInfo.BasicDisplayInfo.AnalogColorType}");
            }

            Console.WriteLine(
                $"--Is sRGB Standard the default color space: {edidInfo.BasicDisplayInfo.IsDefaultSRgbStandard}");
            Console.WriteLine(
                $"--Is Preferred Timing Mode includes the native info: {edidInfo.BasicDisplayInfo.IsPreferredTimingModeIncludesNativeInfo}");
            Console.WriteLine(
                $"--Is Display is continuous frequency:{edidInfo.BasicDisplayInfo.IsDisplayContinuousFrequency}");
            Console.WriteLine();
        }

        private static void PrintGeneralInfo(EdidInfo edidInfo)
        {
            Console.WriteLine($"EDID Structure Version & Revision: {edidInfo.Version}");
            Console.WriteLine();

            Console.WriteLine("Vendor & Product Identification:");
            Console.WriteLine($"--Manufacturer ID: {edidInfo.ProductInfo.ManufacturerId}");
            Console.WriteLine($"--Product Code: {edidInfo.ProductInfo.ProductCode}");
            Console.WriteLine($"--Serial number: {edidInfo.ProductInfo.SerialNumber}");
            Console.WriteLine(
                $"--Made in: Week {edidInfo.ProductInfo.ManufactureDate.Week} of Year {edidInfo.ProductInfo.ManufactureDate.Year} ");
            Console.WriteLine();
        }
    }
}
