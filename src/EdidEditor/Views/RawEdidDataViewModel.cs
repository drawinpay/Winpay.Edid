using CommunityToolkit.Mvvm.ComponentModel;
using Edid.Common;
using EdidEditor.Views.Models;

namespace EdidEditor.Views
{
    public class RawEdidDataViewModel : ObservableObject
    {
        private const int BlockLength = 128;

        private IReadOnlyList<IReadOnlyList<ByteModel>> _blocks = Array.Empty<IReadOnlyList<ByteModel>>();
        private readonly List<ByteModel> _allBytes = new();

        public IReadOnlyList<IReadOnlyList<ByteModel>> Blocks
        {
            get => _blocks;
            private set => SetProperty(ref _blocks, value);
        }

        public void SetData(byte[]? edidData)
        {
            Blocks = CreateBlocks(edidData ?? Array.Empty<byte>());
        }

        private IReadOnlyList<IReadOnlyList<ByteModel>> CreateBlocks(byte[] data)
        {
            if (data.Length % BlockLength != 0)
            {
                throw new ArgumentException($"Data length must be a multiple of {BlockLength}.", nameof(data));
            }

            if (data.Length == 0)
            {
                return Array.Empty<IReadOnlyList<ByteModel>>();
            }

            for (var i = 0; i < data.Length; i++)
            {
                var byteModel = new ByteModel(data[i], i);
                _allBytes.Add(byteModel);
            }

            var blocks = new List<IReadOnlyList<ByteModel>>();
            int blockCount = data.Length / BlockLength;
            for (var blockIndex = 0; blockIndex < blockCount; blockIndex++)
            {
                int startIndex = blockIndex * BlockLength;
                List<ByteModel> block = _allBytes.Skip(startIndex).Take(BlockLength).ToList();
                blocks.Add(block);
            }

            return blocks;
        }

        public void SetSelectedBytes(ByteRange byteRange)
        {
            foreach (ByteModel byteModel in _allBytes)
            {
                byteModel.IsSelected = false;
            }

            for (int i = byteRange.StartIndex; i < byteRange.StartIndex + byteRange.Length; i++)
            {
                if (i >= 0 && i < _allBytes.Count)
                {
                    _allBytes[i].IsSelected = true;
                }
            }
        }
    }
}