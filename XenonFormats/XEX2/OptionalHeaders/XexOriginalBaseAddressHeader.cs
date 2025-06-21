using Edoke.IO;

namespace XenonFormats
{
    public class XexOriginalBaseAddressHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.OriginalBaseAddress;

        public uint OriginalBaseAddress { get; set; }

        public XexOriginalBaseAddressHeader(uint originalBaseAddress)
        {
            OriginalBaseAddress = originalBaseAddress;
        }

        internal XexOriginalBaseAddressHeader(BinaryStreamReader br)
        {
            OriginalBaseAddress = br.ReadUInt32();
        }
    }
}
