using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSS_App
{
    public partial class DSS : Form
    {
        private readonly DSACryptoServiceProvider _dsa = new DSACryptoServiceProvider();
        private readonly SHA1 _sha1 = SHA1.Create();
        private string signatureOutput = "";
        private string chosenFileToVirify = "";
        private string chosenSignatureFile = "";

        public DSS()
        {
            InitializeComponent();
        }

        private void CreateSignatureButton_Click(object sender, EventArgs e)
        {
            if(textInput.Text != "")
                ProcessSignature(Encoding.Default.GetBytes(textInput.Text));
            else
            {
                try
                {
                    using (var openFileDialog = new OpenFileDialog())
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var filePath = openFileDialog.FileName;
                            LogMessage("File input path is " + filePath);
                          
                            ProcessSignature(File.ReadAllBytes(filePath));
                        }
                        if (openFileDialog.FileName == "")
                        {
                            throw new Exception("The file isn`t chosen");
                        }
                    }
                }catch(Exception ex)
                {
                    LogMessage(ex.Message, "ERROR");
                    LogMessage("Process Creating Signature failed", "ERROR");
                }
                
            }
        }

        private void ProcessSignature(Byte[] message)
        {
            byte[] hash = _sha1.ComputeHash(message);
            string result = Convert.ToBase64String(_dsa.CreateSignature(hash));

            signatureOutput = result.Trim();

            LogMessage(signatureOutput, "INFO");

            SaveSignature();
        }

        private void SaveSignature()
        {
            if (string.IsNullOrEmpty(signatureOutput))
            {
                LogMessage("Can not create signature ", "WARNING");
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                RestoreDirectory = true,
                FileName = "Signature.txt"
            };

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, signatureOutput);
                    LogMessage("Signature saved");
                }
                else
                {
                    throw new Exception("can`t save signature");
                }
            }
            catch(Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
            }

        }

        private void LogMessage(string message, string logLevel = "INFO")
        {
            logTextBox.AppendText(
                $"{DateTime.Now.ToLongTimeString()} [{logLevel}]: {message}\n");
        }

        private void ChooseVerificationFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        chosenFileToVirify = openFileDialog.FileName;
                        LogMessage("Chosen file name to verify is " + chosenFileToVirify);
                    }
                    if (chosenFileToVirify == "")
                    {
                        throw new Exception("verification file not selected");
                    }
                }
                catch(Exception ex)
                {
                    LogMessage(ex.Message, "WARNING");
                }
            }
        }

        private void ChooseSignatureButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        chosenSignatureFile = openFileDialog.FileName;
                        LogMessage("Chosen signature to verify is " + chosenSignatureFile);
                    }
                }
                if (chosenSignatureFile == "")
                {
                    throw new Exception("verification file not selected");
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "WARNING");
            }

        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(chosenFileToVirify) || string.IsNullOrWhiteSpace(chosenFileToVirify))
            {
                return;
            }

            byte[] message = File.ReadAllBytes(chosenFileToVirify);
            string sign = File.ReadAllText(chosenSignatureFile);

            var result = VerifySignature(message, sign)
                ? "Verified"
                : "Not verified";

            
            LogMessage(result);
        }

        private bool VerifySignature(byte[] message, string sign)
        {
            try
            {
                byte[] hash = _sha1.ComputeHash(message);
                bool verified = _dsa.VerifySignature(hash, Convert.FromBase64String(sign));
                return verified;
            }
            catch
            {
                return false;
            }
        }
    }
}
