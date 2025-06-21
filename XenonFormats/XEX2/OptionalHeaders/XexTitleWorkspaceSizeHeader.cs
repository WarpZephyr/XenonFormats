using Edoke.IO;

namespace XenonFormats
{
    public class XexTitleWorkspaceSizeHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.TitleWorkspaceSize;

        public uint TitleWorkspaceSize { get; set; }

        public XexTitleWorkspaceSizeHeader(uint titleWorkspaceSize)
        {
            TitleWorkspaceSize = titleWorkspaceSize;
        }
        
        internal XexTitleWorkspaceSizeHeader(BinaryStreamReader br)
        {
            TitleWorkspaceSize = br.ReadUInt32();
        }
    }
}
