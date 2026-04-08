using Edid.Timing;

namespace EdidEditor.Views
{
    public sealed class EstablishedTimingItem
    {
        public string Text { get; }

        public bool IsEnabled { get; }

        public EstablishedTimingItem(string text, bool isEnabled)
        {
            Text = text;
            IsEnabled = isEnabled;
        }

        public static EstablishedTimingItem FromTiming(EstablishedTiming timing)
        {
            return new EstablishedTimingItem(BuildText(timing), timing.IsEnable);
        }

        private static string BuildText(EstablishedTiming timing)
        {
            if (timing.Width == 1024 && timing.Height == 768 && timing.Frequency == 87)
            {
                return "1024¡Á768 @ 87 Hz, interlaced (1024¡Á768i)";
            }

            return $"{timing.Width}¡Á{timing.Height} @ {timing.Frequency} Hz";
        }
    }
}