using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using PertemuanDesktopFadelAzzahraNetFramework;
using QRCoder;
using System.Windows.Controls;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
    public partial class FormBuy : Form
    {
        private MySqlConnection connection;

        public FormBuy()
        {
            InitializeComponent();
        }

        private List<Product> products = new List<Product>();
        private Product selectedProduct;
        private int qtyProduct;
        private int priceProduct;

        private static byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            FadelAzzahraDBConnection fadelazzahraDBConnection = new FadelAzzahraDBConnection();
            connection = fadelazzahraDBConnection.ConnectDBConnection();
            connection.Open();
            products = InitializeProductDatabase();
            connection.Close();

            foreach (Product product in products)
            {
                listBox1.Items.Add($"[{product.Category}] {product.Name} - Rp{product.Price}");
            }
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            UpdatePrice();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Kertas Struk", 400, 700);

        }

        private List<Product> InitializeProductDatabase()
        {
            List<Product> temp = new List<Product>();

            string query = "SELECT tbl_product.name, tbl_product.price, tbl_product.stock, tbl_category.category FROM tbl_product JOIN tbl_category on tbl_product.categoryId = tbl_category.id;";
            
            
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
            
            return temp;

        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown1.Maximum = products[listBox1.SelectedIndex].Stock;
            label4.Text = $"Stok: {products[listBox1.SelectedIndex].Stock}";
            UpdatePrice();
        }

        private int CalculateCoffeePrice()
        {
            return products[listBox1.SelectedIndex].Price * (int)numericUpDown1.Value;
        }

        private void UpdatePrice()
        {
            label7.Text = CalculateCoffeePrice().ToString("C");
        }

        private void Checkout(int idProduct, int qtyProduct)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"{selectedProduct.Name} - {qtyProduct}", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(4);
            pictureBox1.Image = qrCodeImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            ReWriteProductDatabase(idProduct + 1, qtyProduct);
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            label4.Text = $"Stok: {products[listBox1.SelectedIndex].Stock}";
            UpdatePrice();
            MessageBox.Show("Checkout berhasil!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReWriteProductDatabase(int idProduct, int qtyCheckoutedProduct)
        {
            string query = "UPDATE tbl_product SET stock = stock-@param1 WHERE id = @param2;";

            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@param1", qtyCheckoutedProduct);
                command.Parameters.AddWithValue("@param2", idProduct);

                using (MySqlDataReader reader = command.ExecuteReader())
                {

                }
            }

            products = InitializeProductDatabase();
            listBox1.Items.Clear();
            foreach (Product product in products)
            {
                listBox1.Items.Add($"[{product.Category}] {product.Name} - Rp{product.Price}");
            }
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            UpdatePrice();
            connection.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda ingin melakukan checkout?", "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                selectedProduct = products[listBox1.SelectedIndex];
                qtyProduct = (int)numericUpDown1.Value;
                priceProduct = CalculateCoffeePrice();
                printPreviewControl1.Document = printDocument1;
                button2.Enabled = true;
                button3.Enabled = true;
                Checkout(listBox1.SelectedIndex, (int)numericUpDown1.Value);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font fontRegular = new Font("Consolas", 12);
            Font fontBold = new Font("Consolas", 12, FontStyle.Bold);
            Font fontTitle = new Font("Consolas", 16, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);

            int startX = 10;
            int startY = 10;
            int offset = 40;


            // Judul struk
            graphics.DrawString("Coffee! Shop", fontTitle, brush, startX, startY);
            graphics.DrawString("------------------------------------", fontRegular, brush, startX, startY + offset);

            // Detail pesanan
            offset += 20;
            graphics.DrawString("Jenis Menu  : " + selectedProduct.Category, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Menu        : " + selectedProduct.Name, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Jumlah      : " + qtyProduct, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("------------------------------------", fontRegular, brush, startX, startY + offset);

            // Total harga
            offset += 20;
            graphics.DrawString("Harga  : " + priceProduct.ToString("C"), fontTitle, brush, startX, startY + offset);

            // Tanda terima kasih
            offset += 40;
            graphics.DrawString("Terima kasih atas kunjungan Anda!", fontRegular, brush, startX, startY + offset);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            ToolStripButton b = new ToolStripButton();
            b.DisplayStyle = ToolStripItemDisplayStyle.Text;
            b.Click += printPreview_PrintClick;
            b.ToolTipText = "Print";
            b.Text = "Print";
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(printPreviewDialog1.Controls[1])).Items.Insert(0, b);
            printPreviewDialog1.ShowDialog();
        }

        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}