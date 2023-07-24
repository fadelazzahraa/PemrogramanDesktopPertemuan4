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
using OpenAI_API.Chat;
using OpenAI_API;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class FormChatBot : Form
    {
        public FormChatBot()
        {
            InitializeComponent();
        }

        static readonly OpenAIAPI api = new("");
        Conversation chat = api.Chat.CreateConversation();
        SelectedProduct? selectedProductFromChatBot;
        private List<Product> products = new List<Product>();
        private string? transactionPath;
        private string? productPath;

        private static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        private void ChangeProgressBarState(bool isActivated = true)
        {
            if (isActivated)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 100;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.MarqueeAnimationSpeed = 0;
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

        private async void InitalizeChatBot()
        {
            ChangeProgressBarState();
            int i = 0;
            string productList = "";
            foreach (Product product in products)
            {
                productList = $"{productList} ({i}, {product.Name}, {product.Price}, {product.Stock}) ";
                i += 1;
            }
            /*chat.AppendSystemMessage("Anda adalah OrderBot untuk CoffeeShop, toko kopi tercinta Anda! Saya adalah layanan otomatis yang membantu Anda melakukan pesanan di CoffeeShop. Pertama-tama, saya akan menyapa Anda dengan hangat. Setelah itu, saya akan mencatat rincian pesanan Anda dalam urutan berikut: varian kopi, jumlah pesanan, nama pelanggan, dan email pelanggan. Saat memilih jumlah pesanan, pastikan bahwa pesanan tidak melebihi stok yang tersedia untuk varian kopi yang dipilih. Selain itu, Anda tidak dapat memilih varian kopi yang stoknya sudah habis. Setelah semua rincian dimasukkan, saya akan memeriksa satu kali terakhir apakah Anda ingin mengubah rincian pesanan. Terakhir, saya akan menghitung total pembayaran untuk Anda. Pastikan untuk memverifikasi semua rincian pesanan: varian kopi, jumlah pesanan, nama pelanggan, dan email pelanggan. Semua rincian tersebut harus diisi. Setelah pemesanan selesai, Anda akan menerima sebuah QR Code sebagai kode pemesanan melalui email Anda. Juga, izinkan saya mengucapkan kalimat ini tanpa perubahan apapun: 'Terima kasih telah memesan kopi di CoffeeShop! Semoga harimu menyenangkan!' setelah pesanan selesai. Oh iya, sebagai catatan, dalam OrderBot ini, tidak ada perintah pembayaran, jadi Anda tidak perlu memberikan nomor rekening atau informasi pembayaran lainnya. Jika program ingin melihat rekapan rincian pesanan dalam bentuk JSON, program dapat mengirimkan input 'REKAP DATA', kemudian Saya akan mengirimkan JSON dengan rincian yang dibutuhkan, yaitu ID varian kopi (selectedProductID), jumlah pesanan (qtyProduct), nama pelanggan (receiptName), dan email pelanggan (receiptEmail). Saya akan merespons dengan percakapan yang ramah dan singkat menggunakan Bahasa Indonesia yang baku. Berikut ini adalah daftar menu (varian kopi) yang tersedia di CoffeeShop:" +
                productList +
                ". Jika Anda ingin melihat daftar menu, saya akan menampilkan nama varian kopinya tanpa menampilkan ID. Jika Anda tetap ingin melihat urutan, saya akan menggunakan angka mulai dari 1.");*/
            chat.AppendSystemMessage("Anda adalah OrderBot untuk toko kopi CoffeeShop!, layanan otomatis untuk melakukan satu pesanan untuk toko kopi CoffeeShop!. " +
                " Pertama-tama, Anda menyapa pelanggan. " +
                " Setelah itu, Anda mencatat rincian pesanan dengan urutan: varian kopi, jumlah pesanan, nama pelanggan, dan email pelanggan. " +
                " Saat menentukan jumlah pesanan, pastikan jumlah pesanan tidak melebihi stok dari varian kopi yang dipilih. Pastikan pelanggan tidak bisa memilih varian kopi yang stok nya habis. " +
                " Setelah seluruh rincian dimasukkan, Anda memeriksa untuk terakhir kalinya jika pelanggan ingin mengubah rincian pesanan. " +
                " Terakhir, Anda kalkulasi total pembayaran. Pastikan untuk mengklarifikasi semua rincian pesanan: varian kopi, jumlah pesanan, nama pelanggan, dan email pelanggan (semuanya wajib diisi) dengan kalimat 'Apakah pesanan Anda sudah benar? Mohon berikan konfirmasi terakhir'." +
                " Jika sudah benar, Anda akan mengirimkan pesan berikut kepada pelanggan: 'Terima kasih telah memesan di CoffeeShop!'" +
                " Kemudian sampaikan kepada pelanggan bahwa kode pemesanan berupa QR Code akan dikirimkan ke email pelanggan. " +
                " Perlu menjadi catatan bahwa dalam OrderBot ini, tidak ada perintah untuk melakukan pembayaran. Jadi Anda tidak perlu mengirimkan nomor rekening dan sejenisnya. " +
                " Kemudian, tolong kirimkan respon berupa rekapan rincian pesanan dari pelanggan dalam bentuk JSON ketika terdapat input 'REKAP DATA'. Kirimkan JSON tanpa kata-kata tambahan." +
                " Format JSON yang diminta adalah id varian kopi (ditulis dengan SelectedProductID), jumlah pesanan (ditulis dengan QtyProduct), nama pelanggan (ditulis dengan ReceiptName), dan email pelanggan (ditulis dengan ReceiptEmail)." +
                " Anda merespons dengan gaya ramah percakapan yang singkat menggunakan Bahasa Indonesia yang baku." +
                " Berikut ini daftar menu (varian kopi) yang ditulis dalam format (id varian kopi, nama varian kopi, harga, stok tersisa):" +
                productList +
                " Jika pelanggan meminta untuk menampilkan daftar menu, jangan tampilkan id varian kopinya. Jika hendak tetap menampilkan urutan, bisa menggunakan angka yang dimulai dari 1. ");
            chat.AppendUserInput("Hello!");
            string response = await chat.GetResponseFromChatbotAsync();
            richTextBox1.Text = response;
            textBox1.Enabled = true;
            ChangeProgressBarState(false);
        }

        private void FormChatBot_Load(object sender, EventArgs e)
        {
            products = InitializeProductDatabase();
            transactionPath = InitializeTransactionDatabase();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Kertas Struk", 400, 700);
            InitalizeChatBot();
        }

        private void CheckoutFromChatBot()
        {
            if (selectedProductFromChatBot == null)
            {
                MessageBox.Show("Terdapat kesalahan dalam Checkout. Mohon pesan ulang!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Product selectedProduct = products[int.Parse(selectedProductFromChatBot.SelectedProductID)];
                int qtyProduct = int.Parse(selectedProductFromChatBot.QtyProduct);
                if (transactionPath != null)
                {
                    File.AppendAllText(transactionPath, string.Format("{0}{1}", Environment.NewLine, $"{selectedProduct.Name},{qtyProduct},{selectedProduct.Price * qtyProduct},{DateTime.Now}"));
                    MessageBox.Show("Transaksi berhasil dimasukkan ke data transaksi!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ProcessOrderFromChatBot("../../../data_order.csv");
                ReWriteProductDatabase();
                MessageBox.Show("Checkout berhasil!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);


                pictureBox1.Visible = true;
                printPreviewControl1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                label1.Visible = false;

                printPreviewControl1.Document = printDocument1;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private async void ProcessOrderFromChatBot(string path)
        {
            try
            {
                Product selectedProduct = products[int.Parse(selectedProductFromChatBot!.SelectedProductID)];
                int qtyProduct = int.Parse(selectedProductFromChatBot.QtyProduct);
                string receiptName = selectedProductFromChatBot.ReceiptName;
                string receiptEmail = selectedProductFromChatBot.ReceiptEmail;
                DateTime ordertimestamp = DateTime.Now;
                var guid = Guid.NewGuid();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,

                };
                var records = new List<Order>
                {
                    new Order {Id=guid, Pelanggan = receiptName, Item = selectedProduct.Name, Jumlah = qtyProduct, Email= receiptEmail, Waktu=ordertimestamp },
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
                }
                else
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
                var to = new EmailAddress(selectedProductFromChatBot!.ReceiptEmail, selectedProductFromChatBot.ReceiptName);
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
            }
            catch
            {
                return false;
            }
        }

        private void ReWriteProductDatabase()
        {
            if (productPath != null)
            {
                File.WriteAllText(productPath, "Product,Qty,Price");
                foreach (Product product in products)
                {
                    if (product.Equals(products[int.Parse(selectedProductFromChatBot!.SelectedProductID)]))
                    {
                        product.Stock -= int.Parse(selectedProductFromChatBot!.QtyProduct);
                    }
                    File.AppendAllText(productPath, $"{Environment.NewLine}{product.Name},{product.Stock},{product.Price}");
                }

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Product selectedProduct = products[int.Parse(selectedProductFromChatBot!.SelectedProductID)];
            int qtyProduct = int.Parse(selectedProductFromChatBot.QtyProduct);
            string receiptName = selectedProductFromChatBot.ReceiptName;
            string receiptEmail = selectedProductFromChatBot.ReceiptEmail;

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
            graphics.DrawString("Harga: " + (selectedProduct.Price * qtyProduct).ToString("C"), fontTitle, brush, startX, startY + offset);

            // Tanda terima kasih
            offset += 40;
            graphics.DrawString("Terima kasih atas kunjungan Anda!", fontRegular, brush, startX, startY + offset);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            ChangeProgressBarState();
            chat.AppendUserInput(textBox1.Text);
            string response = await chat.GetResponseFromChatbotAsync();
            richTextBox1.Text = response;
            textBox1.Text = String.Empty;
            ChangeProgressBarState(false);
            if (response.Contains("Terima kasih telah memesan di CoffeeShop!"))
            {
                ChangeProgressBarState();
                textBox1.Enabled = false;
                textBox1.ReadOnly = true;
                button1.Enabled = false;
                button1.Visible = false;
                label1.Text = "Pesanan terkonfirmasi. Harap tunggu!";

                chat.AppendSystemMessage("REKAP DATA. Cukup teks JSON nya saja, tanpa tambahan kalimat lain");
                string originalString = await chat.GetResponseFromChatbotAsync();
                int startIndex = originalString.IndexOf("{") + 1;
                int endIndex = originalString.IndexOf("}");
                string extractedString = originalString.Substring(startIndex, endIndex - startIndex);
                selectedProductFromChatBot = JsonConvert.DeserializeObject<SelectedProduct>("{" + extractedString + "}");
                CheckoutFromChatBot();

                button4.Enabled = true;
                button4.Visible = true;
                ChangeProgressBarState(false);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
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

        private async void button4_Click(object sender, EventArgs e)
        {
            ChangeProgressBarState();
            pictureBox1.Visible = false;
            printPreviewControl1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            label1.Visible = true;
            label1.Text = "Silakan lakukan pemesanan dengan chat di kotak sebelah kiri yang disediakan. Apabila pesanan telah selesai dilakukan, struk pesanan akan muncul.\r\n\r\nTips, jika pemesanan sudah selesai namun struk tidak muncul, ketikkan \"Berikan respon yang sesuai saat pesanan sudah selesai!\"";

            chat.AppendUserInput("Hello!");
            string response = await chat.GetResponseFromChatbotAsync();
            richTextBox1.Text = response;
            textBox1.Enabled = true;
            button1.Enabled = true;
            button1.Visible = true;
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;

            ChangeProgressBarState(false);
        }
    }
}

public class SelectedProduct
{
    public string SelectedProductID
    {
        get;
        set;
    }
    public string QtyProduct
    {
        get;
        set;
    }
    public string ReceiptName
    {
        get;
        set;
    }
    public string ReceiptEmail
    {
        get;
        set;
    }
}