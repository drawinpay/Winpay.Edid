namespace Edid.Descriptors.Display;

public enum CvtRefreshRateAndBlankingStyle
{
    Hz50AndStandardBlanking = 1 << 4,
    Hz60AndStandardBlanking = 1 << 3,
    Hz75AndStandardBlanking = 1 << 2,
    Hz85AndStandardBlanking = 1 << 1,
    Hz60AndReducedBlanking = 1 << 0
}