using RC5Cryptography.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC5_Constantsryptography.Model
{
    internal class Word16Bit
    {
        public const Int32 WordSizeInBits = BytesPerWord * RC5_Constants.BitsPerByte;
        public const Int32 BytesPerWord = sizeof(UInt16);

        public UInt16 WordValue { get; set; }

        public void CreateFromBytes(Byte[] bytes, Int32 startFrom)
        {
            WordValue = 0;

            for (var i = startFrom + BytesPerWord - 1; i > startFrom; --i)
            {
                WordValue = (UInt16)(WordValue | bytes[i]);
                WordValue = (UInt16)(WordValue << RC5_Constants.BitsPerByte);
            }

            WordValue = (UInt16)(WordValue | bytes[startFrom]);
        }

        public Byte[] FillBytesArray(Byte[] bytesToFill, Int32 startFrom)
        {
            var i = 0;
            for (; i < BytesPerWord - 1; ++i)
            {
                bytesToFill[startFrom + i] = (Byte)(WordValue & RC5_Constants.ByteMask);
                WordValue = (UInt16)(WordValue >> RC5_Constants.BitsPerByte);
            }

            bytesToFill[startFrom + i] = (Byte)(WordValue & RC5_Constants.ByteMask);

            return bytesToFill;
        }

        public Word16Bit ROL(Int32 offset)
        {
            offset %= BytesPerWord;
            WordValue = (UInt16)((WordValue << offset) | (WordValue >> (WordSizeInBits - offset)));

            return this;
        }

        public Word16Bit ROR(Int32 offset)
        {
            offset %= BytesPerWord;
            WordValue = (UInt16)((WordValue >> offset) | (WordValue << (WordSizeInBits - offset)));

            return this;
        }

        public Word16Bit Add(Word16Bit word)
        {
            WordValue = (UInt16)(WordValue + (word as Word16Bit).WordValue);

            return this;
        }

        public Word16Bit Add(Byte value)
        {
            WordValue = (UInt16)(WordValue + value);

            return this;
        }

        public Word16Bit Sub(Word16Bit word)
        {
            WordValue = (UInt16)(WordValue - (word as Word16Bit).WordValue);

            return this;
        }

        public Word16Bit XorWith(Word16Bit word)
        {
            WordValue = (UInt16)(WordValue ^ (word as Word16Bit).WordValue);

            return this;
        }

        public Word16Bit Clone()
        {
            return (Word16Bit)MemberwiseClone();
        }

        public Int32 ToInt32()
        {
            return WordValue;
        }
    }
}
