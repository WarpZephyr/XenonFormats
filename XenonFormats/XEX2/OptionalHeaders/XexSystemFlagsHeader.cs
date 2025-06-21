using Edoke.IO;

namespace XenonFormats
{
    public class XexSystemFlagsHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.SystemFlags;

        public XexSystemFlags SystemFlags { get; set; }

        public XexSystemFlagsHeader(XexSystemFlags systemFlags)
        {
            SystemFlags = systemFlags;
        }

        internal XexSystemFlagsHeader(BinaryStreamReader br)
        {
            SystemFlags = (XexSystemFlags)br.ReadUInt32();
        }
    }
}
