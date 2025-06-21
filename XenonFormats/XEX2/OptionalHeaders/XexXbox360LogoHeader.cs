using Edoke.IO;

namespace XenonFormats
{
    public class XexXbox360LogoHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.Xbox360Logo;

        public byte[] Xbox360Logo { get; set; }

        public XexXbox360LogoHeader(byte[] xbox360Logo)
        {
            Xbox360Logo = xbox360Logo;
        }

        internal XexXbox360LogoHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                Xbox360Logo = br.ReadBytes(headerSize - sizeof(int));
            }
            br.StepOut();
        }
    }
}
