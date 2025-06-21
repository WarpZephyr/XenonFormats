using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexChecksumTimestampHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.ChecksumTimestamp;

        public uint Checksum { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public XexChecksumTimestampHeader(uint checksum, DateTimeOffset timestamp)
        {
            Checksum = checksum;
            Timestamp = timestamp;
        }

        internal XexChecksumTimestampHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                Checksum = br.ReadUInt32();
                Timestamp = DateTimeOffset.FromUnixTimeSeconds(br.ReadUInt32());
            }
            br.StepOut();
        }
    }
}
