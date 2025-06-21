using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexNormalCompressionInfo : IXexCompressionInfo
    {
        public uint WindowSize { get; set; }
        public XexCompressedBlockInfo Block { get; set; }
        
        public XexNormalCompressionInfo(uint windowSize, XexCompressedBlockInfo block)
        {
            WindowSize = windowSize;
            Block = block;
        }

        internal XexNormalCompressionInfo(BinaryStreamReader br)
        {
            WindowSize = br.ReadUInt32();
            Block = new XexCompressedBlockInfo(br);
        }
    }
}
