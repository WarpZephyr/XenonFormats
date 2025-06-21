using Edoke.IO;

namespace XenonFormats
{
    public class XexExecutionIdHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.ExecutionId;

        public uint MediaID { get; set; }
        public XexVersion Version { get; set; }
        public XexVersion BaseVersion { get; set; }
        public XexTitleID TitleID { get; set; }
        public byte Platform { get; set; }
        public byte ExecutableType { get; set; }
        public byte DiscNumber { get; set; }
        public byte DiscCount { get; set; }
        public uint SaveGameID { get; set; }

        public XexExecutionIdHeader(uint mediaID, XexVersion version, XexVersion baseVersion, XexTitleID titleID, byte platform, byte executableType, byte discNumber, byte discCount, uint saveGameID)
        {
            MediaID = mediaID;
            Version = version;
            BaseVersion = baseVersion;
            TitleID = titleID;
            Platform = platform;
            ExecutableType = executableType;
            DiscNumber = discNumber;
            DiscCount = discCount;
            SaveGameID = saveGameID;
        }

        internal XexExecutionIdHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                MediaID = br.ReadUInt32();
                Version = new XexVersion(br);
                BaseVersion = new XexVersion(br);
                TitleID = new XexTitleID(br);
                Platform = br.ReadByte();
                ExecutableType = br.ReadByte();
                DiscNumber = br.ReadByte();
                DiscCount = br.ReadByte();
                SaveGameID = br.ReadUInt32();
            }
            br.StepOut();
        }
    }
}
