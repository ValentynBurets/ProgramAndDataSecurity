
namespace Lab1
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.startValueInput = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.increaseInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.countInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textOutput = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.logOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numbersCountOutput = new System.Windows.Forms.TextBox();
            this.multiplierInput = new System.Windows.Forms.TextBox();
            this.ComparisonModuleInput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startValueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countInput)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ComparisonModuleInput);
            this.panel1.Controls.Add(this.multiplierInput);
            this.panel1.Controls.Add(this.startValueInput);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.increaseInput);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.GenerateBtn);
            this.panel1.Controls.Add(this.countInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 623);
            this.panel1.TabIndex = 0;
            // 
            // startValueInput
            // 
            this.startValueInput.AccessibleName = "CountNumeric";
            this.startValueInput.Location = new System.Drawing.Point(31, 343);
            this.startValueInput.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.startValueInput.Name = "startValueInput";
            this.startValueInput.Size = new System.Drawing.Size(120, 23);
            this.startValueInput.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "(X0) Start Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "(m) Comparison Module";
            // 
            // increaseInput
            // 
            this.increaseInput.AccessibleName = "CountNumeric";
            this.increaseInput.Location = new System.Drawing.Point(31, 206);
            this.increaseInput.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.increaseInput.Name = "increaseInput";
            this.increaseInput.Size = new System.Drawing.Size(120, 23);
            this.increaseInput.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "(c) Increase";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "(a) Multiplier";
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.AccessibleName = "GenerateBtn";
            this.GenerateBtn.Location = new System.Drawing.Point(31, 61);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(120, 23);
            this.GenerateBtn.TabIndex = 1;
            this.GenerateBtn.Text = "Generate";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // countInput
            // 
            this.countInput.AccessibleName = "CountNumeric";
            this.countInput.Location = new System.Drawing.Point(31, 32);
            this.countInput.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.countInput.Name = "countInput";
            this.countInput.Size = new System.Drawing.Size(120, 23);
            this.countInput.TabIndex = 1;
            this.countInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "numbersCountOutput";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textOutput);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.logOutput);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.numbersCountOutput);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(225, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 623);
            this.panel2.TabIndex = 1;
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(52, 185);
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(538, 423);
            this.textOutput.TabIndex = 6;
            this.textOutput.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "textOutput";
            // 
            // logOutput
            // 
            this.logOutput.Location = new System.Drawing.Point(52, 102);
            this.logOutput.Name = "logOutput";
            this.logOutput.Size = new System.Drawing.Size(538, 23);
            this.logOutput.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "logOutput";
            // 
            // numbersCountOutput
            // 
            this.numbersCountOutput.Location = new System.Drawing.Point(52, 32);
            this.numbersCountOutput.Name = "numbersCountOutput";
            this.numbersCountOutput.Size = new System.Drawing.Size(538, 23);
            this.numbersCountOutput.TabIndex = 2;
            // 
            // multiplierInput
            // 
            this.multiplierInput.Location = new System.Drawing.Point(31, 151);
            this.multiplierInput.Name = "multiplierInput";
            this.multiplierInput.Size = new System.Drawing.Size(120, 23);
            this.multiplierInput.TabIndex = 7;
            // 
            // ComparisonModuleInput
            // 
            this.ComparisonModuleInput.Location = new System.Drawing.Point(31, 285);
            this.ComparisonModuleInput.Name = "ComparisonModuleInput";
            this.ComparisonModuleInput.Size = new System.Drawing.Size(120, 23);
            this.ComparisonModuleInput.TabIndex = 10;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 647);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countInput)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.NumericUpDown countInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox textOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox logOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numbersCountOutput;
        private System.Windows.Forms.NumericUpDown startValueInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown increaseInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ComparisonModuleInput;
        private System.Windows.Forms.TextBox multiplierInput;
    }
}

