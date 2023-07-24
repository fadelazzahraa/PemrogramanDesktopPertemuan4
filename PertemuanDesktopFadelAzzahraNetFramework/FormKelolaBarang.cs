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

            products = InitializeProductDatabase(connection);

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

        private BindingList<Product> InitializeProductDatabase(MySqlConnection connection)
        {
            BindingList<Product> temp = new BindingList<Product>();

            string query = "SELECT tbl_product.name, tbl_product.price, tbl_product.stock, tbl_category.category FROM tbl_product JOIN tbl_category on tbl_product.categoryId = tbl_category.id;";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int stock = reader.GetInt32("stock");
                        int price = reader.GetInt32("price");
                        string category = reader.GetString("category");
                        temp.Add(new Product(name, stock, price, category));
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

                string query = "UPDATE tbl_product SET stock = stock-@param1 WHERE id = @param2;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@param1", qtyCheckoutedProduct);
                    command.Parameters.AddWithValue("@param2", idProduct);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }

                

                connection.Close();
            }
            products = InitializeProductDatabase(connection);
            listBox1.Items.Clear();
            foreach (Product product in products)
            {
                listBox1.Items.Add($"[{product.Category}] {product.Name}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReWriteProductDatabase();
            MessageBox.Show("Database produk berhasil diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
