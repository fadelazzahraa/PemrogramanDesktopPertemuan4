using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDotNet
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private readonly movieEntities _movieEntities;

        private static string hashing(string uname, string pass)
        {
            byte[] salt = Encoding.ASCII.GetBytes("INI SALT");
            byte[] userUuidBytes = Encoding.ASCII.GetBytes(uname);
            byte[] password = Encoding.ASCII.GetBytes(pass);
            var argon2 = new Argon2i(password)
            {
                DegreeOfParallelism = 16,
                MemorySize = 8192,
                Iterations = 40,
                Salt = salt,
                AssociatedData = userUuidBytes
            };
            var hash = argon2.GetBytes(128);
            string hashedValue = Encoding.ASCII.GetString(hash);
            return hashedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vUsername = textBox1.Text;
            string vPass = textBox2.Text;
            string vPhone = textBox3.Text;
            var newRecord = new tblUser()
            {
                username = vUsername,
                password = vPass,
                phone = vPhone
            };
            _movieEntities.tblUser.Add(newRecord);
            _movieEntities.SaveChanges();
            MessageBox.Show("Berhasil");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uname = textBox4.Text;
            string pass = textBox5.Text;
            string passHashed = hashing(uname, pass);

            var userRecord = _movieEntities.tblUser.ToList();
            var loggedInUser = userRecord.FirstOrDefault(user => user.username == uname && user.password == passHashed);
            if (loggedInUser != null)
            {
                MessageBox.Show("Berhasil");
            }
            else
            {
                MessageBox.Show("Gagal");
            }
        }
    }
}
