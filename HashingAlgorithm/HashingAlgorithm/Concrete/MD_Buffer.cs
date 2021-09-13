using HashingAlgorithm.Constants;
using HashingAlgorithm.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingAlgorithm.Concrete
{
    public class MD_Buffer
    {
        internal static MD_Buffer InitialValue { get; }

        public uint A { get; set; }
        public uint B { get; set; }
        public uint C { get; set; }
        public uint D { get; set; }

        static MD_Buffer()
        {
            InitialValue = new MD_Buffer
            {
                A = MD5Constants.A_MD_BUFFER_INITIAL,
                B = MD5Constants.B_MD_BUFFER_INITIAL,
                C = MD5Constants.C_MD_BUFFER_INITIAL,
                D = MD5Constants.D_MD_BUFFER_INITIAL
            };
        }

        public Byte[] ToByteArray()
        {
            return ArraysHelper.ConcatArrays(
                BitConverter.GetBytes(A),
                BitConverter.GetBytes(B),
                BitConverter.GetBytes(C),
                BitConverter.GetBytes(D)
                );
        }

        public MD_Buffer Clone()
        {
            return MemberwiseClone() as MD_Buffer;
        }

        internal void MD5IterationSwap(UInt32 F, UInt32[] X, UInt32 i, UInt32 k)
        {
            var tempD = D;
            D = C;
            C = B;
            B += BitsHelper.LeftRotate(A + F + X[k] + MD5Constants.T[i], MD5Constants.S[i]);
            A = tempD;
        }

        public override String ToString()
        {
            return $"{ToByteString(A)}{ToByteString(B)}{ToByteString(C)}{ToByteString(D)}";
        }

        public override Int32 GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override Boolean Equals(Object value)
        {
            return value is MD_Buffer md
                && (GetHashCode() == md.GetHashCode() || ToString() == md.ToString());
        }

        public static MD_Buffer operator +(MD_Buffer left, MD_Buffer right)
        {
            return new MD_Buffer
            {
                A = left.A + right.A,
                B = left.B + right.B,
                C = left.C + right.C,
                D = left.D + right.D
            };
        }

        private static string ToByteString(UInt32 x)
        {
            return string.Join(string.Empty, BitConverter.GetBytes(x).Select(y => y.ToString("x2")));
        }

    }
}
