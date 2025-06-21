using Edoke.IO;

namespace XenonFormats
{
    public class XexFileBasicCompressionBlock
    {
        public uint DataSize { get; set; }
        public uint ZeroSize { get; set; }

        public XexFileBasicCompressionBlock(uint dataSize, uint zeroSize)
        {
            DataSize = dataSize;
            ZeroSize = zeroSize;

            // TODO: Type isn't complete.
        }

        internal XexFileBasicCompressionBlock(BinaryStreamReader br)
        {
            DataSize = br.ReadUInt32();
            ZeroSize = br.ReadUInt32();

            // TODO: Type isn't complete.
        }
    }
}
