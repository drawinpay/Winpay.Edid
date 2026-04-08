using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EdidEditor.Views.Models
{
    public class ByteModel : ObservableObject
    {
        #region Fields

        private byte _value;
        private int _index;
        private bool _isSelected;

        #endregion

        #region Properties

        public byte Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);
                OnPropertyChanged(nameof(HexValue));
            }
        }

        public int Index
        {
            get => _index;
            set => SetProperty(ref _index, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Background));
            }
        }

        public Brush Background
        {
            get
            {
                return IsSelected ? Brushes.LightBlue : Brushes.Transparent;
            }
        }

        public string HexValue => $"{_value:X2}";

        #endregion

        #region Constructors

        public ByteModel(byte value, int index)
        {
            _value = value;
            _index = index;
        }

        public ByteModel()
        {

        }

        #endregion
    }
}
