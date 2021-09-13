using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1.LogicModule
{
    public class Logic
    {
        public event Action<string> LogMessageToUI;
        public event Action<string> NumberGeneratedOutput;
        public event Action<ulong> NumbersGenerated;
        public string outputFileName { get; }
        public List<ulong> numbers;


        public Logic()
            : this(@"./output.txt")
        {   }

        public Logic(string fileName)
        {
            outputFileName = fileName;
            numbers = new List<ulong>();
        }

        public async Task ExecuteDefaultComparing(ulong numbersCountToUI, GeneratorOptions options, CancellationToken token)
        {
            
            DeleteOutputFile();

                var a = options.Multiplier;
                var c = options.Increase;
                var m = options.ComparisonModule;

                
                ulong zeroNumber = options.StartValue;
                ulong currentNumber = zeroNumber;
                ulong firstNumber = 0;
                ulong numbersGenerated = 1;

                bool isPeriodFound = false;
                bool isMaxToUi = false;

                var generatedData = new List<ulong>();
                generatedData.Add(firstNumber);


            using (var writer = File.CreateText(outputFileName))
            {
                while (!isPeriodFound)
                {
                    firstNumber = (a * currentNumber + c) % m;
                    numbersGenerated++;

                    if (token.IsCancellationRequested)
                        break;

                    if (!isPeriodFound && (firstNumber == zeroNumber || firstNumber == currentNumber))
                    {
                        LogMessageToUI?.Invoke(
                            $"\nSequence interval period found, unique count: "
                            + $"{numbersGenerated - 1}\n");

                        isPeriodFound = true;
                    }

                    if (numbersGenerated > numbersCountToUI)
                        isMaxToUi = true;

                    //output---------------

                    if (!isPeriodFound)
                    {
                        numbers.Add(firstNumber);

                        if (numbers.Count > 100_000)
                        {
                            await writer.WriteAsync(string.Join(" ", numbers));
                            numbers.Clear();
                        }

                    }
                    if (isPeriodFound)
                    {
                        numbers.Add(firstNumber);
                        await writer.WriteAsync(string.Join(" ", numbers));
                        numbers.Clear();
                    }
                    if (!isMaxToUi)
                        NumberGeneratedOutput?.Invoke(" " + firstNumber + " ");

                    //----------------------


                    if (numbersGenerated % 1_000_000 == 0)
                    {
                        await writer.WriteAsync("Burets ");
                        await writer.FlushAsync();
                    }

                    currentNumber = firstNumber;
                }

                NumbersGenerated?.Invoke(numbersGenerated);

            }
        }

        //private bool IsDuplicateFound(ulong nextNumber, ulong? previousNumber, ulong? currentNumber, ulong outputCount)
        //{
        //    return (previousNumber.HasValue && previousNumber == nextNumber && outputCount > 2)
        //        || (currentNumber.HasValue && currentNumber == nextNumber && outputCount > 2)
        //        || (previousNumber.HasValue && previousNumber == nextNumber);
        //}

        //private bool IsDuplicateFound(ulong? zeroNumber, ulong? firstNumber, ulong? currentNumber)
        //{
        //    return (zeroNumber.HasValue &&
        //            firstNumber.HasValue &&
        //            currentNumber.HasValue &&
        //            (firstNumber == zeroNumber || firstNumber == currentNumber));
        //}

        //private bool IsDuplicateFound(
        //    ulong nextNumber,
        //    ulong? previousNumber,
        //    ulong? firstNumber,
        //    ulong? secondNumber,
        //    ulong outputCount)
        //{
        //    return (firstNumber.HasValue && firstNumber == nextNumber && outputCount > 1)
        //        || (secondNumber.HasValue && secondNumber == nextNumber && outputCount > 2)
        //        || (previousNumber.HasValue && previousNumber == nextNumber);
        //}

        //private void OutputAsync(object obj)
        //{
        //    if (!obj.isPeriodFound)
        //    {
        //        numbers.Add(number);

        //        if (numbers.Count > 10_000)
        //        {
        //            writer.WriteAsync(string.Join(" ", numbers));
        //            numbers.Clear();
        //        }

        //    }
        //    if (isPeriodFound)
        //    {
        //        numbers.Add(number);
        //        writer.WriteAsync(string.Join(" ", numbers));
        //    }
        //    if (!breakOutputToUI)
        //        NumberGeneratedOutput?.Invoke(" " + number + " ");

        //}


        //public void OutputAsync(
        //    object parameterObj)
        //{
        //    //    StreamWriter writer,
        //    //    ulong outputCount,
        //    //    ulong number,
        //    //    bool breakOutputToUI,
        //    //    bool isPeriodFound

        //    var param = (WritingParams)parameterObj;

        //    while(!param.isPeriodFound)
        //    {
        //        if (!param.isPeriodFound)
        //        {
        //            numbers.Add(param.number);

        //            if (numbers.Count > 10_000)
        //            {
        //                param.writer.WriteAsync(string.Join(" ", numbers));
        //                numbers.Clear();
        //            }

        //        }
        //        if (param.isPeriodFound)
        //        {
        //            numbers.Add(param.number);
        //            param.writer.WriteAsync(string.Join(" ", numbers));
        //        }
        //        if (!param.breakOutputToUI)
        //                NumberGeneratedOutput?.Invoke(" " + param.number + " ");

        //    }
        //}

        //public async Task OutputAsync()
        //{

        //    using (var writer = File.CreateText(outputFileName))
        //    {
        //        while (!numbersParam.isPeriodFound)
        //        {
        //            if (!numbersParam.isPeriodFound)
        //            {
        //                numbers.Add(numbersParam.number);

        //                if (numbers.Count > 10_000)
        //                {
        //                    await writer.WriteAsync(string.Join(" ", numbers));
        //                    numbers.Clear();
        //                    Thread.Sleep(1000);
        //                }

        //            }
        //            if (numbersParam.isPeriodFound)
        //            {
        //                numbers.Add(numbersParam.number);
        //                await writer.WriteAsync(string.Join(" ", numbers));
        //            }
        //            if (!numbersParam.breakOutputToUI)
        //                NumberGeneratedOutput?.Invoke(" " + numbersParam.number + " ");
        //        }


        //        if (numbersParam.outputCount % 1_000_000 == 0)
        //        {
        //            await writer.WriteAsync("Burets ");
        //            await writer.FlushAsync();
        //        }
        //    }

        //}

        //public async Task OutputAsync(
        //    StreamWriter writer,
        //    ulong outputCount,
        //    ulong number,
        //    bool breakOutputToUI,
        //    bool isPeriodFound)
        //{
        //    if (!isPeriodFound)
        //    {
        //        numbers.Add(number);

        //        if (numbers.Count > 10_000)
        //        {
        //            await writer.WriteAsync(string.Join(" ", numbers));
        //            numbers.Clear();
        //        }

        //    }
        //    if (isPeriodFound)
        //    {
        //        numbers.Add(number);
        //        await writer.WriteAsync(string.Join(" ", numbers));
        //    }
        //    if (!breakOutputToUI)
        //        NumberGeneratedOutput?.Invoke(" " + number + " ");

        //}

        private void DeleteOutputFile()
        {
            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }
        }
    }
}
