using HashingAlgorithm.Constants;
using HashingAlgorithm.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingAlgorithm.Concrete
{
    public sealed class MD5
    {
        private const int OptimalChunkSizeMultiplier = 100_000;
        private const UInt32 OptimalChunkSize = MD5Constants.BytesCountPerBits512Block * OptimalChunkSizeMultiplier;

        public MD_Buffer Hash { get; private set; }

        public void ComputeHash(string message)
        {
            ComputeHash(Encoding.ASCII.GetBytes(message));
        }

        public MD_Buffer ComputeHash(Byte[] message)
        {
            Hash = MD_Buffer.InitialValue;

            var paddedMessage = JoinArrays(message, GetMessagePadding((UInt32)message.Length));

            for (UInt32 bNo = 0; bNo < paddedMessage.Length / MD5Constants.BytesCountPerBits512Block; ++bNo)
            {
                UInt32[] X = BitsHelper.Extract32BitWords(
                    paddedMessage,
                    bNo,
                    MD5Constants.Words32BitArraySize * MD5Constants.BytesPer32BitWord);

                FeedMessageBlockToBeHashed(X);
            }

            return Hash;
        }

        //public async Task<MD_Buffer> ComputeFileHashAsync(String filePath)
        //{
        //    Hash = MD_Buffer.InitialValue;

        //    using (var fs = File.OpenRead(filePath))
        //    {
        //        UInt64 totalBytesRead = 0;
        //        Int32 currentBytesRead = 0;
        //        bool isFileEnd = false;

        //        do
        //        {
        //            var chunk = new Byte[OptimalChunkSize];

        //            currentBytesRead = await fs.ReadAsync(chunk, 0, chunk.Length);
        //            totalBytesRead += (UInt64)currentBytesRead;


        //            if (currentBytesRead < chunk.Length)
        //            {
        //                Byte[] lastChunk;

        //                if (currentBytesRead == 0)
        //                {
        //                    lastChunk = GetMessagePadding(totalBytesRead);
        //                }
        //                else
        //                {
        //                    lastChunk = new Byte[currentBytesRead];
        //                    Array.Copy(chunk, lastChunk, currentBytesRead);

        //                    lastChunk = JoinArrays(lastChunk, GetMessagePadding(totalBytesRead));
        //                }

        //                chunk = lastChunk;
        //                isFileEnd = true;
        //            }

        //            for (UInt32 bNo = 0; bNo < chunk.Length / MD5Constants.BytesCountPerBits512Block; ++bNo)
        //            {
        //                UInt32[] X = BitsHelper.Extract32BitWords(
        //                    chunk,
        //                    bNo,
        //                    MD5Constants.Words32BitArraySize * MD5Constants.BytesPer32BitWord);

        //                FeedMessageBlockToBeHashed(X);
        //            }
        //        }
        //        while (isFileEnd == false);
        //    }

        //    return Hash;
        //}

        private void FeedMessageBlockToBeHashed(UInt32[] X)
        {
            UInt32 F, i, k;
            var blockSize = MD5Constants.BytesCountPerBits512Block;
            var MDq = Hash.Clone();

            // first round
            for (i = 0; i < blockSize / 4; ++i)
            {
                k = i;
                F = BitsHelper.FuncF(MDq.B, MDq.C, MDq.D);

                MDq.MD5IterationSwap(F, X, i, k);
            }
            // second round
            for (; i < blockSize / 2; ++i)
            {
                k = (1 + (5 * i)) % (blockSize / 4);
                F = BitsHelper.FuncG(MDq.B, MDq.C, MDq.D);

                MDq.MD5IterationSwap(F, X, i, k);
            }
            // third round
            for (; i < blockSize / 4 * 3; ++i)
            {
                k = (5 + (3 * i)) % (blockSize / 4);
                F = BitsHelper.FuncH(MDq.B, MDq.C, MDq.D);

                MDq.MD5IterationSwap(F, X, i, k);
            }
            // fourth round
            for (; i < blockSize; ++i)
            {
                k = 7 * i % (blockSize / 4);
                F = BitsHelper.FuncI(MDq.B, MDq.C, MDq.D);

                MDq.MD5IterationSwap(F, X, i, k);
            }

            Hash += MDq;
        }

        private static Byte[] GetMessagePadding(UInt64 messageLength)
        {
            UInt32 paddingLengthInBytes = default;
            var mod = (UInt32)(messageLength * MD5Constants.BitsPerByte % MD5Constants.Bits512BlockSize);

            // Append Padding Bits
            if (mod == MD5Constants.BITS_448)
            {
                paddingLengthInBytes = MD5Constants.Bits512BlockSize / MD5Constants.BitsPerByte;
            }
            else if (mod > MD5Constants.BITS_448)
            {
                paddingLengthInBytes = (MD5Constants.Bits512BlockSize - mod + MD5Constants.BITS_448) / MD5Constants.BitsPerByte;
            }
            else if (mod < MD5Constants.BITS_448)
            {
                paddingLengthInBytes = (MD5Constants.BITS_448 - mod) / MD5Constants.BitsPerByte;
            }

            var padding = new Byte[paddingLengthInBytes + MD5Constants.BitsPerByte];
            padding[0] = MD5Constants.BITS_128;

            // Append Length
            var messageLength64bit = messageLength *MD5Constants.BitsPerByte;

            for (var i = 0; i <MD5Constants.BitsPerByte; ++i)
            {
                padding[paddingLengthInBytes + i] = (Byte)(messageLength64bit
                    >> (Int32)(i *MD5Constants.BitsPerByte)
                    &MD5Constants.BITS_255);
            }

            return padding;
        }
        private static T[] JoinArrays<T>(T[] first, T[] second)
        {
            T[] joinedArray = new T[first.Length + second.Length];
            Array.Copy(first, joinedArray, first.Length);
            Array.Copy(second, 0, joinedArray, first.Length, second.Length);

            return joinedArray;
        }
    }
}
