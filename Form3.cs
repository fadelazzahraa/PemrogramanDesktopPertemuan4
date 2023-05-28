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

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class Form3 : Form
    {
        private readonly bool isAdmin;
        private readonly List<User> users;
        public Form3(bool isAdmin, List<User> users)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.users = users;
        }

        private void formPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            /*form1.Closed += (s, args) => this.Close();*/
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (isAdmin == false)
            {
                menuUserToolStripMenuItem.Enabled = false;
                menuUserToolStripMenuItem.Visible = false;
            }
        }

        private void menuUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string listuser = "";
            
            foreach (User user in users)
            {
                string username = user.Username;
                string role = user.Admin == true ? "Admin" : "User";
                listuser += $"{username} ({role})";
                listuser += "\n";
            }
            MessageBox.Show("Daftar user " + "\n\n" + listuser);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
