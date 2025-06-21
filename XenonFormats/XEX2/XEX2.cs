using Edoke.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace XenonFormats
{
    public class XEX2
    {
        public XexModuleFlags ModuleFlags { get; set; }
        public List<IXexOptionalHeader> OptionalHeaders { get; set; }
        public Xex2SecurityInfo SecurityInfo { get; set; }

        public XEX2(XexModuleFlags moduleFlags, List<IXexOptionalHeader> optionalHeaders, Xex2SecurityInfo securityInfo)
        {
            ModuleFlags = moduleFlags;
            OptionalHeaders = optionalHeaders;
            SecurityInfo = securityInfo;
        }

        public XEX2()
        {
            ModuleFlags = XexModuleFlags.Title;
            OptionalHeaders = [];
            SecurityInfo = new Xex2SecurityInfo();
        }

        private XEX2(BinaryStreamReader br)
        {
            br.BigEndian = true;
            br.AssertASCII("XEX2");
            ModuleFlags = (XexModuleFlags)br.ReadUInt32();
            int headerSize = br.ReadInt32();
            br.AssertInt32(0);
            int securityInfoOffset = br.ReadInt32();
            int optionalHeaderCount = br.ReadInt32();

            OptionalHeaders = new List<IXexOptionalHeader>(optionalHeaderCount);
            for (int i = 0; i < optionalHeaderCount; i++)
            {
                var optionalHeaderType = br.ReadEnumInt32<XexOptionalHeaderType>();
                switch (optionalHeaderType)
                {
                    case XexOptionalHeaderType.ResourceInfo:
                        OptionalHeaders.Add(new XexResourceInfoHeader(br));
                        break;
                    case XexOptionalHeaderType.FileFormatInfo:
                        OptionalHeaders.Add(new XexFileFormatInfoHeader(br));
                        break;
                    case XexOptionalHeaderType.DeltaPatchDescriptor:
                        OptionalHeaders.Add(new XexDeltaPatchDescriptorHeader(br));
                        break;
                    case XexOptionalHeaderType.DiscProfileID:
                        OptionalHeaders.Add(new XexDiscProfileIdHeader(br));
                        break;
                    case XexOptionalHeaderType.BoundingPath:
                        OptionalHeaders.Add(new XexBoundingPathHeader(br));
                        break;
                    case XexOptionalHeaderType.OriginalBaseAddress:
                        OptionalHeaders.Add(new XexOriginalBaseAddressHeader(br));
                        break;
                    case XexOptionalHeaderType.EntryPoint:
                        OptionalHeaders.Add(new XexEntryPointHeader(br));
                        break;
                    case XexOptionalHeaderType.ImageBaseAddress:
                        OptionalHeaders.Add(new XexImageBaseAddressHeader(br));
                        break;
                    case XexOptionalHeaderType.ImportLibraries:
                        OptionalHeaders.Add(new XexImportLibrariesHeader(br));
                        break;
                    case XexOptionalHeaderType.ChecksumTimestamp:
                        OptionalHeaders.Add(new XexChecksumTimestampHeader(br));
                        break;
                    case XexOptionalHeaderType.EnabledForFastcap:
                        OptionalHeaders.Add(new XexEnabledForFastcapHeader(br));
                        break;
                    case XexOptionalHeaderType.OriginalPeName:
                        OptionalHeaders.Add(new XexOriginalPeNameHeader(br));
                        break;
                    case XexOptionalHeaderType.StaticLibraries:
                        OptionalHeaders.Add(new XexStaticLibrariesHeader(br));
                        break;
                    case XexOptionalHeaderType.TlsInfo:
                        OptionalHeaders.Add(new XexTlsInfoHeader(br));
                        break;
                    case XexOptionalHeaderType.DefaultStackSize:
                        OptionalHeaders.Add(new XexDefaultStackSizeHeader(br));
                        break;
                    case XexOptionalHeaderType.DefaultFsCacheSize:
                        OptionalHeaders.Add(new XexDefaultFsCacheSizeHeader(br));
                        break;
                    case XexOptionalHeaderType.DefaultHeapSize:
                        OptionalHeaders.Add(new XexDefaultHeapSizeHeader(br));
                        break;
                    case XexOptionalHeaderType.SystemFlags:
                        OptionalHeaders.Add(new XexSystemFlagsHeader(br));
                        break;
                    case XexOptionalHeaderType.ExecutionId:
                        OptionalHeaders.Add(new XexExecutionIdHeader(br));
                        break;
                    case XexOptionalHeaderType.TitleWorkspaceSize:
                        OptionalHeaders.Add(new XexTitleWorkspaceSizeHeader(br));
                        break;
                    case XexOptionalHeaderType.GameRatings:
                        OptionalHeaders.Add(new XexGameRatingsHeader(br));
                        break;
                    case XexOptionalHeaderType.LanKey:
                        OptionalHeaders.Add(new XexLanKeyHeader(br));
                        break;
                    case XexOptionalHeaderType.Xbox360Logo:
                        OptionalHeaders.Add(new XexXbox360LogoHeader(br));
                        break;
                    case XexOptionalHeaderType.MultidiscMediaIds:
                        OptionalHeaders.Add(new XexMultiDiscMediaIdsHeader(br));
                        break;
                    case XexOptionalHeaderType.AlternateTitleIds:
                        OptionalHeaders.Add(new XexAlternateTitleIdsHeader(br));
                        break;
                    case XexOptionalHeaderType.AdditionalTitleMemory:
                        OptionalHeaders.Add(new XexAdditionalTitleMemoryHeader(br));
                        break;
                    // TODO
                    case XexOptionalHeaderType.DeviceId:
                    case XexOptionalHeaderType.EnabledForCallcap:
                    case XexOptionalHeaderType.PageHeapSizeAndFlags:
                    case XexOptionalHeaderType.ServiceIdList:
                    case XexOptionalHeaderType.ExportsByName:
                    default:
                        throw new NotSupportedException($"{nameof(XEX2)} {nameof(XexOptionalHeaderType)} {optionalHeaderType} is not implemented or not supported.");
                }
            }

            br.Position = securityInfoOffset;
            SecurityInfo = new Xex2SecurityInfo(br);
        }

        public static XEX2 Read(string path)
        {
            using var br = new BinaryStreamReader(path);
            return new XEX2(br);
        }

        public static XEX2 Read(byte[] bytes)
        {
            using var br = new BinaryStreamReader(bytes);
            return new XEX2(br);
        }
    }
}
