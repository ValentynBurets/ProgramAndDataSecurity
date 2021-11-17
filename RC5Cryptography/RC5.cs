using HashingAlgorithm.Helpers;
using NumberGeneratorLibrary.Concrete;
using NumberGeneratorLibrary.Models;
using RC5_Constantsryptography.Model;
using RC5Cryptography.Constants;
using RC5Cryptography.Extensions;
using RC5Cryptography.Options;
using RC5Cryptography.WordFactory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC5Cryptography
{
    public class RC5
    {

        private readonly NumberGenerator _numberGenerator;
        private readonly Word16BitFactory _wordsFactory;
        private readonly Int32 _roundsCount;

        public RC5(AlgorithmSettings algorithmSettings)
        {
            _numberGenerator = new NumberGenerator(NumberGeneratorOptions.Default);

            _wordsFactory = new Word16BitFactory();
            _roundsCount = (int)algorithmSettings.Rounds;
        }

        public Byte[] EncipherCBCPAD(Byte[] input, Byte[] key)
        {
            //quatity of bits to full block
            var paddedBytes = ArraysHelper.ConcatArrays(input, GetPadding(input));
            
            var bytesPerBlock = _wordsFactory.BytesPerBlock;
            var s = BuildExpandedKeyTable(key);
            var cnPrev = GetRandomBytesForInitVector().Take(bytesPerBlock).ToArray();
            var encodedFileContent = new Byte[cnPrev.Length + paddedBytes.Length];

            EncipherECB(cnPrev, encodedFileContent, inStart: 0, outStart: 0, s);

            for (int i = 0; i < paddedBytes.Length; i += bytesPerBlock)
            {
                var cn = new Byte[bytesPerBlock];
                Array.Copy(paddedBytes, i, cn, 0, cn.Length);

                cn.XorWith(
                    xorArray: cnPrev,
                    inStartIndex: 0,
                    xorStartIndex: 0,
                    length: cn.Length);

                EncipherECB(
                    inBytes: cn,
                    outBytes: encodedFileContent,
                    inStart: 0,
                    outStart: i + bytesPerBlock,
                    s: s);

                Array.Copy(encodedFileContent, i + bytesPerBlock, cnPrev, 0, cn.Length);
            }

            return encodedFileContent;
        }


        //generator.X = 13;
        //    generator.A = (ulong) Math.Pow(13, 3);
        //generator.M = (ulong) Math.Pow(2, 26) - 1;
        //    generator.C = 1597;


        private void EncipherECB(Byte[] inBytes, Byte[] outBytes, Int32 inStart, Int32 outStart, Word16Bit[] s)
        {
            var a = _wordsFactory.CreateFromBytes(inBytes, inStart);
            var b = _wordsFactory.CreateFromBytes(inBytes, inStart + _wordsFactory.BytesPerWord);
            
            a.Add(s[0]);
            b.Add(s[1]);
            
            for (var i = 1; i < _roundsCount + 1; ++i)
            {
                a.XorWith(b).ROL(b.ToInt32()).Add(s[2 * i]);
                b.XorWith(a).ROL(a.ToInt32()).Add(s[2 * i + 1]);
            }

            a.FillBytesArray(outBytes, outStart);
            b.FillBytesArray(outBytes, outStart + _wordsFactory.BytesPerWord);
        }

        public Byte[] DecipherCBCPAD(Byte[] input, Byte[] key)
        {
            var bytesPerBlock = _wordsFactory.BytesPerBlock;
            var s = BuildExpandedKeyTable(key);
            var cnPrev = new Byte[bytesPerBlock];
            var decodedFileContent = new Byte[input.Length - cnPrev.Length];

            DecipherECB(
                inBuf: input,
                outBuf: cnPrev,
                inStart: 0,
                outStart: 0,
                s: s);

            for (int i = bytesPerBlock; i < input.Length; i += bytesPerBlock)
            {
                var cn = new Byte[bytesPerBlock];
                Array.Copy(input, i, cn, 0, cn.Length);

                DecipherECB(
                    inBuf: cn,
                    outBuf: decodedFileContent,
                    inStart: 0,
                    outStart: i - bytesPerBlock,
                    s: s);

                decodedFileContent.XorWith(
                    xorArray: cnPrev,
                    inStartIndex: i - bytesPerBlock,
                    xorStartIndex: 0,
                    length: cn.Length);

                Array.Copy(input, i, cnPrev, 0, cnPrev.Length);
            }

            var decodedWithoutPadding = new Byte[decodedFileContent.Length - decodedFileContent.Last()];
            Array.Copy(decodedFileContent, decodedWithoutPadding, decodedWithoutPadding.Length);

            return decodedWithoutPadding;
        }

        private void DecipherECB(Byte[] inBuf, Byte[] outBuf, Int32 inStart, Int32 outStart, Word16Bit[] s)
        {
            var a = _wordsFactory.CreateFromBytes(inBuf, inStart);
            var b = _wordsFactory.CreateFromBytes(inBuf, inStart + _wordsFactory.BytesPerWord);

            for (var i = _roundsCount; i > 0; --i)
            {
                b = b.Sub(s[2 * i + 1]).ROR(a.ToInt32()).XorWith(a);
                a = a.Sub(s[2 * i]).ROR(b.ToInt32()).XorWith(b);
            }

            a.Sub(s[0]);
            b.Sub(s[1]);

            a.FillBytesArray(outBuf, outStart);
            b.FillBytesArray(outBuf, outStart + _wordsFactory.BytesPerWord);
        }

        private Byte[] GetPadding(Byte[] inBytes)
        {
            var paddingLength = _wordsFactory.BytesPerBlock - inBytes.Length % (_wordsFactory.BytesPerBlock);

            var padding = new Byte[paddingLength];

            for (int i = 0; i < padding.Length; ++i)
            {
                padding[i] = (Byte)paddingLength;
            }

            return padding;
        }

        private Byte[] GetRandomBytesForInitVector()
        {
            var ivParts = new List<Byte[]>();

            //BytesPerBlock == 4

            while (ivParts.Count() < _wordsFactory.BytesPerBlock)
            {
                ivParts.Add(BitConverter.GetBytes(_numberGenerator.NextNumber()));
            }

            return ArraysHelper.ConcatArrays(ivParts.ToArray());
        }


        private Word16Bit[] BuildExpandedKeyTable(Byte[] key)
        {

            // Byte[] key
            // md5 key

            var keysWordArrLength = key.Length % _wordsFactory.BytesPerWord > 0
                ? key.Length / _wordsFactory.BytesPerWord + 1
                : key.Length / _wordsFactory.BytesPerWord;

            var lArr = new Word16Bit[keysWordArrLength];

            //create empty array of 16BitWords
            for (int i = 0; i < lArr.Length; i++)
            {
                lArr[i] = _wordsFactory.Create();
            }

            //
            for (var i = key.Length - 1; i >= 0; i--)
            {
                lArr[i / _wordsFactory.BytesPerWord].ROL(RC5_Constants.BitsPerByte).Add(key[i]);
            }

            var sArray = new Word16Bit[2 * (_roundsCount + 1)];
            sArray[0] = _wordsFactory.CreateP();
            var q = _wordsFactory.CreateQ();

            for (var i = 1; i < sArray.Length; i++)
            {
                sArray[i] = sArray[i - 1].Clone();
                sArray[i].Add(q);
            }

            var x = _wordsFactory.Create();
            var y = _wordsFactory.Create();

            var n = 3 * Math.Max(sArray.Length, lArr.Length);

            for (Int32 k = 0, i = 0, j = 0; k < n; ++k)
            {
                sArray[i].Add(x).Add(y).ROL(3);
                x = sArray[i].Clone();

                lArr[j].Add(x).Add(y).ROL(x.ToInt32() + y.ToInt32());
                y = lArr[j].Clone();

                i = (i + 1) % sArray.Length;
                j = (j + 1) % lArr.Length;
            }

            return sArray;
        }
    }
}
