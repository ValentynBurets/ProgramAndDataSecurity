
namespace RC5_ClientApp
{
    partial class RC5_Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.ChooseFileBtn = new System.Windows.Forms.Button();
            this.EncipherBtn = new System.Windows.Forms.Button();
            this.DecipherBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 12);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(457, 23);
            this.password.TabIndex = 1;
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(12, 61);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(457, 23);
            this.filePathTextBox.TabIndex = 2;
            // 
            // ChooseFileBtn
            // 
            this.ChooseFileBtn.Location = new System.Drawing.Point(500, 52);
            this.ChooseFileBtn.Name = "ChooseFileBtn";
            this.ChooseFileBtn.Size = new System.Drawing.Size(75, 39);
            this.ChooseFileBtn.TabIndex = 3;
            this.ChooseFileBtn.Text = "Choose File";
            this.ChooseFileBtn.UseVisualStyleBackColor = true;
            this.ChooseFileBtn.Click += new System.EventHandler(this.ChooseFileBtn_Click);
            // 
            // EncipherBtn
            // 
            this.EncipherBtn.Location = new System.Drawing.Point(128, 111);
            this.EncipherBtn.Name = "EncipherBtn";
            this.EncipherBtn.Size = new System.Drawing.Size(75, 23);
            this.EncipherBtn.TabIndex = 4;
            this.EncipherBtn.Text = "Encipher";
            this.EncipherBtn.UseVisualStyleBackColor = true;
            this.EncipherBtn.Click += new System.EventHandler(this.EncipherBtn_Click);
            // 
            // DecipherBtn
            // 
            this.DecipherBtn.Location = new System.Drawing.Point(249, 111);
            this.DecipherBtn.Name = "DecipherBtn";
            this.DecipherBtn.Size = new System.Drawing.Size(75, 23);
            this.DecipherBtn.TabIndex = 5;
            this.DecipherBtn.Text = "Decipher";
            this.DecipherBtn.UseVisualStyleBackColor = true;
            this.DecipherBtn.Click += new System.EventHandler(this.DecipherBtn_Click);
            // 
            // RC5_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 153);
            this.Controls.Add(this.DecipherBtn);
            this.Controls.Add(this.EncipherBtn);
            this.Controls.Add(this.ChooseFileBtn);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Name = "RC5_Client";
            this.Text = "RC5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button ChooseFileBtn;
        private System.Windows.Forms.Button EncipherBtn;
        private System.Windows.Forms.Button DecipherBtn;
    }
}

