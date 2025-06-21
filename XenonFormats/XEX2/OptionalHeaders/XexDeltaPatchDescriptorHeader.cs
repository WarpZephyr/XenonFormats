using Edoke.IO;
using System;
using System.Collections.Generic;
using System.Resources;

namespace XenonFormats
{
    public class XexDeltaPatchDescriptorHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.DeltaPatchDescriptor;

        public XexVersion TargetVersion { get; set; }
        public XexVersion SourceVersion { get; set; }
        public byte[] DigestSource { get; init; }
        public byte[] ImageKeySource { get; init; }
        public uint SizeOfTargetHeaders { get; set; }
        public uint DeltaHeadersSourceOffset { get; set; }
        public uint DeltaHeadersSourceSize { get; set; }
        public uint DeltaHeadersTargetOffset { get; set; }
        public uint DeltaImageSourceOffset { get; set; }
        public uint DeltaImageSourceSize { get; set; }
        public uint DeltaImageTargetOffset { get; set; }
        public XexDeltaPatchInfo Info { get; set; }

        public XexDeltaPatchDescriptorHeader(XexVersion targetVersion,
            XexVersion sourceVersion,
            byte[] digestSource,
            byte[] imageKeySource,
            uint sizeOfTargetHeaders,
            uint deltaHeadersSourceOffset,
            uint deltaHeadersSourceSize,
            uint deltaHeadersTargetOffset,
            uint deltaImageSourceOffset,
            uint deltaImageSourceSize,
            uint deltaImageTargetOffset,
            XexDeltaPatchInfo info)
        {
            if (digestSource.Length != 20)
                throw new ArgumentException($"{nameof(digestSource)} must be exactly 20 bytes in length.", nameof(digestSource));

            if (imageKeySource.Length != 16)
                throw new ArgumentException($"{nameof(imageKeySource)} must be exactly 16 bytes in length.", nameof(imageKeySource));

            TargetVersion = targetVersion;
            SourceVersion = sourceVersion;
            DigestSource = digestSource;
            ImageKeySource = imageKeySource;
            SizeOfTargetHeaders = sizeOfTargetHeaders;
            DeltaHeadersSourceOffset = deltaHeadersSourceOffset;
            DeltaHeadersSourceSize = deltaHeadersSourceSize;
            DeltaHeadersTargetOffset = deltaHeadersTargetOffset;
            DeltaImageSourceOffset = deltaImageSourceOffset;
            DeltaImageSourceSize = deltaImageSourceSize;
            DeltaImageTargetOffset = deltaImageTargetOffset;
            Info = info;
        }

        internal XexDeltaPatchDescriptorHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                int headerSize = br.ReadInt32();
                TargetVersion = new XexVersion(br);
                SourceVersion = new XexVersion(br);
                DigestSource = br.ReadBytes(20);
                ImageKeySource = br.ReadBytes(20);
                SizeOfTargetHeaders = br.ReadUInt32();
                DeltaHeadersSourceOffset = br.ReadUInt32();
                DeltaHeadersSourceSize = br.ReadUInt32();
                DeltaHeadersTargetOffset = br.ReadUInt32();
                DeltaImageSourceOffset = br.ReadUInt32();
                DeltaImageSourceSize = br.ReadUInt32();
                DeltaImageTargetOffset = br.ReadUInt32();
                Info = new XexDeltaPatchInfo(br);
            }
            br.StepOut();
        }
    }
}
