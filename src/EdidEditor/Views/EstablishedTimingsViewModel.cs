using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Edid.Data;
using Edid.Timing;

namespace EdidEditor.Views
{
    public class EstablishedTimingsViewModel : ObservableObject
    {
        public ObservableCollection<EstablishedTimingItem> EstablishedTimings1 { get; } = new ObservableCollection<EstablishedTimingItem>();

        public ObservableCollection<EstablishedTimingItem> EstablishedTimings2 { get; } = new ObservableCollection<EstablishedTimingItem>();

        public ObservableCollection<EstablishedTimingItem> ManufacturerTimings { get; } = new ObservableCollection<EstablishedTimingItem>();

        public void SetData(EdidInfo edidInfo)
        {
            SetItems(EstablishedTimings1, edidInfo.EstablishedTimings.EstablishedTimings1.Timings);
            SetItems(EstablishedTimings2, edidInfo.EstablishedTimings.EstablishedTimings2.Timings);
            SetItems(ManufacturerTimings, edidInfo.EstablishedTimings.ManufacturerTimings.Timings);
        }

        private static void SetItems(ObservableCollection<EstablishedTimingItem> target, ReadOnlyCollection<EstablishedTiming> timings)
        {
            target.Clear();

            for (int i = 0; i < timings.Count; i++)
            {
                target.Add(EstablishedTimingItem.FromTiming(timings[i]));
            }
        }
    }
}