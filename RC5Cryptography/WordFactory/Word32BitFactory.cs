using RC5Cryptography.Constants;
using RC5Cryptography.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC5Cryptography.WordFactory
{
    internal class Word32BitFactory
    {
        public Int32 BytesPerWord => Word32Bit.BytesPerWord;

        public Int32 BytesPerBlock => BytesPerWord * 2;

        public Word32Bit Create()
        {
            return CreateConcrete();
        }

        public Word32Bit CreateP()
        {
            return CreateConcrete(RC5_Constants.P32);
        }

        public Word32Bit CreateQ()
        {
            return CreateConcrete(RC5_Constants.Q32);
        }

        public Word32Bit CreateFromBytes(Byte[] bytes, Int32 startFromIndex)
        {
            var word = Create();
            word.CreateFromBytes(bytes, startFromIndex);

            return word;
        }

        public Word32Bit CreateConcrete(UInt32 value = 0)
        {
            return new Word32Bit
            {
                WordValue = value
            };
        }
    }
}
