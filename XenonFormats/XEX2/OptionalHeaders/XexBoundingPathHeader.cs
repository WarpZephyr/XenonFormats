using Edoke.IO;

namespace XenonFormats
{
    public class XexBoundingPathHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.BoundingPath;

        public string BoundingPath { get; set; }

        public XexBoundingPathHeader(string boundingPath)
        {
            BoundingPath = boundingPath;
        }

        internal XexBoundingPathHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                BoundingPath = br.ReadASCII(headerSize);
            }
            br.StepOut();
        }
    }
}
