using Edoke.IO;

namespace XenonFormats
{
    public class XexFileBasicCompressionInfo : IXexCompressionInfo
    {
        public XexFileBasicCompressionBlock Block { get; set; }

        public XexFileBasicCompressionInfo(XexFileBasicCompressionBlock block)
        {
            Block = block;
        }

        internal XexFileBasicCompressionInfo(BinaryStreamReader br)
        {
            Block = new XexFileBasicCompressionBlock(br);
        }
    }
}
