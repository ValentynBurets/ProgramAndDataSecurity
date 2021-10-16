using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGeneratorLibrary.Models
{
    public class NumberGeneratorOptions
    {
        static NumberGeneratorOptions()
        {
            //Default = new NumberGeneratorOptions
            //{
            //    Mod = (ulong)Math.Pow(2, 26) - 1,
            //    Cummulative = 1597,
            //    Multiplier = (ulong)Math.Pow(13, 3),
            //    StartValue = 13
            //};

            Default = new NumberGeneratorOptions
            {
                Mod = (ulong)Math.Pow(2, 31) - 1,
                Cummulative = 17711,
                Multiplier = (ulong)Math.Pow(7, 5),
                StartValue = 31
            };

            //Optimal = new NumberGeneratorOptions
            //{
            //    Mod = (ulong)Math.Pow(2, 31) - 1,
            //    Cummulative = 17711,
            //    Multiplier = (ulong)Math.Pow(7, 5),
            //    StartValue = 31
            //};
        }

        public static NumberGeneratorOptions Default { get; }
        public static NumberGeneratorOptions Optimal { get; }

        public ulong Mod { get; set; }

        public ulong Multiplier { get; set; }

        public ulong Cummulative { get; set; }

        public ulong StartValue { get; set; }
    }
}
