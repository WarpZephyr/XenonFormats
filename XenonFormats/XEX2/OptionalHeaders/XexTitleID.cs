using Edoke.IO;
using System;

namespace XenonFormats
{
    public struct XexTitleID
    {
        public char A { get; set; }
        public char B { get; set; }
        public ushort ID { get; set; }

        public XexTitleID(BinaryStreamReader br)
        {
            A = (char)br.ReadByte();
            B = (char)br.ReadByte();
            ID = br.ReadUInt16();
        }

        public override readonly string ToString()
            => $"{A}{B}{ID}";

        public readonly int ToInt32()
            => BitConverter.IsLittleEndian ?
            ((ID << 16) | (((byte)B) << 8) | ((byte)A)) :
            ((((byte)A) << 24) | (((byte)B) << 16) | ID);

        public readonly uint ToUInt32()
            => (uint)(BitConverter.IsLittleEndian ?
            ((ID << 16) | (((byte)B) << 8) | ((byte)A)) :
            ((((byte)A) << 24) | (((byte)B) << 16) | ID));

        public readonly string ToHex()
            => HexHelper.ToHex(A, B, ID);
    }
}
