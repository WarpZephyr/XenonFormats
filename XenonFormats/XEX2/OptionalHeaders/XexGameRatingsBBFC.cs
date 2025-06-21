namespace XenonFormats
{
    public enum XexGameRatingsBBFC : byte
    {
        BBFC_Universal = 1,
        BBFC_PG = 5,
        BBFC_3_Plus = 0,
        BBFC_7_Plus = 4,
        BBFC_12_Plus = 9,
        BBFC_15_Plus = 12,
        BBFC_16_Plus = 13,
        BBFC_18_Plus = 14,
        BBFC_Unrated = 0xFF,
    }
}
