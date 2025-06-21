using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexDiscProfileIdHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.DiscProfileID;

        public byte[] DiscProfileID { get; init; }

        public XexDiscProfileIdHeader(byte[] discProfileID)
        {
            if (discProfileID.Length != 16)
                throw new ArgumentException($"{nameof(discProfileID)} must be exactly 16 bytes in length.", nameof(discProfileID));

            DiscProfileID = discProfileID;
        }

        internal XexDiscProfileIdHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                DiscProfileID = br.ReadBytes(16);
            }
            br.StepOut();
        }
    }
}
