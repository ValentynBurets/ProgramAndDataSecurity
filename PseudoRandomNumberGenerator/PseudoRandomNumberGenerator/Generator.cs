using PseudoRandomNumberGenerator.Model;
using System;

namespace PseudoRandomNumberGenerator
{
    public class Generator
    {
        public ulong _currentNumber;
        private readonly ulong _comparisonModule;
        private readonly ulong _multiplier;
        private readonly ulong _increase;
        public readonly ulong _startValue;

        public Generator(GeneratorOptions options)
        {
            _comparisonModule = options.ComparisonModule;
            _multiplier = options.Multiplier;
            _increase = options.Increase;
            _currentNumber = options.StartValue;
            _startValue = options.StartValue;
        }

        //public ulong NextNumber()
        //{
        //    return SequenceFormula(
        //        _multiplier,
        //        _increase,
        //        _comparisonModule,
        //        _currentNumber);

        //}

        public ulong NextNumber()
        {
            var nextNumber = _currentNumber;

            _currentNumber = SequenceFormula(
                _multiplier,
                _increase,
                _comparisonModule,
                nextNumber);

            return _currentNumber;
        }


        public ulong NextNumber(ulong currentNumber)
        {
            return SequenceFormula(
                _multiplier,
                _increase,
                _comparisonModule,
                currentNumber);
        }

        //public void Reset()
        //{
        //    _currentNumber = _startValue;
        //}

        private static ulong SequenceFormula(
            ulong multiplier,
            ulong increase,
            ulong comparisonModule,
            ulong x)
        {

            //Xn+1 = ( a*Xn + c)mod m
            // c  ==  increase
            // m  ==  comparisonModule
            // a  ==  multiplier
            // x  == current x

            return (multiplier * x + increase) % comparisonModule;
        }
    }
}
