using RC5Cryptography;
using RC5Cryptography.Options;
using RSA_Client.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_Client
{
    public partial class Form1 : Form
    {
        private const string OpenEncipherFileTitle = "Filepath to be encipherd";
        private const string OpenDecipherFileRC5Title = "Filepath to be decipherd RC5";
        private const string OpenDecipherFileRSATitle = "Filepath to be decipherd RSA";

        private const int EncipherBlockSizeRSA = 64;
        private const int DecipherBlockSizeRSA = 128;

        private readonly RC5 _rc5;
        //private RSAParams rsa_params;
        //RSAParameters RSAParam;
        private readonly RSACryptoServiceProvider _rsa;

        private string _filepathToBeEnciphered;
        private string _filepathToBeDecipheredRC5;
        private string _filepathToBeDecipheredRSA;

        public Form1()
        {
            InitializeComponent();
            //RSAParam = _rsa.ExportParameters(true);
            //rsa_params = new RSAParams();
            //_rsa.ImportParameters(rsa_params.GetParams()) ;
            _rc5 = new RC5(new AlgorithmSettings
            {
                Rounds = 8,
                WordLength = 16
            });
            _rsa = new RSACryptoServiceProvider();
            exportRSAParam();
        }


        private void EncipherFileButton_Click(object sender, EventArgs e)
        {
            if (TryOpenFile(OpenEncipherFileTitle, out _filepathToBeEnciphered))
            {
                EncipherFileText.Text = _filepathToBeEnciphered;

                LogMessage($"{OpenEncipherFileTitle}: '{_filepathToBeEnciphered}'");
            }
        }

        private bool TryOpenFile(string dlgTitle, out string filepath)
        {
            bool isFilenameRetrieved = false;
            filepath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = dlgTitle;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog.FileName;
                    isFilenameRetrieved = true;
                }
            }

            return isFilenameRetrieved;
        }

        private void EncipherButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filepathToBeEnciphered))
            {
                var exMsg = "Failed to encipher, file not chosen.";
                LogMessage(exMsg, "ERROR");
                MessageBox.Show(exMsg, "Lab4");

                return;
            }
            if(RC5KeyText.Text == "")
            {
                var exMsg = "Please enter key for rc5.";
                LogMessage(exMsg, "ERROR");
                return;
            }

            try
            {
                ProcessEncipher();
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Process Encipher failed", "ERROR");
            }
        }

        private async void ProcessEncipher()
        {
            var stopWatch = new Stopwatch();
            var rc5HashedKey = Encoding.UTF8
                .GetBytes(RC5KeyText.Text);

            var inputBytes = File.ReadAllBytes(_filepathToBeEnciphered);
            LogMessage(
                 $"{inputBytes.Length} bytes read from file: {_filepathToBeEnciphered}.",
                 "INFO");

            stopWatch.Start();
            var rc5EncipheredBytes = _rc5.EncipherCBCPAD(
                inputBytes,
                rc5HashedKey);
            stopWatch.Stop();
            LogMessage(
                $"RC5 enciphered in {stopWatch.ElapsedMilliseconds} ms.",
                "INFO");

            var rsaEncipheredBytes = await EncipherRSAAsync(inputBytes);

            SaveBytesToFile(
                rc5EncipheredBytes,
                "Save RC5 enciphered file",
                _filepathToBeEnciphered,
                "-enc-rc5");

            var reverce_file_path = _filepathToBeEnciphered.ToCharArray();
            Array.Reverse(reverce_file_path);
            int revers_index = (new String(reverce_file_path)).IndexOf(".") + 1;
            int index = reverce_file_path.Length - revers_index;
            var rc5_path = _filepathToBeEnciphered;
            _filepathToBeDecipheredRC5 = rc5_path.Insert(index, "-enc-rc5");

            var rsa_path = _filepathToBeEnciphered;
            _filepathToBeDecipheredRSA = rsa_path.Insert(index, "-enc-rsa");

            SaveBytesToFile(
                rsaEncipheredBytes,
                "Save RSA enciphered file",
                _filepathToBeEnciphered,
                "-enc-rsa");
            
        }

        private async Task<Byte[]> EncipherRSAAsync(Byte[] inputBytes)
        {
            var stopWatch = new Stopwatch();
            var encipheredBytes = new List<byte>
            {
                Capacity = inputBytes.Length * 2
            };

            stopWatch.Start();

            await Task.Run(() =>
            {
                for (int i = 0; i < inputBytes.Length; i += EncipherBlockSizeRSA)
                {
                    var inputBlock = inputBytes
                        .Skip(i)
                        .Take(EncipherBlockSizeRSA)
                        .ToArray();

                    encipheredBytes.AddRange(_rsa.Encrypt(
                        inputBlock,
                        fOAEP: false));
                }
            });

            stopWatch.Stop();

            LogMessage(
                $"RSA enciphered in {stopWatch.ElapsedMilliseconds} ms.",
                "INFO");

            return encipheredBytes.ToArray();
        }

        private async Task<Byte[]> DecipherRSAAsync(Byte[] inputBytes)
        {
            var stopWatch = new Stopwatch();
            var decipheredBytes = new List<byte>
            {
                Capacity = inputBytes.Length / 2
            };

            stopWatch.Start();

            await Task.Run(() =>
            {
                for (int i = 0; i < inputBytes.Length; i += DecipherBlockSizeRSA)
                {
                    var inputBlock = inputBytes
                        .Skip(i)
                        .Take(DecipherBlockSizeRSA)
                        .ToArray();

                    decipheredBytes.AddRange(_rsa.Decrypt(
                        inputBlock,
                        fOAEP: false));
                }
            });

            stopWatch.Stop();

            LogMessage(
                $"RSA deciphered in {stopWatch.ElapsedMilliseconds} ms.",
                "INFO");

            return decipheredBytes.ToArray();
        }

        private void SaveBytesToFile(
            Byte[] rc5EncipheredBytes,
            string dlgTitle,
            string oldFileName,
            string filenamePadding)
        {
            using (var saveFileDlg = new SaveFileDialog())
            {
                saveFileDlg.Title = dlgTitle;
                saveFileDlg.FileName = PaddFilename(
                    oldFileName,
                    filenamePadding);

                var dlgRes = saveFileDlg.ShowDialog();

                if (dlgRes == DialogResult.OK)
                {
                    File.WriteAllBytes(
                        saveFileDlg.FileName,
                        rc5EncipheredBytes);

                    LogMessage($"File '{saveFileDlg.FileName}' saved.", "INFO");
                }
                else
                {
                    LogMessage($"File save cancelled.", "WARNING");
                }
            }
        }

        private static string PaddFilename(string filePath, string padding)
        {
            var fi = new FileInfo(filePath);
            var fn = Path.GetFileNameWithoutExtension(filePath);

            return Path.Combine(
                fi.DirectoryName,
                fn + padding + fi.Extension);
        }

        private void LogMessage(string message, string logLevel = "INFO")
        {
            logTextBox.AppendText(
                $"{DateTime.Now.ToLongTimeString()} [{logLevel}]: {message}\n");
        }

        private void ClearLogsBtn_Click(Object sender, EventArgs e)
        {
            logTextBox.Clear();
        }

        private void DecipherButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filepathToBeDecipheredRC5)
               || !File.Exists(_filepathToBeDecipheredRSA))
            {
                var exMsg = "Failed to decipher, files to decipher not chosen.";
                LogMessage(exMsg, "ERROR");
                MessageBox.Show(exMsg, "Lab4");

                return;
            }

            try
            {
                var import_key_rsa = File.ReadAllText("RSA_Keys.xml");
                if (import_key_rsa != "")
                    _rsa.FromXmlString(import_key_rsa);

                ProcessDecipher();
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Process Decipher failed", "ERROR");
            }
        }


        private async void ProcessDecipher()
        {
            var stopWatch = new Stopwatch();
            var hashedKey = Encoding.UTF8
                .GetBytes(RC5KeyText.Text);

            var bytesToBeDecipheredRC5 = File.ReadAllBytes(_filepathToBeDecipheredRC5);
            LogMessage(
                 $"{bytesToBeDecipheredRC5.Length} bytes read from file: {_filepathToBeDecipheredRC5}.",
                 "INFO");

            var bytesToBeDecipheredRSA = File.ReadAllBytes(_filepathToBeDecipheredRSA);
            LogMessage(
                 $"{bytesToBeDecipheredRSA.Length} bytes read from file: {_filepathToBeDecipheredRSA}.",
                 "INFO");

            stopWatch.Start();
            var decodedFileContent = _rc5.DecipherCBCPAD(
                bytesToBeDecipheredRC5,
                hashedKey);
            stopWatch.Stop();
            LogMessage(
                $"RC5 deciphered in {stopWatch.ElapsedMilliseconds} ms.",
                "INFO");

            var rsaDecipheredBytes = await DecipherRSAAsync(bytesToBeDecipheredRSA);

            SaveBytesToFile(
                decodedFileContent,
                "Save RC5 deciphered file",
                _filepathToBeDecipheredRC5,
                "-dec-rc5");

            SaveBytesToFile(
                rsaDecipheredBytes,
                "Save RSA enciphered file",
                _filepathToBeDecipheredRSA,
                "-dec-rsa");
        }

        private void importRSAParamButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryOpenFile("Import RSA keys", out var rsaKeysPath))
                    return;

                _rsa.FromXmlString(File.ReadAllText(rsaKeysPath));

                LogMessage($"Successfully imported RSA keys from '{rsaKeysPath}'");
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Import RSA keys failed", "ERROR");
            }
        }

        private void exportRSAParam()
        {
            try
            {
                using (var saveFileDlg = new SaveFileDialog())
                {
                    saveFileDlg.Title = "Export RSA keys";
                    saveFileDlg.FileName = "RSA_Keys.xml";


                    File.WriteAllText(
                        saveFileDlg.FileName,
                        _rsa.ToXmlString(includePrivateParameters: true));

                    LogMessage($"File '{saveFileDlg.FileName}' saved.", "INFO");

                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Export RSA keys failed", "ERROR");
            }
        }

        private void exportRSAParamButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDlg = new SaveFileDialog())
                {
                    saveFileDlg.Title = "Export RSA keys";
                    saveFileDlg.FileName = "RSA_Keys.xml";

                    var dlgRes = saveFileDlg.ShowDialog();

                    if (dlgRes == DialogResult.OK)
                    {
                        File.WriteAllText(
                            saveFileDlg.FileName,
                            _rsa.ToXmlString(includePrivateParameters: true));

                        LogMessage($"File '{saveFileDlg.FileName}' saved.", "INFO");
                    }
                    else
                    {
                        LogMessage($"File save cancelled.", "WARNING");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Export RSA keys failed", "ERROR");
            }
        }

        private async void privatEncipherButton_Click(object sender, EventArgs e)
        {

            if (!File.Exists(_filepathToBeEnciphered))
            {
                var exMsg = "Failed to encipher, file not chosen.";
                LogMessage(exMsg, "ERROR");
                MessageBox.Show(exMsg, "Lab4");

                return;
            }

            try
            {
                var inputBytes = File.ReadAllBytes(_filepathToBeEnciphered);
                LogMessage(
                     $"{inputBytes.Length} bytes read from file: {_filepathToBeEnciphered}.",
                     "INFO");

                var stopWatch = new Stopwatch();
                var encipheredBytes = new List<byte>
                {
                    Capacity = inputBytes.Length * 2
                };

                stopWatch.Start();

                await Task.Run(() =>
                {
                    for (int i = 0; i < inputBytes.Length; i += EncipherBlockSizeRSA)
                    {
                        var inputBlock = inputBytes
                            .Skip(i)
                            .Take(EncipherBlockSizeRSA)
                            .ToArray();

                        encipheredBytes.AddRange(_rsa.PrivateEncipher(inputBlock));
                    }
                });

                stopWatch.Stop();

                LogMessage(
                    $"RSA enciphered in {stopWatch.ElapsedMilliseconds} ms.",
                    "INFO");

                SaveBytesToFile(
                    encipheredBytes.ToArray(),
                    "Save RSA private enciphered file",
                    _filepathToBeEnciphered,
                    "-enc-pr-rsa");

                var reverce_file_path = _filepathToBeEnciphered.ToCharArray();
                Array.Reverse(reverce_file_path);
                int revers_index = (new String(reverce_file_path)).IndexOf(".") + 1;
                int index = reverce_file_path.Length - revers_index;
                var rsa_path = _filepathToBeEnciphered;
                _filepathToBeDecipheredRSA = rsa_path.Insert(index, "-enc-pr-rsa");
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Private encipher failed", "ERROR");
            }
        }

        private async void privatDecipherButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filepathToBeDecipheredRSA))
            {
                var exMsg = "Failed to decipher, file not chosen.";
                LogMessage(exMsg, "ERROR");
                MessageBox.Show(exMsg, "Lab4");

                return;
            }

            try
            {
                var inputBytes = File.ReadAllBytes(_filepathToBeDecipheredRSA);
                LogMessage(
                     $"{inputBytes.Length} bytes read from file: {_filepathToBeDecipheredRSA}.",
                     "INFO");

                var stopWatch = new Stopwatch();
                var decipheredBytes = new List<byte>();

                stopWatch.Start();

                await Task.Run(() =>
                {
                    for (int i = 0; i < inputBytes.Length; i += DecipherBlockSizeRSA)
                    {
                        var inputBlock = inputBytes
                            .Skip(i)
                            .Take(DecipherBlockSizeRSA)
                            .ToArray();

                        decipheredBytes.AddRange(_rsa.PublicDecipher(inputBlock));
                    }
                });

                stopWatch.Stop();

                LogMessage(
                    $"RSA deciphered in {stopWatch.ElapsedMilliseconds} ms.",
                    "INFO");

                SaveBytesToFile(
                    decipheredBytes.ToArray(),
                    "Save RSA private deciphered file",
                    _filepathToBeEnciphered,
                    "-dec-pr-rsa");
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, "ERROR");
                LogMessage("Private encipher failed", "ERROR");
            }
        }

        private void ChooseFileToDecipherRC5Btn_Click(object sender, EventArgs e)
        {
            if (TryOpenFile(OpenDecipherFileRC5Title, out _filepathToBeDecipheredRC5))
            {
                LogMessage($"{OpenDecipherFileRC5Title}: '{_filepathToBeDecipheredRC5}'");
            }
        }

        private void ChooseFileToDecipherRSABtn_Click(object sender, EventArgs e)
        {
            if (TryOpenFile(OpenDecipherFileRSATitle, out _filepathToBeDecipheredRSA))
            {
                LogMessage($"{OpenDecipherFileRSATitle}: '{_filepathToBeDecipheredRSA}'");
            }
        }
    }
}
