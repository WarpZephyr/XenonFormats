using Edoke.IO;

namespace XenonFormats
{
    public class XexFileFormatInfoHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.FileFormatInfo;

        public XexEncryptionType EncryptionType { get; set; }
        public XexCompressionType CompressionType { get; set; }
        public IXexCompressionInfo? CompressionInfo { get; set; }

        public XexFileFormatInfoHeader(XexEncryptionType encryptionType, XexCompressionType compressionType, IXexCompressionInfo? compressionInfo)
        {
            EncryptionType = encryptionType;
            CompressionType = compressionType;
            CompressionInfo = compressionInfo;
        }

        internal XexFileFormatInfoHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                EncryptionType = br.ReadEnumUInt16<XexEncryptionType>();
                CompressionType = br.ReadEnumUInt16<XexCompressionType>();
                switch (CompressionType)
                {
                    case XexCompressionType.Basic:
                        CompressionInfo = new XexFileBasicCompressionInfo(br);
                        break;
                    case XexCompressionType.Normal:
                        CompressionInfo = new XexNormalCompressionInfo(br);
                        break;
                }
            }
            br.StepOut();
        }
    }
}
