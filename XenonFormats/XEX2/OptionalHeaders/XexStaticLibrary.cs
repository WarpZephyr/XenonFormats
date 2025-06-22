using Edoke.IO;

namespace XenonFormats
{
    public class XexStaticLibrary
    {
        public string Name { get; set; }
        public ushort MajorVersion { get; set; }
        public ushort MinorVersion { get; set; }
        public ushort Build { get; set; }
        public XexApprovalType ApprovalType { get; set; }
        public byte QFE { get; set; }

        public XexStaticLibrary(string name, ushort majorVersion, ushort minorVersion, ushort build, XexApprovalType approvalType, byte qfe)
        {
            Name = name;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            Build = build;
            ApprovalType = approvalType;
            QFE = qfe;
        }

        internal XexStaticLibrary(BinaryStreamReader br)
        {
            Name = br.ReadASCII(8).Replace("\0", string.Empty);
            MajorVersion = br.ReadUInt16();
            MinorVersion = br.ReadUInt16();
            Build = br.ReadUInt16();
            ApprovalType = br.ReadEnumByte<XexApprovalType>();
            QFE = br.ReadByte();
        }
    }
}
