using Edoke.IO;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexStaticLibrariesHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.StaticLibraries;

        public List<XexStaticLibrary> StaticLibraries { get; set; }

        public XexStaticLibrariesHeader(List<XexStaticLibrary> staticLibraries)
        {
            StaticLibraries = staticLibraries;
        }

        internal XexStaticLibrariesHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                const int entrySize = 16;
                int entryCount = headerSize / entrySize;

                StaticLibraries = new List<XexStaticLibrary>(entryCount);
                for (int i = 0; i < entryCount; i++)
                {
                    StaticLibraries.Add(new XexStaticLibrary(br));
                }
            }
            br.StepOut();
        }
    }
}
