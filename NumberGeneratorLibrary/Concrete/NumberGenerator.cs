using NumberGeneratorLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGeneratorLibrary.Concrete
{
    public class NumberGenerator
    {
        private ulong _currentNumber;
        private readonly ulong _mod;
        private readonly ulong _multiplier;
        private readonly ulong _cummulative;
        private readonly ulong _startValue;

        public NumberGenerator(NumberGeneratorOptions options)
        {
            _mod = options.Mod;
            _multiplier = options.Multiplier;
            _cummulative = options.Cummulative;
            _startValue = options.StartValue;
            _currentNumber = options.StartValue;
        }

        public ulong NextNumber()
        {
            var nextNumber = SequenceFormula(
                _multiplier,
                _cummulative,
                _mod,
                _currentNumber);

            _currentNumber = nextNumber;

            return nextNumber;
        }

        public ulong NextNumber(ulong currentNumber)
        {
            return SequenceFormula(
                _multiplier,
                _cummulative,
                _mod,
                currentNumber);
        }

        public void Reset()
        {
            _currentNumber = _startValue;
        }

        private static ulong SequenceFormula(
            ulong mult,
            ulong c,
            ulong mod,
            ulong x)
        {
            return (mult * x + c) % mod;
        }
    }
}
