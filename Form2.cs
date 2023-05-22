using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "adminpassword")
            {
                this.Hide();
                Form3 form3 = new Form3(true);
                form3.Closed += (s, args) => this.Close();
                form3.Show();
            }
            else if (textBox1.Text == "user" && textBox2.Text == "userpassword")
            {
                this.Hide();
                Form3 form3 = new Form3(false);
                form3.Closed += (s, args) => this.Close();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }
    }


}
