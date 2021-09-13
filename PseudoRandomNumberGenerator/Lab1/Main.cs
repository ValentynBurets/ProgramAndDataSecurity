using Lab1.LogicModule;
using Lab1.Model;
using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Main : Form
    {
        private ulong _outputBufferInterval = 100000;
        private readonly StringBuilder _outputBuffer;
        private readonly Logic _logic;

        private CancellationTokenSource _cancelTokenSource;
        private ulong _numbersCountToGenerate = 0;


        public Main()
        {
            InitializeComponent();
            _logic = new Logic();
            _logic.LogMessageToUI += Logic_LogMessageToUI;
            _logic.NumbersGenerated += Logic_NumbersGenerated;
            _logic.NumberGeneratedOutput += Logic_NumberGeneratedOutput;

            _cancelTokenSource = new CancellationTokenSource();
            _outputBuffer = new StringBuilder();

            multiplierInput.Text = GeneratorOptions.Default.Multiplier.ToString();
            increaseInput.Value = GeneratorOptions.Default.Increase;
            ComparisonModuleInput.Text = GeneratorOptions.Default.ComparisonModule.ToString();
            startValueInput.Value = GeneratorOptions.Default.StartValue;

            //multiplierInput.Value = GeneratorOptions.Optimal.Multiplier;
            //increaseInput.Value = GeneratorOptions.Optimal.Increase;
            //ComparisonModuleInput.Value = GeneratorOptions.Optimal.ComparisonModule;
            //startValueInput.Value = GeneratorOptions.Optimal.StartValue;
        }

        private void Logic_LogMessageToUI(string message)
        {
            logOutput.Text = message;
        }

        private void Logic_NumberGeneratedOutput(string message)
        {
            Output(message);
        }

        private void Logic_NumbersGenerated(ulong count)
        {
            numbersCountOutput.Text = $"Numbers generated: {count}";
        }

        private async void GenerateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateForms())
                return;

            SetEnableUiElements(true);
            ClearOutputs();

            var stopWatch = new Stopwatch();
            var token = _cancelTokenSource.Token;

            _numbersCountToGenerate = (ulong)countInput.Value;

            stopWatch.Start();

            decimal m = (decimal)new Expression(ComparisonModuleInput.Text).calculate();


            await _logic.ExecuteDefaultComparing(
                _numbersCountToGenerate,
                new GeneratorOptions
                {
                    Multiplier = (ulong)new Expression(multiplierInput.Text).calculate(),
                    Increase = (ulong)increaseInput.Value,
                    StartValue = (ulong)startValueInput.Value,
                    ComparisonModule = (ulong)new Expression(ComparisonModuleInput.Text).calculate()
                },

                token);

            stopWatch.Stop();

            ForceOutput();
            ShowTimeSpentMessageBox(stopWatch);
            SetEnableUiElements(false);
        }

        private bool ValidateForms()
        {
            //Xn+1 = ( a*Xn + c)mod m
            // c  ==  increase
            // m  ==  comparisonModule
            // a  ==  multiplier
            // x  == current x
            
            var c = increaseInput.Value;
            var x0 = startValueInput.Value;
            var count = countInput.Value;
            try
            {
                Expression mExpresion = new Expression(ComparisonModuleInput.Text);
                decimal m = (decimal)mExpresion.calculate();

                if (m <= 0)
                {
                    throw new Exception("m must be greater that 0");
                }

                Expression aExpresion = new Expression(multiplierInput.Text);
                decimal a = (decimal)aExpresion.calculate();

                if (a < 0 || a >= m)
                {
                    throw new Exception("a must be greater or equal 0 and less than m");
                }
                if (c < 0 || c >= m)
                {
                    throw new Exception("c must be greater or equal 0 and less than m");
                }
                if (x0 < 0 || x0 >= m)
                {
                    throw new Exception("x0 must be greater or equal 0 and less than m");
                }
                if(count <= 0)
                {
                    throw new Exception("count must be greater than 0");
                }
            } 
            catch(Exception e)
            {
                MessageBox.Show(this, "incorrect parameter " + e.Message);
                return false;
            }
            return true;
        }

        private void ShowTimeSpentMessageBox(Stopwatch stopWatch)
        {
            TimeSpan ts = stopWatch.Elapsed;

            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            MessageBox.Show(this, elapsedTime, "Time spent");
        }

        private void ClearOutputs()
        {
            numbersCountOutput.Clear();
            logOutput.Clear();
            textOutput.Clear();
        }

        private void SetEnableUiElements(bool isExecutionStarted)
        {
            GenerateBtn.Enabled = !isExecutionStarted;

            if (isExecutionStarted)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void Output(string message)
        {
            _outputBuffer.Append(message);

            if ((ulong)_outputBuffer.Length > _outputBufferInterval)
            {
                ForceOutput();
            }
        }

        private void ForceOutput()
        {
            textOutput.AppendText(_outputBuffer.ToString());
            _outputBuffer.Clear();
        }

    }
}
