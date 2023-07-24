using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using PertemuanDesktopFadelAzzahraNetFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
    public partial class FormLogin : Form
    {
        private MySqlConnection connection;

        public FormLogin()
        {
            InitializeComponent();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FadelAzzahraDBConnection fadelazzahraDBConnection = new FadelAzzahraDBConnection();
            connection = fadelazzahraDBConnection.ConnectDBConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pass = textBox2.Text;

            string query = "SELECT * FROM tbl_user WHERE username = @param1 AND password = @param2;";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@param1", uname);
                command.Parameters.AddWithValue("@param2", pass);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string username = reader.GetString("username");
                            string password = reader.GetString("password");
                            string role = reader.GetString("role");
                            User loggedinUser = new User(username, password, role);
                            this.Hide();
                            FormMainMenu formMainMenu = new FormMainMenu(loggedinUser);
                            formMainMenu.Closed += (s, args) =>
                            {
                                this.Close();
                            };
                            formMainMenu.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!");
                    }
                }
            }
            connection.Close();

        }

        
    }


}
