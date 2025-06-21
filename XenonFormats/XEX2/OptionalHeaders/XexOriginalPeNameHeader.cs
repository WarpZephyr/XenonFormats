using Edoke.IO;

namespace XenonFormats
{
    public class XexOriginalPeNameHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.OriginalPeName;

        public string OriginalPeName { get; set; }

        public XexOriginalPeNameHeader(string originalPeName)
        {
            OriginalPeName = originalPeName;
        }

        internal XexOriginalPeNameHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                OriginalPeName = br.ReadASCII(headerSize - sizeof(int));
            }
            br.StepOut();
        }
    }
}
