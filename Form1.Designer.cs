namespace PemrogramanDesktopFadelAzzahra
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pageSetupDialog1 = new PageSetupDialog();
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button4 = new Button();
            printPreviewControl1 = new PrintPreviewControl();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(328, 53);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 0;
            button1.Text = "Print";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(328, 24);
            button2.Name = "button2";
            button2.Size = new Size(104, 23);
            button2.TabIndex = 1;
            button2.Text = "Page Setup";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(328, 82);
            button3.Name = "button3";
            button3.Size = new Size(104, 23);
            button3.TabIndex = 2;
            button3.Text = "Print Preview";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(328, 147);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 67);
            textBox1.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(508, 53);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(508, 25);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(120, 23);
            textBox2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(449, 28);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 6;
            label1.Text = "Harga";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(449, 57);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 7;
            label2.Text = "Jumlah";
            // 
            // button4
            // 
            button4.Location = new Point(328, 111);
            button4.Name = "button4";
            button4.Size = new Size(104, 23);
            button4.TabIndex = 8;
            button4.Text = "Show Preview";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Location = new Point(12, 12);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(298, 202);
            printPreviewControl1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 226);
            Controls.Add(printPreviewControl1);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PageSetupDialog pageSetupDialog1;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button4;
        private PrintPreviewControl printPreviewControl1;
    }
}