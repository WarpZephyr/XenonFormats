using Edoke.IO;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexAlternateTitleIdsHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.AlternateTitleIds;

        public List<uint> TitleIDs;

        public XexAlternateTitleIdsHeader(List<uint> titleIDs)
        {
            TitleIDs = titleIDs;
        }

        internal XexAlternateTitleIdsHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                int entryCount = (headerSize - sizeof(int)) / sizeof(int);
                TitleIDs = new List<uint>(entryCount);
                for (int i = 0; i < entryCount; i++)
                {
                    TitleIDs.Add(br.ReadUInt32());
                }
            }
            br.StepOut();
        }
    }
}
