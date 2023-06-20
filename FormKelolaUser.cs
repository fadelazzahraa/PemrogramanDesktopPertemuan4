using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class FormKelolaUser : Form
    {
        public FormKelolaUser()
        {
            InitializeComponent();
        }

        private BindingList<User> users = new BindingList<User>();
        private string? userPath;

        private void FormKelolaUser_Load(object sender, EventArgs e)
        {
            users = InitializeUserDatabase();
            dataGridView1.DataSource = users;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            User current = ((BindingList<User>)dataGridView1.DataSource)[e.RowIndex];
            string username = current.Username;
            string password = current.Password;
            string role = current.Role;
            ((BindingList<User>)dataGridView1.DataSource)[e.RowIndex] = new User(username, password, role);
        }

        private BindingList<User> InitializeUserDatabase()
        {
            string[] rawDatabase;
            try
            {
                userPath = "../../../data_user.txt";
                rawDatabase = File.ReadAllLines(userPath);
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
                    userPath = openFileDialog1.FileName;
                    rawDatabase = File.ReadAllLines(userPath);
                }
                else
                {
                    MessageBox.Show("File gagal dipilih. Tidak ada user yang dapat dikelola!");
                    string[] defaultData = new string[1];
                    defaultData[0] = "Username,Password,Role";
                    rawDatabase = defaultData;
                    userPath = null;

                }

            }

            BindingList<User> tempusers = new BindingList<User>();
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

        private bool ReWriteProductDatabase()
        {
            if (userPath != null)
            {
                File.WriteAllText(userPath, "Username,Password,Role");
                foreach (User user in users)
                {
                    File.AppendAllText(userPath, $"{Environment.NewLine}{user.Username},{user.Password},{user.Role}");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ReWriteProductDatabase())
            {
                MessageBox.Show("Database user berhasil diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Database user gagal diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            users.Add(new User("", "", ""));
        }
    }
}
