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
    public partial class FormKelolaBarang : Form
    {
        public FormKelolaBarang()
        {
            InitializeComponent();
        }

        private BindingList<Product> products = new BindingList<Product>();
        private string? productPath;

        private void FormKelolaBarang_Load(object sender, EventArgs e)
        {
            products = InitializeProductDatabase();
            dataGridView1.DataSource = products;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            Product current = ((BindingList<Product>)dataGridView1.DataSource)[e.RowIndex];
            string product = current.Name;
            int qty = current.Stock;
            int price = current.Price;
            ((BindingList<Product>)dataGridView1.DataSource)[e.RowIndex] = new Product(product, qty, price);
        }

        private BindingList<Product> InitializeProductDatabase()
        {
            string[] rawDatabase;
            try
            {
                productPath = @"D:\Data\Documents\VisualStudioProjects\PemrogramanDesktopPertemuan4\data_product.txt";
                rawDatabase = File.ReadAllLines(productPath);
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
                    productPath = openFileDialog1.FileName;
                    rawDatabase = File.ReadAllLines(productPath);
                }
                else
                {
                    MessageBox.Show("File gagal dipilih. Tidak ada produk yang dapat dikelola!");
                    string[] defaultData = new string[1];
                    defaultData[0] = "Product,Qty,Price";
                    rawDatabase = defaultData;
                    productPath = null;

                }

            }

            BindingList<Product> tempproducts = new BindingList<Product>();
            foreach (string rawData in rawDatabase)
            {
                if (rawData == "Product,Qty,Price")
                {
                    continue;
                }
                string[] rawDataSplitted = rawData.Split(',');
                tempproducts.Add(new Product(rawDataSplitted[0], Int16.Parse(rawDataSplitted[1]), Int16.Parse(rawDataSplitted[2])));
            }
            return tempproducts;

        }

        private bool ReWriteProductDatabase()
        {
            if (productPath != null)
            {
                File.WriteAllText(productPath, "Product,Qty,Price");
                foreach (Product product in products)
                {
                    File.AppendAllText(productPath, $"{Environment.NewLine}{product.Name},{product.Stock},{product.Price}");
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
                MessageBox.Show("Database produk berhasil diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Database produk gagal diupdate!", "Update User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            products.Add(new Product("", 0, 0));
        }
    }
}
