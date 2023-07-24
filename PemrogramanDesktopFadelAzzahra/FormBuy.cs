using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.VisualBasic.Devices;
using QRCoder;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class FormBuy : Form
    {
        public FormBuy()
        {
            InitializeComponent();
        }

        private List<Product> products = new List<Product>();
        private string? transactionPath;
        private string? productPath;
        private Product selectedProduct;
        private int qtyProduct;
        private int priceProduct;

        private static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private List<Product> InitializeProductDatabase()
        {
            string[] rawDatabase;
            try
            {
                productPath = "../../../data_product.txt";
                rawDatabase = File.ReadAllLines(productPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("File database produk di path default tidak ditemukan. Mohon pilih file database secara manual!");
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
                    MessageBox.Show("File gagal dipilih. Tidak ada transaksi yang dapat dilakukan!");
                    string[] defaultData = new string[1];
                    defaultData[0] = "Product,Qty,Price";
                    rawDatabase = defaultData;
                    productPath = null;

                }

            }

            List<Product> tempproducts = new List<Product>();
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

        private string? InitializeTransactionDatabase()
        {
            string? databasePath;
            if (File.Exists("../../../data_transaction.txt") == false)
            {
                MessageBox.Show("File database transaksi di path default tidak ditemukan. Mohon pilih file database secara manual!");
                openFileDialog2.InitialDirectory = @"C:\";
                openFileDialog2.Title = "Browse Database File";
                openFileDialog2.Filter = "Text file (*.txt)|*.txt";
                openFileDialog2.Multiselect = false;
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    databasePath = openFileDialog2.FileName;
                }
                else
                {
                    MessageBox.Show("File gagal dipilih. Tidak ada transaksi yang dapat dilakukan!");
                    databasePath = null;
                }
            }
            else
            {
                databasePath = "../../../data_transaction.txt";
            };
            return databasePath;
        }

        private void FormBuy_Load(object sender, EventArgs e)
        {
            products = InitializeProductDatabase();
            transactionPath = InitializeTransactionDatabase();
            foreach (Product product in products)
            {
                listBox1.Items.Add(product.Name);
            }
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            UpdatePrice();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Kertas Struk", 400, 700);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown1.Maximum = products[listBox1.SelectedIndex].Stock;
            label4.Text = $"Stok kopi: {products[listBox1.SelectedIndex].Stock}";
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

        private void Checkout(Product selectedProduct, int qtyProduct)
        {
            if (transactionPath != null)
            {
                File.AppendAllText(transactionPath, string.Format("{0}{1}", Environment.NewLine, $"{selectedProduct.Name},{qtyProduct},{selectedProduct.Price * qtyProduct},{DateTime.Now.ToString()}"));
                MessageBox.Show("Transaksi berhasil dimasukkan ke data transaksi!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProcessOrder("../../../data_order.csv");
            }
            ReWriteProductDatabase(selectedProduct, qtyProduct);
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = 0;
            label4.Text = $"Stok kopi: {products[listBox1.SelectedIndex].Stock}";
            UpdatePrice();
            MessageBox.Show("Checkout berhasil!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void ProcessOrder(string path)
        {
            try
            {
                DateTime ordertimestamp = DateTime.Now;
                var guid = Guid.NewGuid();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,

                };
                Product selectedProduct = products[listBox1.SelectedIndex];
                int qtyProduct = (int)numericUpDown1.Value;
                var records = new List<Order>
                {
                    new Order {Id=guid, Pelanggan = textBox1.Text, Item = selectedProduct.Name, Jumlah = qtyProduct, Email= textBox2.Text, Waktu=ordertimestamp },
                };

                using var writer = new StreamWriter("../../../order.csv", append: true);
                using var csv = new CsvWriter(writer, config);
                csv.WriteRecords(records);

                QRCodeGenerator qrGenerator = new();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(4);
                pictureBox1.Image = qrCodeImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                MessageBox.Show("Transaksi berhasil dimasukkan ke data order! QR Code akan ditampilkan", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (await SendEmail(qrCodeImage))
                {
                    MessageBox.Show("QR Code berhasil dikirimkan ke email!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("QR Code gagal dikirimkan ke email!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Transaksi gagal dimasukkan ke data order!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> SendEmail(Bitmap bitmap)
        {
            try
            {
                var apiKey = "";
                var client = new SendGridClient(apiKey);

                var from = new EmailAddress("fadel.dummy1@gmail.com", "Fadel Azzahra");
                var to = new EmailAddress(textBox2.Text, textBox1.Text);
                var subject = "Coffee Shop! Receipt";
                var plainTextContent = "Berikut kode transaksi Coffee Shop! Fadel Azzahra berupa QR code. Anda dapat melakukan scan untuk verifikasi pesanan Anda";
                var htmlContent = "Berikut kode transaksi <strong>Coffee Shop! Fadel Azzahra</strong> berupa QR code. Anda dapat melakukan scan untuk verifikasi pesanan Anda";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                byte[] imageBytes = ImageToByteArray(bitmap);

                var attachment = new Attachment
                {
                    Content = Convert.ToBase64String(imageBytes),
                    Filename = "qrcode.bmp",
                    Type = "image/bmp",
                    Disposition = "attachment"
                };

                msg.AddAttachment(attachment);

                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch
            {
                return false;
            }
        }

        private void ReWriteProductDatabase(Product checkoutedProduct, int qtyCheckoutedProduct)
        {
            if (productPath != null)
            {
                File.WriteAllText(productPath, "Product,Qty,Price");
                foreach (Product product in products)
                {
                    if (product.Equals(checkoutedProduct))
                    {
                        product.Stock -= qtyCheckoutedProduct;
                    }
                    File.AppendAllText(productPath, $"{Environment.NewLine}{product.Name},{product.Stock},{product.Price}");
                }

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(null) || textBox1.Text.Equals("") || textBox2.Text.Equals(null) || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Isi nama dan email pemesan!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
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
                    Checkout(products[listBox1.SelectedIndex], (int)numericUpDown1.Value);
                }
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
            graphics.DrawString("Varian Kopi : " + selectedProduct.Name, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Jumlah      : " + qtyProduct, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("------------------------------------", fontRegular, brush, startX, startY + offset);

            // Total harga
            offset += 20;
            graphics.DrawString("Harga: " + priceProduct.ToString("C"), fontTitle, brush, startX, startY + offset);

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