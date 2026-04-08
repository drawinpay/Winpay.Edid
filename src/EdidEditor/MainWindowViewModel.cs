using System.IO;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Edid.Services;
using Edid.Utils;
using Microsoft.Win32;

namespace EdidEditor
{
    internal class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private string? _edidContent;
        private byte[]? _edidData;

        #endregion

        #region Properties

        public string? EdidContent
        {
            get => _edidContent;
            set => SetProperty(ref _edidContent, value);
        }

        public ICommand? LoadBinaryDataCommand { get; set; }
        public ICommand? LoadTextDataCommand { get; set; }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            LoadBinaryDataCommand = new RelayCommand(LoadBinaryEdidData);
            LoadTextDataCommand = new RelayCommand(LoadTextEdidData);
        }

        #endregion

        #region Private Methods

        private void LoadTextEdidData()
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != true) return;
            string filepath = openFileDialog.FileName;
            string edidDataText = File.ReadAllText(filepath);
            byte[] edidData = edidDataText.ParseHexString(new[] { " ", "\r", "\n" });
            EdidContent = BinaryDataToString(edidData);

            _edidData = edidData;

            var baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(edidData);
            EdidValidator.ValidBaseEdidBlock(baseEdidBlock);

            //BaseEdidParser baseEdidParser = new BaseEdidParser(baseEdidBlock);
            //var manufacturerData = baseEdidParser.GetManufacturerIdBytes();
            //var manufacturerName = IsaPnpIdParser.ToIsaPnpId(manufacturerData);
        }

        private void LoadBinaryEdidData()
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != true) return;
            string filepath = openFileDialog.FileName;
            byte[] edidData = File.ReadAllBytes(filepath);
            EdidContent = BinaryDataToString(edidData);
            _edidData = edidData;

            var baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(edidData);
            EdidValidator.ValidBaseEdidBlock(baseEdidBlock);

            //BaseEdidParser baseEdidParser = new BaseEdidParser(baseEdidBlock);
            //var manufacturerData = baseEdidParser.GetManufacturerIdBytes();
            //var manufacturerName = IsaPnpIdParser.ToIsaPnpId(manufacturerData);
        }

        private string BinaryDataToString(byte[] data)
        {
            var rowDataLength = 32;
            int rowCount = data.Length / rowDataLength;
            if(data.Length % rowDataLength != 0)
            {
                rowCount += 1;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < rowCount; i++)
            {
                var subData = data.Skip(i * rowDataLength).Take(rowDataLength).ToArray();
                sb.Append(subData.BytesToHexString(" "));
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        #endregion
    }
}
