using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class FormLogin : Form
    {
        private List<User> users = new List<User>();

        public FormLogin()
        {
            InitializeComponent();

        }

        private List<User> InitializeUserDatabase()
        {
            string[] rawDatabase;
            try
            {
                rawDatabase = File.ReadAllLines("../../../data_user.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show("File database di path default tidak ditemukan. Mohon pilih file database secara manual!");
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Database File";
                openFileDialog1.Filter = "Text file (*.txt)|*.txt";
                openFileDialog1.Multiselect = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    rawDatabase = File.ReadAllLines(openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("File gagal dipilih. Tidak ada user yang dapat digunakan untuk login!");
                    string[] defaultData = new string[1];
                    defaultData[0] = "Username,Password,Role";
                    rawDatabase = defaultData;

                }

            }

            List<User> tempusers = new List<User>();
            foreach (string rawData in rawDatabase)
            {
                if (rawData == "Username,Password,Role")
                {
                    continue;
                }
                string[] rawDataSplitted = rawData.Split(',');
                tempusers.Add(new User(rawDataSplitted[0], rawDataSplitted[1], rawDataSplitted[2]));
            }
            return tempusers;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;

            var result = users.FirstOrDefault(x => x.Username == uname);
            if (result != null)
            {
                if (result.Password == pass)
                {
                    this.Hide();
                    FormMainMenu form3 = new FormMainMenu(result);
                    form3.Closed += (s, args) =>
                    {
                        this.Close();
                    };
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Password salah!");
                }
            }
            else
            {
                MessageBox.Show("User tidak ditemukan!");
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            users = InitializeUserDatabase();
        }
    }


}
