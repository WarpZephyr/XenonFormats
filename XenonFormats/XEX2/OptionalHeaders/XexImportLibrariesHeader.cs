using Edoke.IO;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexImportLibrariesHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.ImportLibraries;

        public List<XexImportLibrary> ImportLibraries { get; set; }

        public XexImportLibrariesHeader(List<XexImportLibrary> importLibraries)
        {
            ImportLibraries = importLibraries;
        }

        internal XexImportLibrariesHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                int stringsSize = br.ReadInt32();
                int entryCount = br.ReadInt32();
                ImportLibraries = new List<XexImportLibrary>(entryCount);

                long stringsOffset = br.Position;
                long stringOffset = stringsOffset;
                br.StepIn(stringsOffset + stringsSize);
                {
                    for (int i = 0; i < entryCount; i++)
                    {
                        string name = br.GetASCII(stringOffset);
                        ImportLibraries.Add(new XexImportLibrary(br, name));
                        stringOffset += name.Length + 1;
                    }
                }
                br.StepOut();
            }
            br.StepOut();
        }
    }
}
