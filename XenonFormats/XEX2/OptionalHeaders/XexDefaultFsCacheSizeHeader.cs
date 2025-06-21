using Edoke.IO;

namespace XenonFormats
{
    public class XexDefaultFsCacheSizeHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.DefaultFsCacheSize;

        public uint DefaultFsCacheSize { get; set; }

        public XexDefaultFsCacheSizeHeader(uint defaultFsCacheSize)
        {
            DefaultFsCacheSize = defaultFsCacheSize;
        }

        internal XexDefaultFsCacheSizeHeader(BinaryStreamReader br)
        {
            DefaultFsCacheSize = br.ReadUInt32();
        }
    }
}
