using Edoke.IO;

namespace XenonFormats
{
    public class XexTlsInfoHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
           => XexOptionalHeaderType.TlsInfo;

        public uint SlotCount { get; set; }
        public uint RawDataPointer { get; set; }
        public uint DataSize { get; set; }
        public uint RawDataSize { get; set; }

        public XexTlsInfoHeader(uint slotCount, uint rawDataPointer, uint dataSize, uint rawDataSize)
        {
            SlotCount = slotCount;
            RawDataPointer = rawDataPointer;
            DataSize = dataSize;
            RawDataSize = rawDataSize;
        }

        internal XexTlsInfoHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                SlotCount = br.ReadUInt32();
                RawDataPointer = br.ReadUInt32();
                DataSize = br.ReadUInt32();
                RawDataSize = br.ReadUInt32();
            }
            br.StepOut();
        }
    }
}
