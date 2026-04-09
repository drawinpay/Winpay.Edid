using CommunityToolkit.Mvvm.ComponentModel;
using Edid.Common;
using Edid.DisplayInfo;

namespace EdidEditor.Views
{
    public class DisplayViewModel : ObservableObject
    {
        private bool _isAnalogInput;
        private bool _isDigitalInput;

        private bool _isBitDepthUndefined;
        private bool _isBitDepth6;
        private bool _isBitDepth8;
        private bool _isBitDepth10;
        private bool _isBitDepth12;
        private bool _isBitDepth14;
        private bool _isBitDepth16;
        private bool _isBitDepthReserved;

        private bool _isInterfaceUndefined;
        private bool _isInterfaceDvi;
        private bool _isInterfaceHdmiA;
        private bool _isInterfaceHdmiB;
        private bool _isInterfaceMddi;
        private bool _isInterfaceDisplayPort;

        private bool _isColorFormatRgb444;
        private bool _isColorFormatRgb444YCrCb444;
        private bool _isColorFormatRgb444YCrCb422;
        private bool _isColorFormatRgb444YCrCb444YCrCb422;

        private bool _isScreenSizeTypeSize;
        private bool _isScreenSizeTypePortrait;
        private bool _isScreenSizeTypeLandscape;
        private bool _isScreenSizeTypeUndefined;

        private string _physicalWidth = string.Empty;
        private string _physicalHeight = string.Empty;
        private string _aspectRatio = string.Empty;
        private string _gamma = string.Empty;

        private bool _isStandbySupported;
        private bool _isSuspendSupported;
        private bool _isActiveOffSupported;

        private bool _isDefaultSrgbStandard;
        private bool _isPreferredTimingIncludesNative;
        private bool _isDisplayContinuousFrequency;

        private bool _isV07OnMinus03;
        private bool _isV0714OnMinus0286;
        private bool _isV1OnMinus04;
        private bool _isV07On0;

        private bool _isBlankLevelEqualsBlackLevel;
        private bool _isBlankToBlackSetupOrPedestal;
        private bool _isSeparateSyncSupported;
        private bool _isCompositeSyncSupported;
        private bool _isSyncOnGreenSupported;
        private bool _isVSyncSerratedOnComposite;
        private bool _isAnalogColorMonochrome;
        private bool _isAnalogColorRgb;
        private bool _isAnalogColorNonRgb;
        private bool _isAnalogColorUndefined;

        public bool IsAnalogInput
        {
            get => _isAnalogInput;
            set => SetProperty(ref _isAnalogInput, value);
        }

        public bool IsDigitalInput
        {
            get => _isDigitalInput;
            set => SetProperty(ref _isDigitalInput, value);
        }

        public bool IsBitDepthUndefined
        {
            get => _isBitDepthUndefined;
            set => SetProperty(ref _isBitDepthUndefined, value);
        }

        public bool IsBitDepth6
        {
            get => _isBitDepth6;
            set => SetProperty(ref _isBitDepth6, value);
        }

        public bool IsBitDepth8
        {
            get => _isBitDepth8;
            set => SetProperty(ref _isBitDepth8, value);
        }

        public bool IsBitDepth10
        {
            get => _isBitDepth10;
            set => SetProperty(ref _isBitDepth10, value);
        }

        public bool IsBitDepth12
        {
            get => _isBitDepth12;
            set => SetProperty(ref _isBitDepth12, value);
        }

        public bool IsBitDepth14
        {
            get => _isBitDepth14;
            set => SetProperty(ref _isBitDepth14, value);
        }

        public bool IsBitDepth16
        {
            get => _isBitDepth16;
            set => SetProperty(ref _isBitDepth16, value);
        }

        public bool IsBitDepthReserved
        {
            get => _isBitDepthReserved;
            set => SetProperty(ref _isBitDepthReserved, value);
        }

        public bool IsInterfaceUndefined
        {
            get => _isInterfaceUndefined;
            set => SetProperty(ref _isInterfaceUndefined, value);
        }

        public bool IsInterfaceDvi
        {
            get => _isInterfaceDvi;
            set => SetProperty(ref _isInterfaceDvi, value);
        }

        public bool IsInterfaceHdmiA
        {
            get => _isInterfaceHdmiA;
            set => SetProperty(ref _isInterfaceHdmiA, value);
        }

        public bool IsInterfaceHdmiB
        {
            get => _isInterfaceHdmiB;
            set => SetProperty(ref _isInterfaceHdmiB, value);
        }

