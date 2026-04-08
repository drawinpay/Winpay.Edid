namespace Edid.Services;

/// <summary>
/// EDID Block Splitter
/// </summary>
public class EdidBlockSplitter
{
    private const int BlockSize = 128;

    /// <summary>
    /// Get EDID block by index (each block is 128 bytes)
    /// </summary>
    /// <param name="edidData"></param>
    /// <param name="blockIndex"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static byte[] GetEdidBlock(byte[] edidData, int blockIndex)
    {
        int offset = blockIndex * BlockSize;
        if (edidData.Length < offset + BlockSize)
        {
            throw new Exception("Insufficient data for EDID block.");
        }

        var block = new byte[BlockSize];
        Array.Copy(edidData, offset, block, 0, BlockSize);
        return block;
    }

    /// <summary>
    /// Get the base EDID block (first 128 bytes)
    /// </summary>
    /// <param name="edidData"></param>
    /// <returns></returns>
    public static byte[] GetBaseEdidBlock(byte[] edidData)
    {
        return GetEdidBlock(edidData, 0);
    }
}