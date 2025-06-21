using Edoke.IO;
using System;

namespace XenonFormats
{
    public class XexGameRatingsHeader : IXexOptionalHeader
    {
        public XexOptionalHeaderType Type
            => XexOptionalHeaderType.GameRatings;

        public byte[] GameRatings { get; init; }

        public XexGameRatingsESRB ESRB
        {
            get => (XexGameRatingsESRB)GameRatings[0];
            set => GameRatings[0] = (byte)value;
        }

        public XexGameRatingsPEGI PEGI
        {
            get => (XexGameRatingsPEGI)GameRatings[1];
            set => GameRatings[1] = (byte)value;
        }

        public XexGameRatingsPEGI_FI PEGI_FI
        {
            get => (XexGameRatingsPEGI_FI)GameRatings[2];
            set => GameRatings[2] = (byte)value;
        }

        public XexGameRatingsPEGI_PT PEGI_PT
        {
            get => (XexGameRatingsPEGI_PT)GameRatings[3];
            set => GameRatings[3] = (byte)value;
        }

        public XexGameRatingsBBFC BBFC
        {
            get => (XexGameRatingsBBFC)GameRatings[4];
            set => GameRatings[4] = (byte)value;
        }

        public XexGameRatingsCERO CERO
        {
            get => (XexGameRatingsCERO)GameRatings[5];
            set => GameRatings[5] = (byte)value;
        }

        public XexGameRatingsUSK USK
        {
            get => (XexGameRatingsUSK)GameRatings[6];
            set => GameRatings[6] = (byte)value;
        }

        public XexGameRatingsOFLC_AU OFLC_AU
        {
            get => (XexGameRatingsOFLC_AU)GameRatings[7];
            set => GameRatings[7] = (byte)value;
        }

        public XexGameRatingsOFLC_NZ OFLC_NZ
        {
            get => (XexGameRatingsOFLC_NZ)GameRatings[8];
            set => GameRatings[8] = (byte)value;
        }

        public XexGameRatingsKMRB KMRB
        {
            get => (XexGameRatingsKMRB)GameRatings[9];
            set => GameRatings[9] = (byte)value;
        }

        public XexGameRatingsBrazil Brazil
        {
            get => (XexGameRatingsBrazil)GameRatings[10];
            set => GameRatings[10] = (byte)value;
        }

        public XexGameRatingsFPB FPB
        {
            get => (XexGameRatingsFPB)GameRatings[11];
            set => GameRatings[11] = (byte)value;
        }

        public XexGameRatingsHeader(byte[] gameRatings)
        {
            if (gameRatings.Length != 64)
                throw new ArgumentException($"{nameof(gameRatings)} must be exactly 64 bytes in length.", nameof(gameRatings));

            GameRatings = gameRatings;
        }

        internal XexGameRatingsHeader(BinaryStreamReader br)
        {
            int offset = br.ReadInt32();
            br.StepIn(offset);
            {
                GameRatings = br.ReadBytes(64);
            }
            br.StepOut();
        }
    }
}