        public bool IsInterfaceMddi
        {
            get => _isInterfaceMddi;
            set => SetProperty(ref _isInterfaceMddi, value);
        }

        public bool IsInterfaceDisplayPort
        {
            get => _isInterfaceDisplayPort;
            set => SetProperty(ref _isInterfaceDisplayPort, value);
        }

        public bool IsColorFormatRgb444
        {
            get => _isColorFormatRgb444;
            set => SetProperty(ref _isColorFormatRgb444, value);
        }

        public bool IsColorFormatRgb444YCrCb444
        {
            get => _isColorFormatRgb444YCrCb444;
            set => SetProperty(ref _isColorFormatRgb444YCrCb444, value);
        }

        public bool IsColorFormatRgb444YCrCb422
        {
            get => _isColorFormatRgb444YCrCb422;
            set => SetProperty(ref _isColorFormatRgb444YCrCb422, value);
        }

        public bool IsColorFormatRgb444YCrCb444YCrCb422
        {
            get => _isColorFormatRgb444YCrCb444YCrCb422;
            set => SetProperty(ref _isColorFormatRgb444YCrCb444YCrCb422, value);
        }

        public bool IsV07OnMinus03
        {
            get => _isV07OnMinus03;
            set => SetProperty(ref _isV07OnMinus03, value);
        }

        public bool IsV0714OnMinus0286
        {
            get => _isV0714OnMinus0286;
            set => SetProperty(ref _isV0714OnMinus0286, value);
        }

        public bool IsV1OnMinus04
        {
            get => _isV1OnMinus04;
            set => SetProperty(ref _isV1OnMinus04, value);
        }

        public bool IsV07On0
        {
            get => _isV07On0;
            set => SetProperty(ref _isV07On0, value);
        }

        public bool IsBlankLevelEqualsBlackLevel
        {
            get => _isBlankLevelEqualsBlackLevel;
            set => SetProperty(ref _isBlankLevelEqualsBlackLevel, value);
        }

        public bool IsBlankToBlackSetupOrPedestal
        {
            get => _isBlankToBlackSetupOrPedestal;
            set => SetProperty(ref _isBlankToBlackSetupOrPedestal, value);
        }

        public bool IsSeparateSyncSupported
        {
            get => _isSeparateSyncSupported;
            set => SetProperty(ref _isSeparateSyncSupported, value);
        }

        public bool IsCompositeSyncSupported
        {
            get => _isCompositeSyncSupported;
            set => SetProperty(ref _isCompositeSyncSupported, value);
        }

        public bool IsSyncOnGreenSupported
        {
            get => _isSyncOnGreenSupported;
            set => SetProperty(ref _isSyncOnGreenSupported, value);
        }

        public bool IsVSyncSerratedOnComposite
        {
            get => _isVSyncSerratedOnComposite;
            set => SetProperty(ref _isVSyncSerratedOnComposite, value);
        }

        public bool IsAnalogColorMonochrome
        {
            get => _isAnalogColorMonochrome;
            set => SetProperty(ref _isAnalogColorMonochrome, value);
        }

        public bool IsAnalogColorRgb
        {
            get => _isAnalogColorRgb;
            set => SetProperty(ref _isAnalogColorRgb, value);
        }

        public bool IsAnalogColorNonRgb
        {
            get => _isAnalogColorNonRgb;
            set => SetProperty(ref _isAnalogColorNonRgb, value);
        }

        public bool IsAnalogColorUndefined
        {
            get => _isAnalogColorUndefined;
            set => SetProperty(ref _isAnalogColorUndefined, value);
        }

        public bool IsScreenSizeTypeSize
        {
            get => _isScreenSizeTypeSize;
            set => SetProperty(ref _isScreenSizeTypeSize, value);
        }

        public bool IsScreenSizeTypePortrait
        {
            get => _isScreenSizeTypePortrait;
            set => SetProperty(ref _isScreenSizeTypePortrait, value);
        }

        public bool IsScreenSizeTypeLandscape
        {
            get => _isScreenSizeTypeLandscape;
            set => SetProperty(ref _isScreenSizeTypeLandscape, value);
        }

        public bool IsScreenSizeTypeUndefined
        {
            get => _isScreenSizeTypeUndefined;
            set => SetProperty(ref _isScreenSizeTypeUndefined, value);
        }

        public string PhysicalWidth
        {
            get => _physicalWidth;
            set => SetProperty(ref _physicalWidth, value);
        }

        public string PhysicalHeight
        {
            get => _physicalHeight;
            set => SetProperty(ref _physicalHeight, value);
        }

        public string AspectRatio
        {
            get => _aspectRatio;
            set => SetProperty(ref _aspectRatio, value);
        }

