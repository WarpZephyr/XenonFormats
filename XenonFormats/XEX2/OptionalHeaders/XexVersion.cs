using Edoke.IO;

namespace XenonFormats
{
    public struct XexVersion
    {
        private uint BitField;

        public byte QFE
        {
            readonly get => (byte)(BitField >>> 24);
            set => BitField = ((BitField & 0b00000000_11111111_11111111_11111111U) | ((uint)(value) << 24));
        }

        public ushort Build
        {
            readonly get => (ushort)(BitField >>> 16);
            set => BitField = ((BitField & 0b11111111_00000000_00000000_11111111U) | ((uint)(value) << 16));
        }

        public byte Minor
        {
            readonly get => (byte)((BitField & 0b1111_0000U) >>> 4);
            set => BitField = ((BitField & 0b11111111_11111111_11111111_00001111U) | ((uint)(value) << 4));
        }

        public byte Major
        {
            readonly get => (byte)(BitField & 0b1111U);
            set => BitField = ((BitField & 0b11111111_11111111_11111111_11110000U) | ((uint)(value)));
        }


        public XexVersion(uint value)
        {
            BitField = value;
        }

        internal XexVersion(BinaryStreamReader br)
        {
            BitField = br.ReadUInt32();
        }
    }
}
