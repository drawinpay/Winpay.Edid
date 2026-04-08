using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Edid.Data;
using Edid.Services;
using Edid.Utils;
using Microsoft.Win32;

namespace EdidEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void MiLoadTextData_OnClick(object sender, RoutedEventArgs e)
        {
            bool result = LoadTextEdidData(out byte[]? edidData);
            if (!result || edidData == null)
            {
                return;
            }

            ParseAndDisplayEdidData(edidData);
        }

        private void MiLoadBinaryData_OnClick(object sender, RoutedEventArgs e)
        {
            bool result = LoadBinaryEdidData(out byte[]? edidData);
            if (!result || edidData == null)
            {
                return;
            }

            ParseAndDisplayEdidData(edidData);
        }


        private void MiExportBinaryData_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void MiExportTextData_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ParseAndDisplayEdidData(byte[] edidData)
        {
            byte[] baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(edidData);
            EdidValidator.ValidBaseEdidBlock(baseEdidBlock);

            var edidInfo = new EdidInfo(edidData);

            PanelRawEdidData.SetData(edidData);
            PanelGeneralInfo.SetData(edidInfo, edidData);
            PanelDisplay.SetData(edidInfo.BasicDisplayInfo);
            PanelColor.SetData(edidInfo);
            PanelEstablishedTimings.SetData(edidInfo);
            PanelStandardTimings.SetData(edidInfo);
            PanelDescriptors.SetData(edidInfo);

            UpdateVisibleSection();
        }

        private void LsbSections_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateVisibleSection();
        }

        private void UpdateVisibleSection()
        {
            if (LsbSections.SelectedItem is not ListBoxItem item || item.Tag is not string tag)
            {
                return;
            }

            PanelGeneralInfo.Visibility = Visibility.Collapsed;
            PanelDisplay.Visibility = Visibility.Collapsed;
            PanelColor.Visibility = Visibility.Collapsed;
            PanelEstablishedTimings.Visibility = Visibility.Collapsed;
            PanelStandardTimings.Visibility = Visibility.Collapsed;
            PanelDescriptors.Visibility = Visibility.Collapsed;

            switch (tag)
            {
                case "GeneralInfo":
                    PanelGeneralInfo.Visibility = Visibility.Visible;
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetGeneralInfoBytesRange());
                    break;
                case "Display":
                    PanelDisplay.Visibility = Visibility.Visible;
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetBasicDisplayInfoBytesRange());
                    break;
                case "Color":
                    PanelColor.Visibility = Visibility.Visible;
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetChromaticityCoordinatesBytesRange());
                    break;
                case "EstablishedTimings":
                    PanelEstablishedTimings.Visibility = Visibility.Visible;
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetEstablishedTimingsBytesRange());
                    break;
                case "StandardTimings":
                    PanelStandardTimings.Visibility = Visibility.Visible;
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetStandardTimingsBytesRange());
                    break;
                case "Descriptor1":
                    ShowDescriptorSection(0);
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetDescriptorBlockBytesRange(0));
                    break;
                case "Descriptor2":
                    ShowDescriptorSection(1);
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetDescriptorBlockBytesRange(1));
                    break;
                case "Descriptor3":
                    ShowDescriptorSection(2);
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetDescriptorBlockBytesRange(2));
                    break;
                case "Descriptor4":
                    ShowDescriptorSection(3);
                    PanelRawEdidData.SetSelectedBytes(BaseEdidDataSplitter.GetDescriptorBlockBytesRange(3));
                    break;
            }
        }

        private void ShowDescriptorSection(int index)
        {
            PanelDescriptors.Visibility = Visibility.Visible;
            PanelDescriptors.ShowDescriptor(index);
        }

        private bool LoadTextEdidData(out byte[]? edidData)
        {
            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != true)
            {
                edidData = null;
                return false;
            }

            string filepath = openFileDialog.FileName;
            string edidDataText = File.ReadAllText(filepath);
            edidData = edidDataText.ParseHexString(new[] { " ", "\r", "\n" });
            return true;
        }

        private bool LoadBinaryEdidData(out byte[]? edidData)
        {
            edidData = null;

            var openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != true)
            {
                return false;
            }

            string filepath = openFileDialog.FileName;
            edidData = File.ReadAllBytes(filepath);
            return true;
        }

        #endregion
    }
}