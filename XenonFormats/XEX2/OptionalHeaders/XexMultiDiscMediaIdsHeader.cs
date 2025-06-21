using Edoke.IO;
using System;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexMultiDiscMediaIdsHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.MultidiscMediaIds;

        public List<byte[]> XGD2MediaIds;

        public XexMultiDiscMediaIdsHeader(List<byte[]> xgd2MediaIds)
        {
            for (int i = 0; i < xgd2MediaIds.Count; i++)
                if (xgd2MediaIds[i].Length != 16)
                    throw new ArgumentException($"{nameof(xgd2MediaIds)}[{i}] must be exactly 16 bytes in length.", nameof(xgd2MediaIds));

            XGD2MediaIds = xgd2MediaIds;
        }

        internal XexMultiDiscMediaIdsHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                const int idSize = 16;
                int idCount = headerSize / idSize;
                XGD2MediaIds = new List<byte[]>(idCount);
                for (int i = 0; i < idCount; i++)
                {
                    XGD2MediaIds.Add(br.ReadBytes(idSize));
                }
            }
            br.StepOut();
        }
    }
}
