
namespace Client
{
    partial class MD5_Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalcHashFromString = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputStr = new System.Windows.Forms.TextBox();
            this.outStrHash = new System.Windows.Forms.TextBox();
            this.btnHashFile = new System.Windows.Forms.Button();
            this.saveHashBtn = new System.Windows.Forms.Button();
            this.loadHashBtn = new System.Windows.Forms.Button();
            this.filename = new System.Windows.Forms.TextBox();
            this.savedHashFilename = new System.Windows.Forms.TextBox();
            this.loadedHashFileName = new System.Windows.Forms.TextBox();
            this.outFileHash = new System.Windows.Forms.TextBox();
            this.loadedHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comapareHashesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalcHashFromString
            // 
            this.btnCalcHashFromString.Location = new System.Drawing.Point(604, 12);
            this.btnCalcHashFromString.Name = "btnCalcHashFromString";
            this.btnCalcHashFromString.Size = new System.Drawing.Size(84, 57);
            this.btnCalcHashFromString.TabIndex = 0;
            this.btnCalcHashFromString.Text = "Hash String";
            this.btnCalcHashFromString.UseVisualStyleBackColor = true;
            this.btnCalcHashFromString.Click += new System.EventHandler(this.btnCalcHashFromString_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Res Hash String";
            // 
            // inputStr
            // 
            this.inputStr.Location = new System.Drawing.Point(12, 12);
            this.inputStr.Name = "inputStr";
            this.inputStr.Size = new System.Drawing.Size(573, 23);
            this.inputStr.TabIndex = 2;
            // 
            // outStrHash
            // 
            this.outStrHash.Enabled = false;
            this.outStrHash.HideSelection = false;
            this.outStrHash.Location = new System.Drawing.Point(12, 83);
            this.outStrHash.Name = "outStrHash";
            this.outStrHash.Size = new System.Drawing.Size(573, 23);
            this.outStrHash.TabIndex = 3;
            // 
            // btnHashFile
            // 
            this.btnHashFile.Location = new System.Drawing.Point(604, 164);
            this.btnHashFile.Name = "btnHashFile";
            this.btnHashFile.Size = new System.Drawing.Size(84, 23);
            this.btnHashFile.TabIndex = 4;
            this.btnHashFile.Text = "Hash File";
            this.btnHashFile.UseVisualStyleBackColor = true;
            this.btnHashFile.Click += new System.EventHandler(this.btnHashFile_ClickAsync);
            // 
            // saveHashBtn
            // 
            this.saveHashBtn.Location = new System.Drawing.Point(604, 207);
            this.saveHashBtn.Name = "saveHashBtn";
            this.saveHashBtn.Size = new System.Drawing.Size(84, 23);
            this.saveHashBtn.TabIndex = 5;
            this.saveHashBtn.Text = "Save Hash";
            this.saveHashBtn.UseVisualStyleBackColor = true;
            this.saveHashBtn.Click += new System.EventHandler(this.saveHashBtn_Click);
            // 
            // loadHashBtn
            // 
            this.loadHashBtn.Location = new System.Drawing.Point(604, 248);
            this.loadHashBtn.Name = "loadHashBtn";
            this.loadHashBtn.Size = new System.Drawing.Size(84, 23);
            this.loadHashBtn.TabIndex = 6;
            this.loadHashBtn.Text = "Load Hash";
            this.loadHashBtn.UseVisualStyleBackColor = true;
            this.loadHashBtn.Click += new System.EventHandler(this.loadHashBtn_Click);
            // 
            // filename
            // 
            this.filename.Enabled = false;
            this.filename.HideSelection = false;
            this.filename.Location = new System.Drawing.Point(12, 165);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(573, 23);
            this.filename.TabIndex = 7;
            // 
            // savedHashFilename
            // 
            this.savedHashFilename.Enabled = false;
            this.savedHashFilename.HideSelection = false;
            this.savedHashFilename.Location = new System.Drawing.Point(12, 207);
            this.savedHashFilename.Name = "savedHashFilename";
            this.savedHashFilename.Size = new System.Drawing.Size(573, 23);
            this.savedHashFilename.TabIndex = 8;
            // 
            // loadedHashFileName
            // 
            this.loadedHashFileName.Enabled = false;
            this.loadedHashFileName.HideSelection = false;
            this.loadedHashFileName.Location = new System.Drawing.Point(12, 249);
            this.loadedHashFileName.Name = "loadedHashFileName";
            this.loadedHashFileName.Size = new System.Drawing.Size(573, 23);
            this.loadedHashFileName.TabIndex = 9;
            // 
            // outFileHash
            // 
            this.outFileHash.Enabled = false;
            this.outFileHash.HideSelection = false;
            this.outFileHash.Location = new System.Drawing.Point(12, 340);
            this.outFileHash.Name = "outFileHash";
            this.outFileHash.Size = new System.Drawing.Size(573, 23);
            this.outFileHash.TabIndex = 10;
            // 
            // loadedHash
            // 
            this.loadedHash.Enabled = false;
            this.loadedHash.HideSelection = false;
            this.loadedHash.Location = new System.Drawing.Point(12, 392);
            this.loadedHash.Name = "loadedHash";
            this.loadedHash.Size = new System.Drawing.Size(573, 23);
            this.loadedHash.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "loaded hash from file";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Res File Hash String";
            // 
            // comapareHashesBtn
            // 
            this.comapareHashesBtn.Location = new System.Drawing.Point(604, 357);
            this.comapareHashesBtn.Name = "comapareHashesBtn";
            this.comapareHashesBtn.Size = new System.Drawing.Size(84, 49);
            this.comapareHashesBtn.TabIndex = 14;
            this.comapareHashesBtn.Text = "Compare Hash";
            this.comapareHashesBtn.UseVisualStyleBackColor = true;
            this.comapareHashesBtn.Click += new System.EventHandler(this.comapareHashesBtn_Click);
            // 
            // MD5_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 427);
            this.Controls.Add(this.comapareHashesBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loadedHash);
            this.Controls.Add(this.outFileHash);
            this.Controls.Add(this.loadedHashFileName);
            this.Controls.Add(this.savedHashFilename);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.loadHashBtn);
            this.Controls.Add(this.saveHashBtn);
            this.Controls.Add(this.btnHashFile);
            this.Controls.Add(this.outStrHash);
            this.Controls.Add(this.inputStr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalcHashFromString);
            this.Name = "MD5_Client";
            this.Text = "HashTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcHashFromString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputStr;
        private System.Windows.Forms.TextBox outStrHash;
        private System.Windows.Forms.Button btnHashFile;
        private System.Windows.Forms.Button saveHashBtn;
        private System.Windows.Forms.Button loadHashBtn;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.TextBox savedHashFilename;
        private System.Windows.Forms.TextBox loadedHashFileName;
        private System.Windows.Forms.TextBox outFileHash;
        private System.Windows.Forms.TextBox loadedHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button comapareHashesBtn;
    }
}

