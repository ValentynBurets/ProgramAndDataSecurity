using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Client.Logic
{
    public class RSAParams
    {
        RSAParameters RSAParam;

        public RSAParams()
        {
            RSAParam = new RSAParameters();
            initRSAParam();
        }

        public RSAParameters GetParams()
        {
            return RSAParam;
        }

        private void initRSAParam()
        {

            var p = 3;
            var q = 7;
            var n = p * q;

            RSAParam.Modulus = BitConverter.GetBytes(n);

            int eiler_function_res = (p - 1) * (q - 1);

            var e = CalculateExponent(p, q, eiler_function_res);
            RSAParam.Exponent = Convert.FromBase64String(e.ToString());

            //d must be inverted to e in the module to euler function
            // (d * e) % ф = 1
            // d = e^(-1) mod Ф(n)
            var d = Math.Pow(e, -1) % eiler_function_res;
            RSAParam.D = Convert.FromBase64String(d.ToString());
            //RSAParam.P = Convert.FromBase64String("4");

        }

        private int CalculateExponent(int p, int q, int eiler_function_res)
        { 
            List<int> primeNumbers;
            //e must be less then eiler_function_res
            //e must be simple
            //GCD e and eiler_function_res must be 1
            GetPrimeNumbers(eiler_function_res, out primeNumbers);

            return GetFirstFitNumber(primeNumbers, eiler_function_res);
        }

        private int GetFirstFitNumber(List<int>  primeNumbers, int eiler_function_res)
        {
            foreach(var item in primeNumbers)
            {
                if (GCD(item, eiler_function_res) == 1)
                    return item;
            }

            return primeNumbers[0];
        }

        //static int GCD(int[] numbers)
        //{
        //    return numbers.Aggregate((x, y) => { return GCD((int)x, (int)y); });
        //}

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        private void GetPrimeNumbers(int number, out List<int> primeNumbers)
        {
            int num, i, ctr, stno, enno;
            primeNumbers = new List<int>();
            //starting number of range
            stno = 1;
            // ending number of range
            enno = number;

            Console.Write("The prime numbers between {0} and {1} are : \n", stno, enno);

            for (num = stno; num <= enno; num++)
            {
                ctr = 0;

                for (i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }

                if (ctr == 0 && num != 1)
                {
                    primeNumbers.Add(num);
                }
            }

        }

    }
}
