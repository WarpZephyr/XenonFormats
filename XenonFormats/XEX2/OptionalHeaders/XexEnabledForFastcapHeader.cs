using Edoke.IO;

namespace XenonFormats
{
    public class XexEnabledForFastcapHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.EnabledForFastcap;

        public uint EnabledForFastcap { get; set; }

        public XexEnabledForFastcapHeader(uint enabledForFastcap)
        {
            EnabledForFastcap = enabledForFastcap;
        }

        internal XexEnabledForFastcapHeader(BinaryStreamReader br)
        {
            EnabledForFastcap = br.ReadUInt32();
        }
    }
}
