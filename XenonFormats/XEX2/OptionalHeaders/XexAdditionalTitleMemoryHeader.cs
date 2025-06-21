using Edoke.IO;

namespace XenonFormats
{
    public class XexAdditionalTitleMemoryHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.AdditionalTitleMemory;

        public uint AdditionalTitleMemory { get; set; }

        public XexAdditionalTitleMemoryHeader(uint additionalTitleMemory)
        {
            AdditionalTitleMemory = additionalTitleMemory;
        }

        internal XexAdditionalTitleMemoryHeader(BinaryStreamReader br)
        {
            AdditionalTitleMemory = br.ReadUInt32();
        }
    }
}
