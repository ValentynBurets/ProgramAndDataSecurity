using RC5_Constantsryptography.Model;
using RC5Cryptography.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC5Cryptography.WordFactory
{
    internal class Word16BitFactory
    {
        public Int32 BytesPerWord => Word16Bit.BytesPerWord;

        public Int32 BytesPerBlock => BytesPerWord * 2;

        public Word16Bit Create()
        {
            return CreateConcrete();
        }

        public Word16Bit CreateP()
        {
            return CreateConcrete(RC5_Constants.P16);
        }

        public Word16Bit CreateQ()
        {
            return CreateConcrete(RC5_Constants.Q16);
        }

        public Word16Bit CreateFromBytes(Byte[] bytes, Int32 startFromIndex)
        {
            var word = Create();
            word.CreateFromBytes(bytes, startFromIndex);

            return word;
        }

        public Word16Bit CreateConcrete(UInt16 value = 0)
        {
            return new Word16Bit
            {
                WordValue = value
            };
        }
    }
}
