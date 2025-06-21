using System;

namespace XenonFormats
{
    [Flags]
    public enum XexRegionCodeFlags : uint
    {
        None = 0,
        NTSC_U = 0x000000FF,
        NTSC_J = 0x0000FF00,
        NTSC_J_Other = 0x0000FC00,
        NTSC_J_Japan = 0x00000100,
        NTSC_J_China = 0x00000200,
        PAL = 0x00FF0000,
        PAL_Other = 0x00FE0000,
        PAL_AU_NZ = 0x00010000,
        Other = 0xFF000000,
        All = 0xFFFFFFFF
    }
}
