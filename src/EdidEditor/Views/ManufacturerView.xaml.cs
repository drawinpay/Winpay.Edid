using System.Windows.Controls;
using Edid.GeneralInfo;
using Edid.Services;
using Edid.Utils;

namespace EdidEditor.Views
{
    /// <summary>
    /// ManufacturerView.xaml 的交互逻辑
    /// </summary>
    public partial class ManufacturerView : UserControl
    {
        private readonly List<TextBox> _byteTextBoxList = new();
        private readonly List<TextBox> _bitTextBoxList = new();
        private readonly List<TextBox> _charTextBoxList = new();

        private byte[]? _edidData;

        public ManufacturerView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            GridRoot.RowDefinitions.Add(new RowDefinition());
            GridRoot.RowDefinitions.Add(new RowDefinition());
            GridRoot.RowDefinitions.Add(new RowDefinition());

            for (var i = 0; i < 16; i++)
            {
                GridRoot.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (var i = 0; i < 2; i++)
            {
                var tb = new TextBox
                {
                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center
                };

                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i * 8);
                Grid.SetColumnSpan(tb, 8);
                GridRoot.Children.Add(tb);
                _byteTextBoxList.Add(tb);
            }

            for (var i = 0; i < 16; i++)
            {
                var tb = new TextBox
                {
                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                    IsReadOnly = true
                };

                Grid.SetRow(tb, 1);
                Grid.SetColumn(tb, i);
                GridRoot.Children.Add(tb);
                _bitTextBoxList.Add(tb);
            }


            var tb1 = new TextBox
            {
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                Text = "/",
                IsReadOnly = true
            };
            Grid.SetRow(tb1, 2);
            Grid.SetColumn(tb1, 0);
            GridRoot.Children.Add(tb1);

            for (var i = 0; i < 3; i++)
            {
                var tb = new TextBox
                {
                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center
                };

                Grid.SetRow(tb, 2);
                Grid.SetColumn(tb, i * 5 + 1);
                Grid.SetColumnSpan(tb, 5);
                GridRoot.Children.Add(tb);
                _charTextBoxList.Add(tb);
            }
        }

        public void SetEdidData(byte[] edidData)
        {
            _edidData = edidData;

            var baseEdidBlock = EdidBlockSplitter.GetBaseEdidBlock(edidData);
            EdidValidator.ValidBaseEdidBlock(baseEdidBlock);

            var bitReader = new BitReader(baseEdidBlock);
            var byteRange = BaseEdidDataSplitter.GetManufacturerIdBytesRange();
            var manufacturerData = bitReader.ReadBytes(byteRange.StartIndex, byteRange.Length);
            for (var i = 0; i < manufacturerData.Length; i++)
            {
                _byteTextBoxList[i].Text = manufacturerData[i].ToString("X2");
            }

            for (var i = 0; i < 8; i++)
            {
                _bitTextBoxList[i].Text = ((manufacturerData[0] >> (7 - i)) & 0x1).ToString();
            }

            for(var i = 0; i < 8; i++)
            {
                _bitTextBoxList[i + 8].Text = ((manufacturerData[1] >> (7 - i)) & 0x1).ToString();
            }
           
            var manufacturerName = IsaPnpIdParser.ToIsaPnpId(manufacturerData);
            for (var i = 0; i < manufacturerName.Length; i++)
            {
                _charTextBoxList[i].Text = manufacturerName[i].ToString();
            }
        }
    }
}
