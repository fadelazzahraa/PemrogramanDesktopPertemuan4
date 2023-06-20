using CsvHelper;
using CsvHelper.Configuration;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            i += 1;
            var records = new List<Pelanggan>
                {
                    new Pelanggan { Id = i, Nama = textBox1.Text, Alamat = textBox2.Text },
                };
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };

            using (var writer = new StreamWriter("../../../pelanggan.csv", true))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(records);
            }
            MessageBox.Show("Done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (var reader = new StreamReader("../../../pelanggan.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<Pelanggan>().ToList();
                comboBox1.Items.Clear();
                foreach (var rec in record)
                {
                    i += 1;
                    comboBox1.Items.Add(rec.Nama);
                }
                dataGridView1.DataSource = record;
            }

            MessageBox.Show("Done!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime waktu1 = DateTime.Now;
            var guid = Guid.NewGuid();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,

            };
            var records = new List<Order>
            {
                new Order {Id=guid, Pelanggan = comboBox1.Text, Item = comboBox2.Text, Jumlah = Convert.ToInt16(numericUpDown1.Value), Waktu=waktu1 },
            };

            using var writer = new StreamWriter("../../../order.csv", append: true);
            using var csv = new CsvWriter(writer, config);
            csv.WriteRecords(records);

            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(6);
            pictureBox1.Image = qrCodeImage;

            MessageBox.Show("Done!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