        public string Gamma
        {
            get => _gamma;
            set => SetProperty(ref _gamma, value);
        }

        public bool IsStandbySupported
        {
            get => _isStandbySupported;
            set => SetProperty(ref _isStandbySupported, value);
        }

        public bool IsSuspendSupported
        {
            get => _isSuspendSupported;
            set => SetProperty(ref _isSuspendSupported, value);
        }

        public bool IsActiveOffSupported
        {
            get => _isActiveOffSupported;
            set => SetProperty(ref _isActiveOffSupported, value);
        }

        public bool IsDefaultSrgbStandard
        {
            get => _isDefaultSrgbStandard;
            set => SetProperty(ref _isDefaultSrgbStandard, value);
        }

        public bool IsPreferredTimingIncludesNative
        {
            get => _isPreferredTimingIncludesNative;
            set => SetProperty(ref _isPreferredTimingIncludesNative, value);
        }

        public bool IsDisplayContinuousFrequency
        {
            get => _isDisplayContinuousFrequency;
            set => SetProperty(ref _isDisplayContinuousFrequency, value);
        }

        public void SetData(BasicDisplayInfo basicDisplayInfo)
        {
            IsAnalogInput = basicDisplayInfo.InputType == VideoInputType.Analog;
            IsDigitalInput = basicDisplayInfo.InputType == VideoInputType.Digital;

            ResetDigitalSelections();
            ResetAnalogSelections();

            if (basicDisplayInfo.InputType == VideoInputType.Digital)
            {
                DigitalVideoInput digitalInput = basicDisplayInfo.DigitalInput;

                switch (digitalInput.ColorBitDepth)
                {
                    case DigitalColorBitDepth.Undefined:
                        IsBitDepthUndefined = true;
                        break;
                    case DigitalColorBitDepth.Bit6:
                        IsBitDepth6 = true;
                        break;
                    case DigitalColorBitDepth.Bit8:
                        IsBitDepth8 = true;
                        break;
                    case DigitalColorBitDepth.Bit10:
                        IsBitDepth10 = true;
                        break;
                    case DigitalColorBitDepth.Bit12:
                        IsBitDepth12 = true;
                        break;
                    case DigitalColorBitDepth.Bit14:
                        IsBitDepth14 = true;
                        break;
                    case DigitalColorBitDepth.Bit16:
                        IsBitDepth16 = true;
                        break;
                    default:
                        IsBitDepthReserved = true;
                        break;
                }

                switch (digitalInput.VideoInterfaceStandard)
                {
                    case DigitalVideoInterface.Undefined:
                        IsInterfaceUndefined = true;
                        break;
                    case DigitalVideoInterface.DVI:
                        IsInterfaceDvi = true;
                        break;
                    case DigitalVideoInterface.HDMIa:
                        IsInterfaceHdmiA = true;
                        break;
                    case DigitalVideoInterface.HDMIb:
                        IsInterfaceHdmiB = true;
                        break;
                    case DigitalVideoInterface.MDDI:
                        IsInterfaceMddi = true;
                        break;
                    case DigitalVideoInterface.DisplayPort:
                        IsInterfaceDisplayPort = true;
                        break;
                }

                switch (basicDisplayInfo.DigitalColorFormat)
                {
                    case DigitalColorFormat.RGB444:
                        IsColorFormatRgb444 = true;
                        break;
                    case DigitalColorFormat.RGB444YCrCb444:
                        IsColorFormatRgb444YCrCb444 = true;
                        break;
                    case DigitalColorFormat.RGB444CrCb422:
                        IsColorFormatRgb444YCrCb422 = true;
                        break;
                    case DigitalColorFormat.RGB444YCrCb444YCrCb422:
                        IsColorFormatRgb444YCrCb444YCrCb422 = true;
                        break;
                }
            }
            else
            {
                AnalogVideoInput analogInput = basicDisplayInfo.AnalogInput!;

                switch (analogInput.SignalLevelStandard)
                {
                    case AnalogVideoWhiteLevel.V07OnMinus03:
                        IsV07OnMinus03 = true;
                        break;
                    case AnalogVideoWhiteLevel.V0714OnMinus0286:
                        IsV0714OnMinus0286 = true;
                        break;
                    case AnalogVideoWhiteLevel.V1OnMinus04:
                        IsV1OnMinus04 = true;
                        break;
                    case AnalogVideoWhiteLevel.V07On0:
                        IsV07On0 = true;
                        break;
                }

                IsBlankLevelEqualsBlackLevel = !analogInput.IsBlankToBlackExpected;
                IsBlankToBlackSetupOrPedestal = analogInput.IsBlankToBlackExpected;

                IsSeparateSyncSupported = analogInput.IsSeparateSyncSupported;
                IsCompositeSyncSupported = analogInput.IsCompositeSyncSupported;
                IsSyncOnGreenSupported = analogInput.IsSyncOnGreenSupported;
                IsVSyncSerratedOnComposite = analogInput.IsVSyncSerratedOnComposite;

                switch (basicDisplayInfo.AnalogColorType)
                {
                    case AnalogDisplayColorType.Monochrome:
                        IsAnalogColorMonochrome = true;
                        break;
                    case AnalogDisplayColorType.RGB:
                        IsAnalogColorRgb = true;
                        break;
                    case AnalogDisplayColorType.NonRGB:
                        IsAnalogColorNonRgb = true;
                        break;
                    default:
                        IsAnalogColorUndefined = true;
                        break;
                }
            }

            IsScreenSizeTypeSize = basicDisplayInfo.ScreenSizeType == ScreenSizeType.WidthAndHeight;
            IsScreenSizeTypePortrait = basicDisplayInfo.ScreenSizeType == ScreenSizeType.PortraitAspectRatio;
            IsScreenSizeTypeLandscape = basicDisplayInfo.ScreenSizeType == ScreenSizeType.LandscapeAspectRatio;
            IsScreenSizeTypeUndefined = basicDisplayInfo.ScreenSizeType == ScreenSizeType.Unknown;

            if (basicDisplayInfo.ScreenSizeType == ScreenSizeType.WidthAndHeight)
            {
                PhysicalWidth = basicDisplayInfo.PhysicalWidth.ToString();
                PhysicalHeight = basicDisplayInfo.PhysicalHeight.ToString();
                AspectRatio = string.Empty;
            }
            else if (basicDisplayInfo.ScreenSizeType == ScreenSizeType.PortraitAspectRatio
                     || basicDisplayInfo.ScreenSizeType == ScreenSizeType.LandscapeAspectRatio)
            {
                PhysicalWidth = string.Empty;
                PhysicalHeight = string.Empty;
                AspectRatio = basicDisplayInfo.AspectRatio.ToString("0.00");
            }
            else
            {
                PhysicalWidth = string.Empty;
                PhysicalHeight = string.Empty;
                AspectRatio = string.Empty;
            }

            Gamma = basicDisplayInfo.Gamma.ToString("0.00");

            IsStandbySupported = basicDisplayInfo.IsStandbySupported;
            IsSuspendSupported = basicDisplayInfo.IsSuspendSupported;
            IsActiveOffSupported = basicDisplayInfo.IsActiveOffSupported;

            IsDefaultSrgbStandard = basicDisplayInfo.IsDefaultSRgbStandard;
            IsPreferredTimingIncludesNative = basicDisplayInfo.IsPreferredTimingModeIncludesNativeInfo;
            IsDisplayContinuousFrequency = basicDisplayInfo.IsDisplayContinuousFrequency;
        }

