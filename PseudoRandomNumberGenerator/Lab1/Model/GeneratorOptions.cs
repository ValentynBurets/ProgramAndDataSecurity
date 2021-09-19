using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class GeneratorOptions
    {
        static GeneratorOptions()
        {
            ////#1
            //Default = new GeneratorOptions
            //{
            //    ComparisonModule = (ulong)Math.Pow(2, 10) - 1,
            //    Multiplier = (ulong)Math.Pow(2, 5),
            //    Increase = 0,
            //    StartValue = 2
            //};

            //#7
            //Default = new GeneratorOptions
            //{
            //    ComparisonModule = (ulong)Math.Pow(2, 16) - 1,
            //    Multiplier = (ulong)Math.Pow(3, 3),
            //    Increase = 13,
            //    StartValue = 128
            //};

            //#8
            //Default = new GeneratorOptions
            //{
            //    ComparisonModule = (ulong)Math.Pow(2, 17) - 1,
            //    Multiplier = (ulong)Math.Pow(4, 3),
            //    Increase = 21,
            //    StartValue = 256
            //};

            ////#17
            //Default = new GeneratorOptions
            //{
            //    ComparisonModule = (ulong)Math.Pow(2, 26) - 1,
            //    Multiplier = (ulong)Math.Pow(13, 3),
            //    Increase = 1597,
            //    StartValue = 13
            //};

            //Default = new GeneratorOptions
            //{
            //    ComparisonModule = (ulong)Math.Pow(2, 26) - 1,
            //    Increase = 1597,
            //    Multiplier = (ulong)Math.Pow(13, 3),
            //    StartValue = 13
            //};

            //#22
            Default = new GeneratorOptions
            {
                ComparisonModule = (ulong)Math.Pow(2, 31) - 1,
                Multiplier = (ulong)Math.Pow(7, 5),
                Increase = 17711,
                StartValue = 31
            };
        }

        public static GeneratorOptions Default { get; }
        public static GeneratorOptions Optimal { get; }

        public ulong ComparisonModule { get; set; }
        public ulong Multiplier { get; set; }
        public ulong Increase { get; set; }
        public ulong StartValue { get; set; }
    }
}
