using Edoke.IO;

namespace XenonFormats
{
    public class XexImageBaseAddressHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.ImageBaseAddress;

        public uint ImageBaseAddress { get; set; }

        public XexImageBaseAddressHeader(uint imageBaseAddress)
        {
            ImageBaseAddress = imageBaseAddress;
        }

        internal XexImageBaseAddressHeader(BinaryStreamReader br)
        {
            ImageBaseAddress = br.ReadUInt32();
        }
    }
}
