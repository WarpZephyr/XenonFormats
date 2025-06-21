using Edoke.IO;

namespace XenonFormats
{
    public class XexDefaultHeapSizeHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.DefaultHeapSize;

        public uint DefaultHeapSize { get; set; }

        public XexDefaultHeapSizeHeader(uint defaultHeapSize)
        {
            DefaultHeapSize = defaultHeapSize;
        }

        internal XexDefaultHeapSizeHeader(BinaryStreamReader br)
        {
            DefaultHeapSize = br.ReadUInt32();
        }
    }
}
