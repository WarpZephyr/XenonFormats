using Edoke.IO;
using System;
using System.Collections.Generic;

namespace XenonFormats
{
    public class Xex2SecurityInfo
    {
        public uint HeaderSize { get; set; }
        public uint ImageSize { get; set; }
        public byte[] RSASignature { get; init; }
        public uint Unk108 { get; set; }
        public XexImageFlags ImageFlags { get; set; }
        public uint BaseAddress { get; set; }
        public byte[] SectionDigest { get; init; }
        public byte[] ImportTableDigest { get; init; }
        public byte[] XGD2MediaID { get; set; }
        public byte[] TitleKey { get; set; }
        public uint ExportTablePointer { get; set; }
        public byte[] HeaderDigest { get; init; }
        public XexRegionCodeFlags RegionCodeFlags { get; set; }
        public XexMediaTypeFlags AllowedMediaTypes { get; set; }
        public List<XexPageDescriptor> PageDescriptors { get; set; }

        public Xex2SecurityInfo(uint headerSize,
            uint imageSize,
            byte[] rsaSignature,
            uint unk108,
            XexImageFlags imageFlags,
            uint baseAddress,
            byte[] sectionDigest,
            byte[] importTableDigest,
            byte[] xgd2MediaID,
            byte[] titleKey,
            uint exportTablePointer,
            byte[] headerDigest,
            XexRegionCodeFlags regionCodeFlags,
            XexMediaTypeFlags mediaTypeFlags,
            List<XexPageDescriptor> pageDescriptors)
        {
            if (rsaSignature.Length != 256)
                throw new ArgumentException($"{nameof(rsaSignature)} must be exactly 256 bytes in length.", nameof(rsaSignature));

            if (sectionDigest.Length != 20)
                throw new ArgumentException($"{nameof(sectionDigest)} must be exactly 20 bytes in length.", nameof(sectionDigest));

            if (importTableDigest.Length != 20)
                throw new ArgumentException($"{nameof(importTableDigest)} must be exactly 20 bytes in length.", nameof(importTableDigest));

            if (headerDigest.Length != 20)
                throw new ArgumentException($"{nameof(headerDigest)} must be exactly 20 bytes in length.", nameof(headerDigest));

            if (xgd2MediaID.Length != 16)
                throw new ArgumentException($"{nameof(xgd2MediaID)} must be exactly 16 bytes in length.", nameof(xgd2MediaID));

            if (titleKey.Length != 16)
                throw new ArgumentException($"{nameof(titleKey)} must be exactly 16 bytes in length.", nameof(titleKey));

            HeaderSize = headerSize;
            ImageSize = imageSize;
            RSASignature = rsaSignature;
            Unk108 = unk108;
            ImageFlags = imageFlags;
            BaseAddress = baseAddress;
            SectionDigest = sectionDigest;
            ImportTableDigest = importTableDigest;
            XGD2MediaID = xgd2MediaID;
            TitleKey = titleKey;
            ExportTablePointer = exportTablePointer;
            HeaderDigest = headerDigest;
            RegionCodeFlags = regionCodeFlags;
            AllowedMediaTypes = mediaTypeFlags;
            PageDescriptors = pageDescriptors;
        }

        public Xex2SecurityInfo()
        {
            HeaderSize = 0xFFFFFFFFU;
            ImageSize = 0xFFFFFFFFU;
            RSASignature = new byte[256];
            Unk108 = 0;
            ImageFlags = XexImageFlags.Xgd2MediaOnly;
            BaseAddress = 0x82000000U;
            SectionDigest = new byte[20];
            ImportTableDigest = new byte[20];
            XGD2MediaID = new byte[16];
            TitleKey = new byte[16];
            ExportTablePointer = 0U;
            HeaderDigest = new byte[20];
            RegionCodeFlags = XexRegionCodeFlags.All;
            AllowedMediaTypes = XexMediaTypeFlags.DVD_CD;
            PageDescriptors = [];
        }

        internal Xex2SecurityInfo(BinaryStreamReader br)
        {
            HeaderSize = br.ReadUInt32();
            ImageSize = br.ReadUInt32();
            RSASignature = br.ReadBytes(256);
            Unk108 = br.ReadUInt32();
            ImageFlags = (XexImageFlags)br.ReadUInt32();
            BaseAddress = br.ReadUInt32();
            SectionDigest = br.ReadBytes(20);
            int importTableCount = br.ReadInt32();
            ImportTableDigest = br.ReadBytes(20);
            XGD2MediaID = br.ReadBytes(16);
            TitleKey = br.ReadBytes(16);
            ExportTablePointer = br.ReadUInt32();
            HeaderDigest = br.ReadBytes(20);
            RegionCodeFlags = (XexRegionCodeFlags)br.ReadUInt32();
            AllowedMediaTypes = (XexMediaTypeFlags)br.ReadUInt32();

            int pageDescriptorCount = br.ReadInt32();
            PageDescriptors = new List<XexPageDescriptor>(pageDescriptorCount);
            for (int i = 0; i < pageDescriptorCount; i++)
            {
                PageDescriptors.Add(new XexPageDescriptor(br));
            }
        }
    }
}
