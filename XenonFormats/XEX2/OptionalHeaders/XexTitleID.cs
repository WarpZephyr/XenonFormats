using Edoke.IO;

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
    }
}
