using MySql.Data.MySqlClient;
using PertemuanDesktopFadelAzzahraNetFramework;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
    public partial class FormKelolaUser : Form
    {
        private MySqlConnection connection;

        public FormKelolaUser()
        {
            InitializeComponent();
        }

        private BindingList<User> users = new BindingList<User>();

        private void FormKelolaUser_Load(object sender, EventArgs e)
        {
            FadelAzzahraDBConnection fadelazzahraDBConnection = new FadelAzzahraDBConnection();
            connection = fadelazzahraDBConnection.ConnectDBConnection();

            users = InitializeUserDatabase(connection);
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

        private BindingList<User> InitializeUserDatabase(MySqlConnection connection)
        {
            BindingList<User> temp = new BindingList<User>();

            string query = "SELECT * FROM tbl_user;";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader.GetString("username");
                        string password = reader.GetString("password");
                        string role = reader.GetString("password");
                        temp.Add(new User(username, password, role));
                    }

                }
            }
            connection.Close();

            return temp;

        }

        /*private bool ReWriteProductDatabase()
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
        }*/
    }
}
