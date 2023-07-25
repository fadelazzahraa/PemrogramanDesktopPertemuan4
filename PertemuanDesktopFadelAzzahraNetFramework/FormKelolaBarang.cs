using MySql.Data.MySqlClient;
using PertemuanDesktopFadelAzzahraNetFramework;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
    public partial class FormKelolaBarang : Form
    {

        private MySqlConnection connection;

        public FormKelolaBarang()
        {
            InitializeComponent();
        }

        private BindingList<Product> products = new BindingList<Product>();

        private void FormKelolaBarang_Load(object sender, EventArgs e)
        {
            FadelAzzahraDBConnection fadelazzahraDBConnection = new FadelAzzahraDBConnection();
            connection = fadelazzahraDBConnection.ConnectDBConnection();

            products = InitializeProductDatabase();

            dataGridView1.DataSource = products;
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
            Product current = ((BindingList<Product>)dataGridView1.DataSource)[e.RowIndex];
            string product = current.Name;
            int qty = current.Stock;
            int price = current.Price;
            string category = current.Category;
            ((BindingList<Product>)dataGridView1.DataSource)[e.RowIndex] = new Product(product, qty, price,category);
        }

        private BindingList<Product> InitializeProductDatabase()
        {
            BindingList<Product> temp = new BindingList<Product>();

            string query = "SELECT tbl_product.id, tbl_product.name, tbl_product.price, tbl_product.stock, tbl_category.category FROM tbl_product JOIN tbl_category on tbl_product.categoryId = tbl_category.id ORDER BY tbl_category.category ASC;";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string name = reader.GetString("name");
                        int stock = reader.GetInt32("stock");
                        int price = reader.GetInt32("price");
                        string category = reader.GetString("category");
                        Product newProduct = new Product(name, stock, price, category);
                        newProduct.id = id;
                        temp.Add(newProduct);
                    }
                    
                }
            }
            connection.Close();

            return temp;

        }

        private void ReWriteProductDatabase()
        {
            connection.Open();
            foreach (Product product in products)
            {
                int categoryId = product.Category == "Minuman" ? 1 : 2;
                string query = "UPDATE tbl_product SET name = @param1, price = @param2, stock = @param3, categoryId = @param4 WHERE id = @param5;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@param1", product.Name);
                    command.Parameters.AddWithValue("@param2", product.Price);
                    command.Parameters.AddWithValue("@param3", product.Stock);
                    command.Parameters.AddWithValue("@param4", categoryId);
                    command.Parameters.AddWithValue("@param5", product.id);

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
            products = InitializeProductDatabase();

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
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
            ReWriteProductDatabase();
            MessageBox.Show("Database produk berhasil diupdate!", "Update Barang", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO tbl_product (name, price, stock, categoryId) VALUES (@param1, @param2, @param3, @param4);";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@param1", "");
                command.Parameters.AddWithValue("@param2", 0);
                command.Parameters.AddWithValue("@param3", 0);
                command.Parameters.AddWithValue("@param4", 1);

                using (MySqlDataReader reader = command.ExecuteReader())
                {

                }
            }
            connection.Close();
            RefreshDataGridSource();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Product deletedProduct = products[e.RowIndex];
                
                connection.Open();
                string query = "DELETE FROM tbl_product WHERE ID = @param1;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@param1", deletedProduct.id);

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
