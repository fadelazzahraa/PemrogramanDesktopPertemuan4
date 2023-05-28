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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label4 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            printPreviewControl1 = new PrintPreviewControl();
            button2 = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button3 = new Button();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(300, 32);
            label1.TabIndex = 0;
            label1.Text = "Aplikasi Pemesanan Kopi";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 65);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Varian Kopi";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Espresso - Rp10.000,00", "Latte - Rp15.000,00", "Cappuccino - Rp12.000,00" });
            comboBox1.Location = new Point(113, 62);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(226, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Espresso - Rp10.000,00";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 93);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 3;
            label3.Text = "Ukuran";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(113, 91);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 19);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.Text = "Medium";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(189, 91);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(150, 19);
            radioButton2.TabIndex = 5;
            radioButton2.Text = "Large (extra Rp2.000,00)";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 122);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 6;
            label4.Text = "Level Gula (%)";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            numericUpDown1.Location = new Point(113, 120);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(86, 23);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            numericUpDown2.Location = new Point(113, 149);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(86, 23);
            numericUpDown2.TabIndex = 9;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 151);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 8;
            label5.Text = "Level Es (%)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 180);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 10;
            label6.Text = "Tambahan";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Bubble + Rp3.000,00", "Grass Jelly + Rp3.500,00", "Nata de coco + Rp2.500,00", "Whipped cream + Rp1.000,00", "Choco chip + Rp1.500,00", "Oreo + Rp2.000,00" });
            checkedListBox1.Location = new Point(113, 178);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(226, 112);
            checkedListBox1.TabIndex = 11;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(0, 394);
            button1.Name = "button1";
            button1.Size = new Size(353, 48);
            button1.TabIndex = 14;
            button1.Text = "Buat struk";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.ForestGreen;
            label7.Location = new Point(25, 326);
            label7.Name = "label7";
            label7.Size = new Size(94, 32);
            label7.TabIndex = 15;
            label7.Text = "Rp0,00";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 311);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 16;
            label8.Text = "Harga";
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.AutoZoom = false;
            printPreviewControl1.Location = new Point(359, 12);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(341, 314);
            printPreviewControl1.TabIndex = 17;
            printPreviewControl1.Zoom = 0.6D;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(359, 394);
            button2.Name = "button2";
            button2.Size = new Size(353, 48);
            button2.TabIndex = 18;
            button2.Text = "Cetak struk";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(359, 340);
            button3.Name = "button3";
            button3.Size = new Size(353, 48);
            button3.TabIndex = 19;
            button3.Text = "Print preview";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
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
            // printDialog1
            // 
            printDialog1.Document = printDocument1;
            printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 442);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(printPreviewControl1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Controls.Add(label6);
            Controls.Add(numericUpDown2);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(label4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Aplikasi Pemesanan Kopi - Fadel Azzahra";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label5;
        private Label label6;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Label label7;
        private Label label8;
        private PrintPreviewControl printPreviewControl1;
        private Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button3;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
    }
}