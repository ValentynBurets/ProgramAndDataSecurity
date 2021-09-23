using HashingAlgorithm.Concrete;
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

namespace Client
{
    public partial class MD5_Client : Form
    {
        private readonly MD5 _hasher;
        private readonly MD5 _fileHasher;
        private string _filePath = string.Empty;
        private string _savedHashFilePath = string.Empty;
        private string _loadedHash = string.Empty;

        public MD5_Client()
        {
            InitializeComponent();
            _hasher = new MD5();
            _fileHasher = new MD5();
        }

        private void btnCalcHashFromString_Click(object sender, EventArgs e)
        {
            HashInputString();
        }

        private void HashInputString()
        {
            _hasher.ComputeHash(inputStr.Text);
            outStrHash.Text = _hasher.HashAsString;
        }

        private async void btnHashFile_ClickAsync(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;
                    filename.Text = _filePath;
                }
                else
                {
                    return;
                }
            }

            try
            {
                btnHashFile.Enabled = false;
                outFileHash.Text = await _fileHasher.GetFileHashAsync(_filePath);

                MessageBox.Show("File Hash Generated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnHashFile.Enabled = true;
            }
        }

        private void saveHashBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outFileHash.Text))
            {
                MessageBox.Show("Nothing to save!");

                return;
            }

            using (var openFileDialog = new SaveFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _savedHashFilePath = openFileDialog.FileName;

                    savedHashFilename.Text = _savedHashFilePath;
                }
            }

            File.WriteAllText(_savedHashFilePath, outFileHash.Text);
        }

        private void loadHashBtn_Click(object sender, EventArgs e)
        {
            var loadedHashFilePath = string.Empty;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedHashFilePath = openFileDialog.FileName;
                    loadedHashFileName.Text = loadedHashFilePath;
                }
                else
                {
                    return;
                }
            }

            _loadedHash = File.ReadAllText(loadedHashFilePath);
            loadedHash.Text = _loadedHash;
        }

        private void comapareHashesBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(outFileHash.Text)
               || string.IsNullOrWhiteSpace(_loadedHash))
            {
                MessageBox.Show("File or loaded hash not set!");

                return;
            }

            bool isHashMatch = string.Equals(
                outFileHash.Text.Trim(),
                _loadedHash.Trim(),
                StringComparison.CurrentCultureIgnoreCase);

            MessageBox.Show($"File and loaded hash comparison: {isHashMatch}");
        }
    }
}
