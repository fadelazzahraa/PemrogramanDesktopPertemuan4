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
    public partial class Form3 : Form
    {
        private List<User> _userlist = new();

        public Form3()
        {
            InitializeComponent();
            _userlist.Add(new User("user", "password", false));
            _userlist.Add(new User("admin", "adminpassword", true));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;

            var result = _userlist.FirstOrDefault(x => x.Username == uname);
            if (result != null)
            {
                if (result.Password == pass)
                {
                    MessageBox.Show("Berhasil Login");
                    Form2 form2 = new(result.Username);
                    this.Hide();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Password Salah");
                }
            }
            else
            {
                MessageBox.Show("User tidak ditemukan!");
            }
        }
    }
}
