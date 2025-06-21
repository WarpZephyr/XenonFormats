using Edoke.IO;

namespace XenonFormats
{
    public class XexDefaultStackSizeHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.DefaultStackSize;

        public uint DefaultStackSize { get; set; }

        public XexDefaultStackSizeHeader(uint defaultStackSize)
        {
            DefaultStackSize = defaultStackSize;
        }

        internal XexDefaultStackSizeHeader(BinaryStreamReader br)
        {
            DefaultStackSize = br.ReadUInt32();
        }
    }
}
