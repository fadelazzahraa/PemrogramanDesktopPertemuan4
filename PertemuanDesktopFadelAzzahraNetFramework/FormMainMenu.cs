﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
    public partial class FormMainMenu : Form
    {
        private readonly User user;
        public FormMainMenu(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void formPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormBuy form1 = new FormBuy();
            /*form1.Closed += (s, args) => this.Close();*/
            form1.Show();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            if (user.Role == "Admin")
            {
                kelolaUserToolStripMenuItem.Enabled = true;
                kelolaUserToolStripMenuItem.Visible = true;
                kelolaBarangToolStripMenuItem.Enabled = true;
                kelolaBarangToolStripMenuItem.Visible = true;
                toolStripStatusLabel3.Text = "Logged in as Admin";
            }
            else
            {
                kelolaUserToolStripMenuItem.Enabled = false;
                kelolaUserToolStripMenuItem.Visible = false;
                kelolaBarangToolStripMenuItem.Enabled = false;
                kelolaBarangToolStripMenuItem.Visible = false;
                toolStripStatusLabel3.Text = "Logged in as User";
            }
        }

        private void menuUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKelolaUser formKelolaUser = new FormKelolaUser();
            /*form1.Closed += (s, args) => this.Close();*/
            formKelolaUser.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Closed += (s, args) => this.Close();
            formLogin.Show();
        }

        private void kelolaBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKelolaBarang formKelolaBarang = new FormKelolaBarang();
            /*form1.Closed += (s, args) => this.Close();*/
            formKelolaBarang.Show();
        }

    }
}