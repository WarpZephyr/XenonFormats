using Edoke.IO;

namespace XenonFormats
{
    public class XexResourceInfo
    {
        public string ResourceID { get; set; }
        public uint ResourcePointer { get; set; }
        public uint ResourceSize { get; set; }

        public XexResourceInfo(string resourceID, uint resourcePointer, uint resourceSize)
        {
            ResourceID = resourceID;
            ResourcePointer = resourcePointer;
            ResourceSize = resourceSize;
        }

        internal XexResourceInfo(BinaryStreamReader br)
        {
            ResourceID = br.ReadASCII(8);
            ResourcePointer = br.ReadUInt32();
            ResourceSize = br.ReadUInt32();
        }
    }
}
