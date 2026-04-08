using CommunityToolkit.Mvvm.ComponentModel;
using Edid.Data;
using Edid.GeneralInfo;

namespace EdidEditor.Views
{
    public class GeneralInfoViewModel : ObservableObject
    {
        private string _manufacturerName = string.Empty;
        private string _productCode = string.Empty;
        private string _serialNumber = string.Empty;
        private string _weekOfManufacture = string.Empty;
        private string _yearOfManufacture = string.Empty;
        private string _version = string.Empty;
        private string _revision = string.Empty;

        public string ManufacturerName
        {
            get => _manufacturerName;
            set => SetProperty(ref _manufacturerName, value);
        }

        public string ProductCode
        {
            get => _productCode;
            set => SetProperty(ref _productCode, value);
        }

        public string SerialNumber
        {
            get => _serialNumber;
            set => SetProperty(ref _serialNumber, value);
        }

        public string WeekOfManufacture
        {
            get => _weekOfManufacture;
            set => SetProperty(ref _weekOfManufacture, value);
        }

        public string YearOfManufacture
        {
            get => _yearOfManufacture;
            set => SetProperty(ref _yearOfManufacture, value);
        }

        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        public string Revision
        {
            get => _revision;
            set => SetProperty(ref _revision, value);
        }

        public void SetData(EdidInfo edidInfo)
        {
            ManufacturerName = edidInfo.ProductInfo.ManufacturerId;
            ProductCode = edidInfo.ProductInfo.ProductCode.ToString();
            SerialNumber = edidInfo.ProductInfo.SerialNumber.ToString();

            EdidTime manufactureDate = edidInfo.ProductInfo.ManufactureDate;
            if (manufactureDate.Type == YearType.Model)
            {
                WeekOfManufacture = "Model Year";
            }
            else
            {
                WeekOfManufacture = manufactureDate.Week.ToString();
            }

            YearOfManufacture = manufactureDate.Year.ToString();
            Version = edidInfo.Version.Version.ToString();
            Revision = edidInfo.Version.Revision.ToString();
        }
    }
}