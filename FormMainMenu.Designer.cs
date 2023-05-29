namespace PemrogramanDesktopFadelAzzahra
{
    partial class FormMainMenu
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
            menuStrip1 = new MenuStrip();
            formPenjualanToolStripMenuItem = new ToolStripMenuItem();
            kelolaUserToolStripMenuItem = new ToolStripMenuItem();
            kelolaBarangToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { formPenjualanToolStripMenuItem, kelolaUserToolStripMenuItem, kelolaBarangToolStripMenuItem, logoutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(465, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // formPenjualanToolStripMenuItem
            // 
            formPenjualanToolStripMenuItem.Name = "formPenjualanToolStripMenuItem";
            formPenjualanToolStripMenuItem.Size = new Size(102, 20);
            formPenjualanToolStripMenuItem.Text = "Form Penjualan";
            formPenjualanToolStripMenuItem.Click += formPenjualanToolStripMenuItem_Click;
            // 
            // kelolaUserToolStripMenuItem
            // 
            kelolaUserToolStripMenuItem.Name = "kelolaUserToolStripMenuItem";
            kelolaUserToolStripMenuItem.Size = new Size(77, 20);
            kelolaUserToolStripMenuItem.Text = "Kelola User";
            kelolaUserToolStripMenuItem.Click += menuUserToolStripMenuItem_Click;
            // 
            // kelolaBarangToolStripMenuItem
            // 
            kelolaBarangToolStripMenuItem.Name = "kelolaBarangToolStripMenuItem";
            kelolaBarangToolStripMenuItem.Size = new Size(91, 20);
            kelolaBarangToolStripMenuItem.Text = "Kelola Barang";
            kelolaBarangToolStripMenuItem.Click += kelolaBarangToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(57, 20);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 143);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(465, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(10, 17);
            toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(74, 17);
            toolStripStatusLabel3.Text = "Logged in as";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(125, 60);
            label2.Name = "label2";
            label2.Size = new Size(214, 45);
            label2.TabIndex = 5;
            label2.Text = "Coffee! Shop";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 165);
            Controls.Add(label2);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMainMenu";
            Text = "Main Menu";
            Load += Form3_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem formPenjualanToolStripMenuItem;
        private ToolStripMenuItem kelolaUserToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private Label label2;
        private ToolStripMenuItem kelolaBarangToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
    }
}