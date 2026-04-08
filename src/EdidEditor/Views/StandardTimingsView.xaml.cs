using System.Windows.Controls;
using Edid.Data;
using Edid.Timing;

namespace EdidEditor.Views
{
    public partial class StandardTimingsView : UserControl
    {
        public StandardTimingsView()
        {
            InitializeComponent();
        }

        public void SetData(EdidInfo edidInfo)
        {
            int count = edidInfo.StandardTimings.Timings.Count;
            var items = new StandardTimingDisplayItem[count];

            for (int i = 0; i < count; i++)
            {
                StandardTiming timing = edidInfo.StandardTimings.Timings[i];
                items[i] = new StandardTimingDisplayItem(i + 1, timing);
            }

            LsbStandardTimings.ItemsSource = items;
        }

        private sealed class StandardTimingDisplayItem
        {
            public string Title { get; }

            public bool IsUnused { get; }

            public string Width { get; }

            public string Frequency { get; }

            public bool IsAspectRatio16By10 { get; }

            public bool IsAspectRatio4By3 { get; }

            public bool IsAspectRatio5By4 { get; }

            public bool IsAspectRatio16By9 { get; }

            public StandardTimingDisplayItem(int index, StandardTiming timing)
            {
                Title = $"Standard Timing #{index}";

                if (timing.IsUnused)
                {
                    IsUnused = true;
                    Width = string.Empty;
                    Frequency = string.Empty;
                    return;
                }

                Width = timing.Width.ToString();
                Frequency = timing.Frequency.ToString();

                IsAspectRatio16By10 = HasAspectRatio(timing, 16, 10);
                IsAspectRatio4By3 = HasAspectRatio(timing, 4, 3);
                IsAspectRatio5By4 = HasAspectRatio(timing, 5, 4);
                IsAspectRatio16By9 = HasAspectRatio(timing, 16, 9);
            }

            private static bool HasAspectRatio(StandardTiming timing, int horizontal, int vertical)
            {
                return timing.AspectRatio.Horizontal == horizontal
                       && timing.AspectRatio.Vertical == vertical;
            }
        }
    }
}