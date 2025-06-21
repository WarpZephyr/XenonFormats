using System;

namespace XenonFormats
{
    [Flags]
    public enum XexImageFlags : uint
    {
        None = 0,
        ManufacturingUtility = 0x00000002,
        ManufacturingSupportTools = 0x00000004,
        Xgd2MediaOnly = 0x00000008,
        CardeaKey = 0x00000100,
        XeikaKey = 0x00000200,
        UsermodeTitle = 0x00000400,
        UsermodeSystem = 0x00000800,
        Orange0 = 0x00001000,
        Orange1 = 0x00002000,
        Orange2 = 0x00004000,
        IptvSignupApplication = 0x00010000,
        IptvTitleApplication = 0x00020000,
        KeyvaultPrivilegesRequired = 0x04000000,
        OnlineActivationRequired = 0x08000000,
        PageSize4kb = 0x10000000, // Default is 64kb.
        RegionFree = 0x20000000,
        RevocationCheckOptional = 0x40000000,
        RevocationCheckRequired = 0x80000000
    }
}
