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

            users = InitializeUserDatabase();
            dataGridView1.DataSource = users;
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "deleteAction";
                button.HeaderText = "";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true; //dont forget this line
                this.dataGridView1.Columns.Add(button);
            }
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
            BindingList<User> temp = new BindingList<User>();

            string query = "SELECT * FROM tbl_user;";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string username = reader.GetString("username");
                        string password = reader.GetString("password");
                        string role = reader.GetString("role");
                        User newUser = new User(username, password, role);
                        newUser.id = id;
                        temp.Add(newUser);
                    }

                }
            }
            connection.Close();

            return temp;

        }

        private void ReWriteUserDatabase()
        {
            connection.Open();
            foreach (User user in users)
            {
                string query = "UPDATE tbl_user SET username = @param1, password = @param2, role = @param3 WHERE id = @param4;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@param1", user.Username);
                    command.Parameters.AddWithValue("@param2", user.Password);
                    command.Parameters.AddWithValue("@param3", user.Role);
                    command.Parameters.AddWithValue("@param4", user.id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }
            connection.Close();
            RefreshDataGridSource();


        }

        private void RefreshDataGridSource()
        {
            users = InitializeUserDatabase();

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = users;
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "deleteAction";
                button.HeaderText = "";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(button);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReWriteUserDatabase();
            MessageBox.Show("Database user berhasil diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO tbl_user (username, password, role) VALUES (@param1, @param2, @param3);";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@param1", "");
                command.Parameters.AddWithValue("@param2", "");
                command.Parameters.AddWithValue("@param3", "User");

                using (MySqlDataReader reader = command.ExecuteReader())
                {

                }
            }
            connection.Close();
            RefreshDataGridSource();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                User deletedUser = users[e.RowIndex];

                connection.Open();
                string query = "DELETE FROM tbl_user WHERE ID = @param1;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@param1", deletedUser.id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
                connection.Close();
                RefreshDataGridSource();
            }
        }
    }

}
