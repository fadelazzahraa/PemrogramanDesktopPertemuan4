﻿namespace PemrogramanDesktopFadelAzzahra
{
    partial class FormBuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuy));
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            printPreviewControl1 = new PrintPreviewControl();
            button2 = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button3 = new Button();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();
            openFileDialog1 = new OpenFileDialog();
            listBox1 = new ListBox();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            openFileDialog2 = new OpenFileDialog();
            textBox1 = new TextBox();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(25, 12);
            label1.Name = "label1";
            label1.Size = new Size(296, 32);
            label1.TabIndex = 0;
            label1.Text = "Pemesanan Coffee! Shop";
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(0, 514);
            button1.Name = "button1";
            button1.Size = new Size(353, 48);
            button1.TabIndex = 14;
            button1.Text = "Pesan!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.ForestGreen;
            label7.Location = new Point(25, 445);
            label7.Name = "label7";
            label7.Size = new Size(94, 32);
            label7.TabIndex = 15;
            label7.Text = "Rp0,00";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 430);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 16;
            label8.Text = "Harga";
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            printPreviewControl1.AutoZoom = false;
            printPreviewControl1.Location = new Point(359, 176);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(341, 278);
            printPreviewControl1.TabIndex = 17;
            printPreviewControl1.Zoom = 0.6D;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(359, 514);
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
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(359, 460);
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
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(115, 65);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(210, 184);
            listBox1.TabIndex = 20;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(115, 255);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(72, 23);
            numericUpDown1.TabIndex = 21;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 257);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 22;
            label3.Text = "Jumlah";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 281);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 23;
            label4.Text = "Stok kopi:";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 329);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "*wajib diisi";
            textBox1.Size = new Size(300, 23);
            textBox1.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 362);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 25;
            label5.Text = "E-Mail Pemesan";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(451, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 158);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 311);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 28;
            label6.Text = "Nama Pemesan";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(25, 380);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "*wajib diisi";
            textBox2.Size = new Size(300, 23);
            textBox2.TabIndex = 27;
            // 
            // FormBuy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 562);
            Controls.Add(label6);
            Controls.Add(textBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(printPreviewControl1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormBuy";
            Text = "Pemesanan Coffee! Shop";
            Load += FormBuy_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Label label7;
        private Label label8;
        private PrintPreviewControl printPreviewControl1;
        private Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button3;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private OpenFileDialog openFileDialog1;
        private ListBox listBox1;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label4;
        private OpenFileDialog openFileDialog2;
        private TextBox textBox1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private TextBox textBox2;
    }
}