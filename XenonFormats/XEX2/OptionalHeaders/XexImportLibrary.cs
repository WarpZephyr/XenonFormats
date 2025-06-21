using Edoke.IO;
using System;
using System.Collections.Generic;

namespace XenonFormats
{
    public class XexImportLibrary
    {
        public string Name { get; set; }
        public byte[] NextImportDigest { get; set; }
        public uint ID { get; set; }
        public XexVersion Version { get; set; }
        public XexVersion MinVersion { get; set; }
        public List<uint> Thunks { get; set; }

        public XexImportLibrary(string name, byte[] nextImportDigest, uint id, XexVersion version, XexVersion minVersion, List<uint> thunks)
        {
            if (nextImportDigest.Length != 20)
                throw new ArgumentException($"{nameof(nextImportDigest)} must be exactly 20 bytes in length.", nameof(nextImportDigest));

            Name = name;
            NextImportDigest = nextImportDigest;
            ID = id;
            Version = version;
            MinVersion = minVersion;
            Thunks = thunks;
        }

        internal XexImportLibrary(BinaryStreamReader br, string name)
        {
            Name = name;
            
            int size = br.ReadInt32();
            NextImportDigest = br.ReadBytes(20);
            ID = br.ReadUInt32();
            Version = new XexVersion(br);
            MinVersion = new XexVersion(br);
            ushort nameIndex = br.ReadUInt16();
            ushort thunkCount = br.ReadUInt16();

            Thunks = new List<uint>(thunkCount);
            for (int i = 0; i < thunkCount; i++)
            {
                Thunks.Add(br.ReadUInt32());
            }
        }
    }
}
