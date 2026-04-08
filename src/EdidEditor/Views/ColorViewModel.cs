using CommunityToolkit.Mvvm.ComponentModel;
using Edid.Data;

namespace EdidEditor.Views
{
    public class ColorViewModel : ObservableObject
    {
        private string _redX = string.Empty;
        private string _redY = string.Empty;
        private string _greenX = string.Empty;
        private string _greenY = string.Empty;
        private string _blueX = string.Empty;
        private string _blueY = string.Empty;
        private string _whiteX = string.Empty;
        private string _whiteY = string.Empty;

        public string RedX
        {
            get => _redX;
            set => SetProperty(ref _redX, value);
        }

        public string RedY
        {
            get => _redY;
            set => SetProperty(ref _redY, value);
        }

        public string GreenX
        {
            get => _greenX;
            set => SetProperty(ref _greenX, value);
        }

        public string GreenY
        {
            get => _greenY;
            set => SetProperty(ref _greenY, value);
        }

        public string BlueX
        {
            get => _blueX;
            set => SetProperty(ref _blueX, value);
        }

        public string BlueY
        {
            get => _blueY;
            set => SetProperty(ref _blueY, value);
        }

        public string WhiteX
        {
            get => _whiteX;
            set => SetProperty(ref _whiteX, value);
        }

        public string WhiteY
        {
            get => _whiteY;
            set => SetProperty(ref _whiteY, value);
        }

        public void SetData(EdidInfo edidInfo)
        {
            RedX = edidInfo.ChromaticityCoordinates.RedX.ToString("0.000");
            RedY = edidInfo.ChromaticityCoordinates.RedY.ToString("0.000");
            GreenX = edidInfo.ChromaticityCoordinates.GreenX.ToString("0.000");
            GreenY = edidInfo.ChromaticityCoordinates.GreenY.ToString("0.000");
            BlueX = edidInfo.ChromaticityCoordinates.BlueX.ToString("0.000");
            BlueY = edidInfo.ChromaticityCoordinates.BlueY.ToString("0.000");
            WhiteX = edidInfo.ChromaticityCoordinates.WhiteX.ToString("0.000");
            WhiteY = edidInfo.ChromaticityCoordinates.WhiteY.ToString("0.000");
        }
    }
}