
namespace DSS_App
{
    partial class DSS
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
            this.textInput = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.CreateSignatureButton = new System.Windows.Forms.Button();
            this.ChooseVerificationFileButton = new System.Windows.Forms.Button();
            this.ChooseSignatureButton = new System.Windows.Forms.Button();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Location = new System.Drawing.Point(12, 12);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(387, 23);
            this.textInput.TabIndex = 0;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 152);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(545, 249);
            this.logTextBox.TabIndex = 1;
            this.logTextBox.Text = "";
            // 
            // CreateSignatureButton
            // 
            this.CreateSignatureButton.Location = new System.Drawing.Point(418, 11);
            this.CreateSignatureButton.Name = "CreateSignatureButton";
            this.CreateSignatureButton.Size = new System.Drawing.Size(139, 23);
            this.CreateSignatureButton.TabIndex = 2;
            this.CreateSignatureButton.Text = "Create Signature";
            this.CreateSignatureButton.UseVisualStyleBackColor = true;
            this.CreateSignatureButton.Click += new System.EventHandler(this.CreateSignatureButton_Click);
            // 
            // ChooseVerificationFileButton
            // 
            this.ChooseVerificationFileButton.Location = new System.Drawing.Point(13, 53);
            this.ChooseVerificationFileButton.Name = "ChooseVerificationFileButton";
            this.ChooseVerificationFileButton.Size = new System.Drawing.Size(144, 23);
            this.ChooseVerificationFileButton.TabIndex = 3;
            this.ChooseVerificationFileButton.Text = "Choose File To Verify Signature";
            this.ChooseVerificationFileButton.UseVisualStyleBackColor = true;
            this.ChooseVerificationFileButton.Click += new System.EventHandler(this.ChooseVerificationFileButton_Click);
            // 
            // ChooseSignatureButton
            // 
            this.ChooseSignatureButton.Location = new System.Drawing.Point(13, 82);
            this.ChooseSignatureButton.Name = "ChooseSignatureButton";
            this.ChooseSignatureButton.Size = new System.Drawing.Size(144, 23);
            this.ChooseSignatureButton.TabIndex = 4;
            this.ChooseSignatureButton.Text = "Choose Signature";
            this.ChooseSignatureButton.UseVisualStyleBackColor = true;
            this.ChooseSignatureButton.Click += new System.EventHandler(this.ChooseSignatureButton_Click);
            // 
            // VerifyButton
            // 
            this.VerifyButton.Location = new System.Drawing.Point(13, 111);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(144, 23);
            this.VerifyButton.TabIndex = 5;
            this.VerifyButton.Text = "Verify";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // DSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 413);
            this.Controls.Add(this.VerifyButton);
            this.Controls.Add(this.ChooseSignatureButton);
            this.Controls.Add(this.ChooseVerificationFileButton);
            this.Controls.Add(this.CreateSignatureButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.textInput);
            this.Name = "DSS";
            this.Text = "DSS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Button CreateSignatureButton;
        private System.Windows.Forms.Button ChooseVerificationFileButton;
        private System.Windows.Forms.Button ChooseSignatureButton;
        private System.Windows.Forms.Button VerifyButton;
    }
}

