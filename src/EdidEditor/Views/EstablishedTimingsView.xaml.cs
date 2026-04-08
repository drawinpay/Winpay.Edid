using System.Collections.ObjectModel;
using System.Windows.Controls;
using Edid.Data;
using Edid.Timing;

namespace EdidEditor.Views
{
    public partial class EstablishedTimingsView : UserControl
    {
        public EstablishedTimingsView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo)
        {
            LsbEstablishedTimings1.ItemsSource = CreateEstablishedTimingDisplayItems(edidInfo.EstablishedTimings.EstablishedTimings1.Timings);
            LsbEstablishedTimings2.ItemsSource = CreateEstablishedTimingDisplayItems(edidInfo.EstablishedTimings.EstablishedTimings2.Timings);
            LsbManufacturerTimings.ItemsSource = CreateEstablishedTimingDisplayItems(edidInfo.EstablishedTimings.ManufacturerTimings.Timings);
        }

        private static EstablishedTimingDisplayItem[] CreateEstablishedTimingDisplayItems(ReadOnlyCollection<EstablishedTiming> timings)
        {
            var items = new EstablishedTimingDisplayItem[timings.Count];
            for (int i = 0; i < timings.Count; i++)
            {
                EstablishedTiming timing = timings[i];
                items[i] = new EstablishedTimingDisplayItem(BuildEstablishedTimingText(timing), timing.IsEnable);
            }

            return items;
        }

        private static string BuildEstablishedTimingText(EstablishedTiming timing)
        {
            if (timing.Width == 1024 && timing.Height == 768 && timing.Frequency == 87)
            {
                return "1024¡Á768 @ 87 Hz, interlaced (1024¡Á768i)";
            }

            return $"{timing.Width}¡Á{timing.Height} @ {timing.Frequency} Hz";
        }

        private sealed class EstablishedTimingDisplayItem
        {
            public string Text { get; }

            public bool IsEnabled { get; }

            public EstablishedTimingDisplayItem(string text, bool isEnabled)
            {
                Text = text;
                IsEnabled = isEnabled;
            }
        }
    }
}