using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexCompressedBlockInfo
    {
        public uint BlockSize { get; set; }
        public byte[] BlockHash { get; init; }

        public XexCompressedBlockInfo(uint blockSize, byte[] blockHash)
        {
            if (blockHash.Length != 20)
                throw new ArgumentException($"{nameof(blockHash)} must be exactly 20 bytes in length.", nameof(blockHash));

            BlockSize = blockSize;
            BlockHash = blockHash;
        }

        internal XexCompressedBlockInfo(BinaryStreamReader br)
        {
            BlockSize = br.ReadUInt32();
            BlockHash = br.ReadBytes(20);
        }
    }
}
