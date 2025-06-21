using System;

namespace XenonFormats
{
    [Flags]
    public enum XexMediaTypeFlags : uint
    {
        None = 0,
        HardDisk = 0x00000001,
        XGD1 = 0x00000002,
        DVD_CD = 0x00000004,
        DVD_5 = 0x00000008,
        DVD_9 = 0x00000010,
        SystemFlash = 0x00000020,
        MemoryUnit = 0x00000080,
        USBMassStorageDevice = 0x00000100,
        Network = 0x00000200,
        DirectFromMemory = 0x00000400,
        RAMDrive = 0x00000800,
        SVOD = 0x00001000,
        InsecurePackage = 0x01000000,
        SaveGamePackage = 0x02000000,
        LocallySignedPackage = 0x04000000,
        LiveSignedPackage = 0x08000000,
        XboxPackage = 0x10000000
    }
}
