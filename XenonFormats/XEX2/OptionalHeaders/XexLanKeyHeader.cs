using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexLanKeyHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.LanKey;

        public byte[] LanKey { get; init; }

        public XexLanKeyHeader(byte[] lanKey)
        {
            if (lanKey.Length != 16)
                throw new ArgumentException($"{nameof(lanKey)} must be exactly 16 bytes in length.", nameof(lanKey));

            LanKey = lanKey;
        }

        internal XexLanKeyHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                LanKey = br.ReadBytes(16);
            }
            br.StepOut();
        }
    }
}
