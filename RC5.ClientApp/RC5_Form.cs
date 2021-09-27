using RC5Cryptography;
using RC5Cryptography.Extensions;
using RC5Cryptography.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RC5_ClientApp
{
    public partial class RC5_Client : Form
    {
        private readonly RC5 _rc5;
        private string _filePath;
        private const int KeyLength = 16;

        public RC5_Client()
        {
            _rc5 = new RC5(new AlgorithmSettings
            {
                Rounds = 8,
                WordLength = 16
            });

        }

        private void ChooseFileBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    filePathTextBox.Text = _filePath;
                }
            }
        }

        private void EncipherBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filePath))
            {
                MessageBox.Show("please, choose a file!", "RC5");
                return;
            }
            try
            {
                var hashedKey = Encoding.UTF8
                    .GetBytes(password.Text)
                    .GetMD5HashedKeyForRC5(KeyLength);

                var encodedFileContent = _rc5.EncipherCBCPAD(
                    File.ReadAllBytes(_filePath),
                    hashedKey);

                File.WriteAllBytes(PaddFilename(_filePath, "-enc"), encodedFileContent);

                MessageBox.Show("Enciphered", "RC5");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RC5");
            }
        }

        private static String PaddFilename(string filePath, string padding)
        {
            var fi = new FileInfo(filePath);
            var fn = Path.GetFileNameWithoutExtension(filePath);

            return Path.Combine(
                fi.DirectoryName,
                fn + padding + fi.Extension);
        }

        private void DecipherBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_filePath))
            {
                MessageBox.Show("File not choosen!", "RC5");

                return;
            }
            try
            {
                var hashedKey = Encoding.UTF8
                .GetBytes(password.Text)
                .GetMD5HashedKeyForRC5(KeyLength);

                var decodedFileContent = _rc5.DecipherCBCPAD(
                    File.ReadAllBytes(_filePath),
                    hashedKey);

                File.WriteAllBytes(PaddFilename(_filePath, "-dec"), decodedFileContent);

                MessageBox.Show("Deciphered", "RC5");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RC5");
            }
        }
    }
}
