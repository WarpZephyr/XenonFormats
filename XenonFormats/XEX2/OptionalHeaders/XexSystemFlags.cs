using System;

namespace XenonFormats
{
    [Flags]
    public enum XexSystemFlags : uint
    {
        NoForcedReboot = 0x00000001,
        ForegroundTasks = 0x00000002,
        NoOddMapping = 0x00000004,
        HandleMceInput = 0x00000008,
        RestrictedHudFeatures = 0x00000010,
        HandleGamepadDisconnect = 0x00000020,
        InsecureSockets = 0x00000040,
        Xbox1Interoperability = 0x00000080,
        DashContext = 0x00000100,
        UsesGameVoiceChannel = 0x00000200,
        Pal50Incompatible = 0x00000400,
        InsecureUtilityDrive = 0x00000800,
        XamHooks = 0x00001000,
        AccessPii = 0x00002000,
        CrossPlatformSystemLink = 0x00004000,
        MultidiscSwap = 0x00008000,
        MultidiscInsecureMedia = 0x00010000,
        Ap25Media = 0x00020000,
        NoConfirmExit = 0x00040000,
        AllowBackgroundDownload = 0x00080000,
        CreatePersistableRamdrive = 0x00100000,
        InheritPersistentRamdrive = 0x00200000,
        AllowHudVibration = 0x00400000,
        AccessUtilityPartitions = 0x00800000,
        IptvInputSupported = 0x01000000,
        PreferBigButtonInput = 0x02000000,
        AllowExtendedSystemReservation = 0x04000000,
        MultidiscCrossTitle = 0x08000000,
        InstallIncompatible = 0x10000000,
        AllowAvatarGetMetadataByXuid = 0x20000000,
        AllowControllerSwapping = 0x40000000,
        DashExtensibilityModule = 0x80000000
    }
}
