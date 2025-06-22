using System;

namespace XenonFormats
{
    internal static class HexHelper
    {
        private const string ByteToHexLookup =
            "000102030405060708090A0B0C0D0E0F" +
            "101112131415161718191A1B1C1D1E1F" +
            "202122232425262728292A2B2C2D2E2F" +
            "303132333435363738393A3B3C3D3E3F" +
            "404142434445464748494A4B4C4D4E4F" +
            "505152535455565758595A5B5C5D5E5F" +
            "606162636465666768696A6B6C6D6E6F" +
            "707172737475767778797A7B7C7D7E7F" +
            "808182838485868788898A8B8C8D8E8F" +
            "909192939495969798999A9B9C9D9E9F" +
            "A0A1A2A3A4A5A6A7A8A9AAABACADAEAF" +
            "B0B1B2B3B4B5B6B7B8B9BABBBCBDBEBF" +
            "C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF" +
            "D0D1D2D3D4D5D6D7D8D9DADBDCDDDEDF" +
            "E0E1E2E3E4E5E6E7E8E9EAEBECEDEEEF" +
            "F0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF";

        [ThreadStatic]
        private static readonly char[] HexBuffer;

        static HexHelper()
        {
            HexBuffer = new char[16];
        }

        public static string ToHex(sbyte value)
            => new(ByteToHexLookup.AsSpan(((byte)value) << 1, 2));

        public static string ToHex(byte value)
            => new(ByteToHexLookup.AsSpan(value << 1, 2));

        public static string ToHex(short value)
        {
            ushort uvalue = (ushort)value;
            int index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 4));
        }

        public static string ToHex(ushort value)
        {
            int index = (byte)(value >>> 8) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = ((byte)value) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 4));
        }

        public static string ToHex(int value)
        {
            uint uvalue = (uint)value;
            int index = (byte)(uvalue >>> 24) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 16) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 8));
        }

        public static string ToHex(uint value)
        {
            int index = (byte)(value >>> 24) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 16) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 8) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = ((byte)value) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 8));
        }

        public static string ToHex(long value)
        {
            ulong uvalue = (ulong)value;
            int index = (byte)(uvalue >>> 56) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 48) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 40) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 32) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 24) << 1;
            HexBuffer[8] = ByteToHexLookup[index];
            HexBuffer[9] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 16) << 1;
            HexBuffer[10] = ByteToHexLookup[index];
            HexBuffer[11] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[12] = ByteToHexLookup[index];
            HexBuffer[13] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[14] = ByteToHexLookup[index];
            HexBuffer[15] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer));
        }

        public static string ToHex(ulong value)
        {
            int index = (byte)(value >>> 56) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 48) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 40) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 32) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 24) << 1;
            HexBuffer[8] = ByteToHexLookup[index];
            HexBuffer[9] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 16) << 1;
            HexBuffer[10] = ByteToHexLookup[index];
            HexBuffer[11] = ByteToHexLookup[index + 1];

            index = (byte)(value >>> 8) << 1;
            HexBuffer[12] = ByteToHexLookup[index];
            HexBuffer[13] = ByteToHexLookup[index + 1];

            index = ((byte)value) << 1;
            HexBuffer[14] = ByteToHexLookup[index];
            HexBuffer[15] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer));
        }

        public static string ToHex(Half value)
        {
            ushort uvalue = BitConverter.HalfToUInt16Bits(value);
            int index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 4));
        }

        public static string ToHex(float value)
        {
            uint uvalue = BitConverter.SingleToUInt32Bits(value);
            int index = (byte)(uvalue >>> 24) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 16) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 8));
        }

        public static string ToHex(double value)
        {
            ulong uvalue = BitConverter.DoubleToUInt64Bits(value);
            int index = (byte)(uvalue >>> 56) << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 48) << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 40) << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 32) << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 24) << 1;
            HexBuffer[8] = ByteToHexLookup[index];
            HexBuffer[9] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 16) << 1;
            HexBuffer[10] = ByteToHexLookup[index];
            HexBuffer[11] = ByteToHexLookup[index + 1];

            index = (byte)(uvalue >>> 8) << 1;
            HexBuffer[12] = ByteToHexLookup[index];
            HexBuffer[13] = ByteToHexLookup[index + 1];

            index = ((byte)uvalue) << 1;
            HexBuffer[14] = ByteToHexLookup[index];
            HexBuffer[15] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer));
        }

        internal static string ToHex(char a, char b, ushort c)
        {
            byte value1 = (byte)a;
            byte value2 = (byte)b;
            byte value3;
            byte value4;
            if (BitConverter.IsLittleEndian)
            {
                value3 = (byte)c;
                value4 = (byte)(c >>> 8);
            }
            else
            {
                value3 = (byte)(c >>> 8);
                value4 = (byte)c;
            }

            int index = value1 << 1;
            HexBuffer[0] = ByteToHexLookup[index];
            HexBuffer[1] = ByteToHexLookup[index + 1];

            index = value2 << 1;
            HexBuffer[2] = ByteToHexLookup[index];
            HexBuffer[3] = ByteToHexLookup[index + 1];

            index = value3 << 1;
            HexBuffer[4] = ByteToHexLookup[index];
            HexBuffer[5] = ByteToHexLookup[index + 1];

            index = value4 << 1;
            HexBuffer[6] = ByteToHexLookup[index];
            HexBuffer[7] = ByteToHexLookup[index + 1];

            return new(new ReadOnlySpan<char>(HexBuffer, 0, 8));
        }
    }
}