        private void ResetDigitalSelections()
        {
            IsBitDepthUndefined = false;
            IsBitDepth6 = false;
            IsBitDepth8 = false;
            IsBitDepth10 = false;
            IsBitDepth12 = false;
            IsBitDepth14 = false;
            IsBitDepth16 = false;
            IsBitDepthReserved = false;

            IsInterfaceUndefined = false;
            IsInterfaceDvi = false;
            IsInterfaceHdmiA = false;
            IsInterfaceHdmiB = false;
            IsInterfaceMddi = false;
            IsInterfaceDisplayPort = false;

            IsColorFormatRgb444 = false;
            IsColorFormatRgb444YCrCb444 = false;
            IsColorFormatRgb444YCrCb422 = false;
            IsColorFormatRgb444YCrCb444YCrCb422 = false;
        }

        private void ResetAnalogSelections()
        {
            IsV07OnMinus03 = false;
            IsV0714OnMinus0286 = false;
            IsV1OnMinus04 = false;
            IsV07On0 = false;

            IsBlankLevelEqualsBlackLevel = false;
            IsBlankToBlackSetupOrPedestal = false;

            IsSeparateSyncSupported = false;
            IsCompositeSyncSupported = false;
            IsSyncOnGreenSupported = false;
            IsVSyncSerratedOnComposite = false;

            IsAnalogColorMonochrome = false;
            IsAnalogColorRgb = false;
            IsAnalogColorNonRgb = false;
            IsAnalogColorUndefined = false;
        }
    }
}