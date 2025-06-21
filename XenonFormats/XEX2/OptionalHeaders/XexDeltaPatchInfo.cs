using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexDeltaPatchInfo
    {
        public uint OldAddress { get; set; }
        public uint NewAddress { get; set; }
        public ushort UncompressedSize { get; set; }
        public ushort CompressedSize { get; set; }
        public byte[] Data { get; set; }

        public XexDeltaPatchInfo(uint oldAddress, uint newAddress, ushort uncompressedSize, ushort compressedSize, byte[] data)
        {
            if (compressedSize > 0 && data.Length != compressedSize)
                throw new ArgumentException($"{nameof(compressedSize)} is greater than 0 but {nameof(data)} does not match it in length.", nameof(compressedSize));
            else if (uncompressedSize > 0 && data.Length != uncompressedSize)
                throw new ArgumentException($"{nameof(uncompressedSize)} is greater than 0 and {nameof(compressedSize)} is not but {nameof(data)} does not match {nameof(uncompressedSize)} in length.", nameof(uncompressedSize));

            OldAddress = oldAddress;
            NewAddress = newAddress;
            UncompressedSize = uncompressedSize;
            CompressedSize = compressedSize;
            Data = data;
        }

        internal XexDeltaPatchInfo(BinaryStreamReader br)
        {
            OldAddress = br.ReadUInt32();
            NewAddress = br.ReadUInt32();
            UncompressedSize = br.ReadUInt16();
            CompressedSize = br.ReadUInt16();
            Data = br.ReadBytes(CompressedSize < 1 ? UncompressedSize : CompressedSize);
        }
    }
}
