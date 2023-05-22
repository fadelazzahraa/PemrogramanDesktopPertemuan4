namespace PemrogramanDesktopFadelAzzahra
{
    partial class Form2
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
            button1 = new Button();
            button2 = new Button();
            colorDialog1 = new ColorDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label1 = new Label();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            listBox1 = new ListBox();
            saveFileDialog1 = new SaveFileDialog();
            textBox1 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            label2 = new Label();
            fontDialog1 = new FontDialog();
            button6 = new Button();
            textBox2 = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(33, 32);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Color";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(33, 61);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Folder";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 36);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 2;
            label1.Text = "Color test";
            // 
            // button3
            // 
            button3.Location = new Point(33, 90);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "File";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(125, 90);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(125, 219);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 107);
            textBox1.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(33, 219);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(284, 32);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 7;
            button5.Text = "Font";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(385, 36);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 8;
            label2.Text = "Font test";
            // 
            // button6
            // 
            button6.Location = new Point(284, 90);
            button6.Name = "button6";
            button6.Size = new Size(245, 23);
            button6.TabIndex = 9;
            button6.Text = "Read txt file";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(284, 119);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.Size = new Size(245, 207);
            textBox2.TabIndex = 10;
            textBox2.WordWrap = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 354);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(573, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 376);
            Controls.Add(statusStrip1);
            Controls.Add(textBox2);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ColorDialog colorDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private ListBox listBox1;
        private SaveFileDialog saveFileDialog1;
        private TextBox textBox1;
        private Button button4;
        private Button button5;
        private Label label2;
        private FontDialog fontDialog1;
        private Button button6;
        private TextBox textBox2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}