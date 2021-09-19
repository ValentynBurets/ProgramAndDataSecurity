using HashingAlgorithm.Constants;
using HashingAlgorithm.Helpers;
using System;
using System.Linq;
using System.Text;

namespace HashingAlgorithm.Concrete
{
    public sealed class MD5
    {
        private const int OptimalChunkSizeMultiplier = 100_000;
 
        public MD_Buffer Hash { get; private set; }

        public string HashAsString => Hash.ToString();

        public void ComputeHash(string message)
        {
            ComputeHash(Encoding.ASCII.GetBytes(message));
        }

        public MD_Buffer ComputeHash(Byte[] message)
        {
            Hash = MD_Buffer.InitialValue;

            var processedInput = JoinArrays(message, GetMessagePadding((UInt32)message.Length));

            for (int i = 0; i < processedInput.Length / MD5Constants.BytesCountPerBits512Block; ++i)
            {
                uint[] X = new uint[16];

                //copy the input to X array
                for (int j = 0; j < 16; ++j)
                    X[j] = BitConverter.ToUInt32(processedInput, (i * 64) + (j * 4));

                FeedMessageBlockToBeHashed(X);
            }

            return Hash;
        }

        //public string GetHash()
        //{
        //    return ToByteString(Hash.A) + ToByteString(Hash.B) + ToByteString(Hash.C) + ToByteString(Hash.D);
        //}

        //private static string ToByteString(UInt32 x)
        //{
        //    return string.Join(string.Empty, BitConverter.GetBytes(x).Select(y => y.ToString("x2")));
        //}

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
            //initialize input to M

            var MD_block = Hash.Clone();

            uint F = 0,
                 g = 0;

            //UInt32 F, i, k;
            var blockSize = MD5Constants.BytesCountPerBits512Block;
            //var MDq = Hash.Clone();

            // first round
            for (uint k = 0; k < blockSize; ++k)
            {
                if(k <= 15)
                {
                    //FunF(X,Y,Z)= (X /\ Y) \/ (~X /\ Z)
                    F = BitsHelper.FuncF(MD_block.B, MD_block.C, MD_block.D);

                    g = k;
                }
                else if(k >= 16 && k <= 31)
                {
                    //FunG(X,Y,Z)= (X /\ Z) \/ (~Z /\ Y )
                    F = BitsHelper.FuncG(MD_block.B, MD_block.C, MD_block.D);
                    g = ((5 * k) + 1) % 16;
                }
                else if (k >= 32 && k <= 47)
                {
                    //FunH(X,Y,Z)= X (+) Y (+) Z 
                    F = BitsHelper.FuncH(MD_block.B, MD_block.C, MD_block.D);
                    g = ((3 * k) + 5) % 16;
                }
                else if (k >= 48)
                {
                    //FunI(X,Y,Z)= Y (+) ( ~Z \/ X )
                    F = BitsHelper.FuncI(MD_block.B, MD_block.C, MD_block.D);
                    g = (7 * k) % 16;
                }

                MD_block.MD5IterationSwap(F, X, k, g);
            }

            //adding current MD block to hash
            // a0 += A;
            // b0 += B;
            // c0 += C;
            // d0 += D;
            
            Hash += MD_block;
        }

        //private static byte[] JoinArrays<T>(T[] input)
        //{
        //    var addLength = (56 - ((input.Length + 1) % 64)) % 64; //new Length with padding
        //    var processedInput = new byte[input.Length + 1 + addLength + 8];
        //    Array.Copy(input, processedInput, input.Length);
        //    processedInput[input.Length] = 0x80; // add 1000 0000 / 2 (BIN)

        //    byte[] length = BitConverter.GetBytes(input.Length * 8); // bit converter returns little-endian
        //    Array.Copy(length, 0, processedInput, processedInput.Length - 8, 4); // add length in bits

        //    return processedInput;
        //}

        private static Byte[] GetMessagePadding(UInt64 messageLength)
        {
            UInt32 paddingLengthInBytes = default;
            var mod = (UInt32)(messageLength * 8 % MD5Constants.Bits512BlockSize);

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
            var messageLength64bit = messageLength * MD5Constants.BitsPerByte;

            for (var i = 0; i < MD5Constants.BitsPerByte; ++i)
            {
                padding[paddingLengthInBytes + i] = (Byte)(messageLength64bit
                    >> (Int32)(i * MD5Constants.BitsPerByte)
                    & MD5Constants.BITS_255);
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
