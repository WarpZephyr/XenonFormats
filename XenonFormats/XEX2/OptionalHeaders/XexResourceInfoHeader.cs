using Edoke.IO;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexResourceInfoHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.ResourceInfo;

        public List<XexResourceInfo> Resources { get; set; }
        public XexResourceInfoHeader(List<XexResourceInfo> resources)
        {
            Resources = resources;
        }

        internal XexResourceInfoHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                int entrySize = headerSize / 16;
                Resources = new List<XexResourceInfo>(entrySize);
                for (int i = 0; i < entrySize; i++)
                {
                    Resources.Add(new XexResourceInfo(br));
                }
            }
            br.StepOut();
        }
    }
}
