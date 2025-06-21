using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexPageDescriptor
    {
        private uint BitField;

        public uint PageCount
        {
            get => BitField >>> 4;
            set => BitField = (BitField & 0b00000000_00000000_00000000_00001111U) | (value << 4);
        }

        public XexSectionType SectionType
        {
            get => (XexSectionType)(BitField & 0b00000000_00000000_00000000_00001111U);
            set => BitField = (BitField & 0b11111111_11111111_11111111_11110000U) | ((uint)(value) & 0b00000000_00000000_00000000_00001111U);
        }

        public byte[] DataDigest { get; init; }

        public XexPageDescriptor(uint bitField, byte[] dataDigest)
        {
            if (dataDigest.Length != 20)
                throw new ArgumentException($"{nameof(dataDigest)} must be exactly 20 bytes in length.", nameof(dataDigest));

            BitField = bitField;
            DataDigest = dataDigest;
        }

        internal XexPageDescriptor(BinaryStreamReader br)
        {
            BitField = br.ReadUInt32();
            DataDigest = br.ReadBytes(20);
        }
    }
}
