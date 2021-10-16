using HashingAlgorithm.Concrete;
using RC5Cryptography.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC5Cryptography.Extensions
{
    public static class ByteArrayExtensions
    {
        public static Byte[] GetMD5HashedKeyForRC5(
            this Byte[] key,
            int length)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var hasher = new MD5();
            var bytesHash = hasher.ComputeHash(key).ToByteArray();

            if (bytesHash.Length != (int)length)
            {
                throw new InvalidOperationException(
                    $"Internal error at {nameof(ByteArrayExtensions.GetMD5HashedKeyForRC5)} method, " +
                    $"hash result is not equal to {(int)length}.");
            }

            return bytesHash;
        }

        internal static void XorWith(
            this Byte[] array,
            Byte[] xorArray,
            int inStartIndex,
            int xorStartIndex,
            int length)
        {
            for (int i = 0; i < length; ++i)
            {
                array[i + inStartIndex] ^= xorArray[i + xorStartIndex];
            }
        }
    }
}
