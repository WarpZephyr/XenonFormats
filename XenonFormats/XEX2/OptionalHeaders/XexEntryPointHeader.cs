using Edoke.IO;

namespace XenonFormats
{
    public class XexEntryPointHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.EntryPoint;

        public uint EntryPoint { get; set; }

        public XexEntryPointHeader(uint entryPoint)
        {
            EntryPoint = entryPoint;
        }

        internal XexEntryPointHeader(BinaryStreamReader br)
        {
            EntryPoint = br.ReadUInt32();
        }
    }
}
