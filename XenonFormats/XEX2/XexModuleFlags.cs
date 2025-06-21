using System;

namespace XenonFormats
{
    [Flags]
    public enum XexModuleFlags
    {
        None = 0,
        Title = 0x00000001,
        ExportsToTitle = 0x00000002,
        SystemDebugger = 0x00000004,
        DllModule = 0x00000008,
        ModulePatch = 0x00000010,
        PatchFull = 0x00000020,
        PatchDelta = 0x00000040,
        UserMode = 0x00000080
    }
}
