
namespace RSA_Client
{
    partial class Form1
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
            this.EncipherFileButton = new System.Windows.Forms.Button();
            this.RC5Key = new System.Windows.Forms.Label();
            this.RC5KeyText = new System.Windows.Forms.TextBox();
            this.EncipherFileText = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.EncipherButton = new System.Windows.Forms.Button();
            this.DecipherButton = new System.Windows.Forms.Button();
            this.importRSAParamButton = new System.Windows.Forms.Button();
            this.exportRSAParamButton = new System.Windows.Forms.Button();
            this.privatEncipherButton = new System.Windows.Forms.Button();
            this.privatDecipherButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChooseFileToDecipherRC5Btn = new System.Windows.Forms.Button();
            this.ChooseFileToDecipherRSABtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EncipherFileButton
            // 
            this.EncipherFileButton.Location = new System.Drawing.Point(21, 24);
            this.EncipherFileButton.Name = "EncipherFileButton";
            this.EncipherFileButton.Size = new System.Drawing.Size(81, 23);
            this.EncipherFileButton.TabIndex = 0;
            this.EncipherFileButton.Text = "EncipherFile";
            this.EncipherFileButton.UseVisualStyleBackColor = true;
            this.EncipherFileButton.Click += new System.EventHandler(this.EncipherFileButton_Click);
            // 
            // RC5Key
            // 
            this.RC5Key.AutoSize = true;
            this.RC5Key.Location = new System.Drawing.Point(27, 112);
            this.RC5Key.Name = "RC5Key";
            this.RC5Key.Size = new System.Drawing.Size(47, 15);
            this.RC5Key.TabIndex = 3;
            this.RC5Key.Text = "RC5Key";
            // 
            // RC5KeyText
            // 
            this.RC5KeyText.Location = new System.Drawing.Point(111, 104);
            this.RC5KeyText.Name = "RC5KeyText";
            this.RC5KeyText.Size = new System.Drawing.Size(209, 23);
            this.RC5KeyText.TabIndex = 4;
            // 
            // EncipherFileText
            // 
            this.EncipherFileText.Location = new System.Drawing.Point(121, 25);
            this.EncipherFileText.Name = "EncipherFileText";
            this.EncipherFileText.Size = new System.Drawing.Size(252, 23);
            this.EncipherFileText.TabIndex = 7;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(21, 240);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(733, 349);
            this.logTextBox.TabIndex = 8;
            this.logTextBox.Text = "";
            // 
            // EncipherButton
            // 
            this.EncipherButton.Location = new System.Drawing.Point(27, 188);
            this.EncipherButton.Name = "EncipherButton";
            this.EncipherButton.Size = new System.Drawing.Size(75, 23);
            this.EncipherButton.TabIndex = 9;
            this.EncipherButton.Text = "Encipher";
            this.EncipherButton.UseVisualStyleBackColor = true;
            this.EncipherButton.Click += new System.EventHandler(this.EncipherButton_Click);
            // 
            // DecipherButton
            // 
            this.DecipherButton.Location = new System.Drawing.Point(121, 188);
            this.DecipherButton.Name = "DecipherButton";
            this.DecipherButton.Size = new System.Drawing.Size(75, 23);
            this.DecipherButton.TabIndex = 10;
            this.DecipherButton.Text = "Decipher";
            this.DecipherButton.UseVisualStyleBackColor = true;
            this.DecipherButton.Click += new System.EventHandler(this.DecipherButton_Click);
            // 
            // importRSAParamButton
            // 
            this.importRSAParamButton.Location = new System.Drawing.Point(636, 12);
            this.importRSAParamButton.Name = "importRSAParamButton";
            this.importRSAParamButton.Size = new System.Drawing.Size(129, 23);
            this.importRSAParamButton.TabIndex = 11;
            this.importRSAParamButton.Text = "import RSA params";
            this.importRSAParamButton.UseVisualStyleBackColor = true;
            this.importRSAParamButton.Click += new System.EventHandler(this.importRSAParamButton_Click);
            // 
            // exportRSAParamButton
            // 
            this.exportRSAParamButton.Location = new System.Drawing.Point(639, 50);
            this.exportRSAParamButton.Name = "exportRSAParamButton";
            this.exportRSAParamButton.Size = new System.Drawing.Size(126, 23);
            this.exportRSAParamButton.TabIndex = 12;
            this.exportRSAParamButton.Text = "export RSA params";
            this.exportRSAParamButton.UseVisualStyleBackColor = true;
            this.exportRSAParamButton.Click += new System.EventHandler(this.exportRSAParamButton_Click);
            // 
            // privatEncipherButton
            // 
            this.privatEncipherButton.Location = new System.Drawing.Point(298, 188);
            this.privatEncipherButton.Name = "privatEncipherButton";
            this.privatEncipherButton.Size = new System.Drawing.Size(75, 23);
            this.privatEncipherButton.TabIndex = 13;
            this.privatEncipherButton.Text = "Encipher";
            this.privatEncipherButton.UseVisualStyleBackColor = true;
            this.privatEncipherButton.Click += new System.EventHandler(this.privatEncipherButton_Click);
            // 
            // privatDecipherButton
            // 
            this.privatDecipherButton.Location = new System.Drawing.Point(398, 188);
            this.privatDecipherButton.Name = "privatDecipherButton";
            this.privatDecipherButton.Size = new System.Drawing.Size(75, 23);
            this.privatDecipherButton.TabIndex = 14;
            this.privatDecipherButton.Text = "Decipher";
            this.privatDecipherButton.UseVisualStyleBackColor = true;
            this.privatDecipherButton.Click += new System.EventHandler(this.privatDecipherButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Privat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Privat";
            // 
            // ChooseFileToDecipherRC5Btn
            // 
            this.ChooseFileToDecipherRC5Btn.Location = new System.Drawing.Point(639, 89);
            this.ChooseFileToDecipherRC5Btn.Name = "ChooseFileToDecipherRC5Btn";
            this.ChooseFileToDecipherRC5Btn.Size = new System.Drawing.Size(129, 23);
            this.ChooseFileToDecipherRC5Btn.TabIndex = 17;
            this.ChooseFileToDecipherRC5Btn.Text = "RC5 File To Decipher";
            this.ChooseFileToDecipherRC5Btn.UseVisualStyleBackColor = true;
            this.ChooseFileToDecipherRC5Btn.Click += new System.EventHandler(this.ChooseFileToDecipherRC5Btn_Click);
            // 
            // ChooseFileToDecipherRSABtn
            // 
            this.ChooseFileToDecipherRSABtn.Location = new System.Drawing.Point(639, 130);
            this.ChooseFileToDecipherRSABtn.Name = "ChooseFileToDecipherRSABtn";
            this.ChooseFileToDecipherRSABtn.Size = new System.Drawing.Size(129, 23);
            this.ChooseFileToDecipherRSABtn.TabIndex = 18;
            this.ChooseFileToDecipherRSABtn.Text = "RSA File To Decipher";
            this.ChooseFileToDecipherRSABtn.UseVisualStyleBackColor = true;
            this.ChooseFileToDecipherRSABtn.Click += new System.EventHandler(this.ChooseFileToDecipherRSABtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 610);
            this.Controls.Add(this.ChooseFileToDecipherRSABtn);
            this.Controls.Add(this.ChooseFileToDecipherRC5Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.privatDecipherButton);
            this.Controls.Add(this.privatEncipherButton);
            this.Controls.Add(this.exportRSAParamButton);
            this.Controls.Add(this.importRSAParamButton);
            this.Controls.Add(this.DecipherButton);
            this.Controls.Add(this.EncipherButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.EncipherFileText);
            this.Controls.Add(this.RC5KeyText);
            this.Controls.Add(this.RC5Key);
            this.Controls.Add(this.EncipherFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncipherFileButton;
        private System.Windows.Forms.Label RC5Key;
        private System.Windows.Forms.TextBox RC5KeyText;
        private System.Windows.Forms.TextBox EncipherFileText;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button EncipherButton;
        private System.Windows.Forms.Button DecipherButton;
        private System.Windows.Forms.Button importRSAParamButton;
        private System.Windows.Forms.Button exportRSAParamButton;
        private System.Windows.Forms.Button privatEncipherButton;
        private System.Windows.Forms.Button privatDecipherButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChooseFileToDecipherRC5Btn;
        private System.Windows.Forms.Button ChooseFileToDecipherRSABtn;
    }
}

