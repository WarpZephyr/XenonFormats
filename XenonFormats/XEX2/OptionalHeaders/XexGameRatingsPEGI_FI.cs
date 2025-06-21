namespace XenonFormats
{
    /// <summary>
    /// PEGI Finland.
    /// </summary>
    public enum XexGameRatingsPEGI_FI : byte
    {
        PEGI_FI_3_Plus = 0,
        PEGI_FI_7_Plus = 4,
        PEGI_FI_11_Plus = 8,
        PEGI_FI_15_Plus = 12,
        PEGI_FI_18_Plus = 14,
        PEGI_FI_Unrated = 0xFF,
    }
}
