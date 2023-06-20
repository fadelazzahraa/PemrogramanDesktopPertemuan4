namespace PemrogramanDesktopFadelAzzahra
{
    partial class FormChatBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChatBot));
            printPreviewControl1 = new PrintPreviewControl();
            button2 = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button3 = new Button();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDialog1 = new PrintDialog();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            progressBar1 = new ProgressBar();
            button4 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            printPreviewControl1.AutoZoom = false;
            printPreviewControl1.Enabled = false;
            printPreviewControl1.Location = new Point(492, 176);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(341, 278);
            printPreviewControl1.TabIndex = 17;
            printPreviewControl1.Visible = false;
            printPreviewControl1.Zoom = 0.6D;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(492, 514);
            button2.Name = "button2";
            button2.Size = new Size(353, 48);
            button2.TabIndex = 18;
            button2.Text = "Cetak struk";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
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
            button3.Location = new Point(492, 460);
            button3.Name = "button3";
            button3.Size = new Size(353, 48);
            button3.TabIndex = 19;
            button3.Text = "Print preview";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
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
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Enabled = false;
            pictureBox1.Location = new Point(589, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 158);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(12, 272);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBox1.Size = new Size(471, 221);
            richTextBox1.TabIndex = 29;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(210, 243);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 28;
            button1.Text = "Chat!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 52);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(471, 185);
            textBox1.TabIndex = 27;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 499);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(471, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 30;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.Enabled = false;
            button4.Location = new Point(210, 243);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 31;
            button4.Text = "Reset";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Location = new Point(540, 187);
            label1.Name = "label1";
            label1.Size = new Size(251, 134);
            label1.TabIndex = 32;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormChatBot
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 562);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(progressBar1);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(printPreviewControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormChatBot";
            Text = "ChatBot Coffee! Shop";
            Load += FormChatBot_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PrintPreviewControl printPreviewControl1;
        private Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button3;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDialog printDialog1;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private TextBox textBox1;
        private ProgressBar progressBar1;
        private Button button4;
        private Label label1;
    }
}