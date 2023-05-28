using Microsoft.VisualBasic.Devices;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int coffeeTypeOption = 0; // by index
        public int coffeeSize = 0; // 0 for medium, 1 for large
        public int coffeeSugar = 0;
        public int coffeeIce = 0;
        public bool[] coffeeAddOnOption = new bool[6];

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            coffeeTypeOption = comboBox1.SelectedIndex;
            refreshPriceOnLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            coffeeAddOnOption[0] = false;
            coffeeAddOnOption[1] = false;
            coffeeAddOnOption[2] = false;
            coffeeAddOnOption[3] = false;
            coffeeAddOnOption[4] = false;
            coffeeAddOnOption[5] = false;
            refreshPriceOnLabel();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Kertas Struk", 400, 700);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                coffeeSize = 0;
            }
            else if (radioButton2.Checked == true)
            {
                coffeeSize = 1;
            }
            refreshPriceOnLabel();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            coffeeSugar = (int)numericUpDown1.Value;
            refreshPriceOnLabel();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            coffeeIce = (int)numericUpDown2.Value;
            refreshPriceOnLabel();
        }

        private int calculateCoffeePrice()
        {
            int price = 0;

            if (coffeeTypeOption == 0)
            {
                price += 10000;
            }
            else if (coffeeTypeOption == 1)
            {
                price += 15000;
            }
            else if (coffeeTypeOption == 2)
            {
                price += 12000;
            }

            if (coffeeSize == 1)
            {
                price += 2000;
            }

            if (checkedListBox1.GetItemCheckState(0).ToString() == "Checked")
            {
                price += 3000;
            }
            if (checkedListBox1.GetItemCheckState(1).ToString() == "Checked")
            {
                price += 3500;
            }
            if (checkedListBox1.GetItemCheckState(2).ToString() == "Checked")
            {
                price += 2500;
            }
            if (checkedListBox1.GetItemCheckState(3).ToString() == "Checked")
            {
                price += 1000;
            }
            if (checkedListBox1.GetItemCheckState(4).ToString() == "Checked")
            {
                price += 1500;
            }
            if (checkedListBox1.GetItemCheckState(5).ToString() == "Checked")
            {
                price += 2000;
            }

            return price;
        }

        private void refreshPriceOnLabel()
        {
            label7.Text = $"Rp{calculateCoffeePrice()},00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Kode Lama*/

            /*MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show($"Harga kopi Anda Rp{calculateCoffeePrice().ToString()}. Apakah Anda ingin melanjutkan pemesanan?", "Checkout", buttons);
            if (result == DialogResult.Yes)
            {

                MessageBox.Show("Terima kasih telah memesan!", "Terima kasih!");
            }
            else
            {
                MessageBox.Show("Anda membatalkan pesanan", "Yaahh...");
            }*/

            printPreviewControl1.Document = printDocument1;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPriceOnLabel();
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

            string coffeeTypeOptionToString;
            switch (coffeeTypeOption)
            {
                case 0:
                    coffeeTypeOptionToString = "Espresso";
                    break;
                case 1:
                    coffeeTypeOptionToString = "Latte";
                    break;
                case 2:
                    coffeeTypeOptionToString = "Cappuccino";
                    break;
                default:
                    coffeeTypeOptionToString = "Tipe Kopi";
                    break;
            }
            string coffeeSizeToString;
            switch (coffeeSize)
            {
                case 0:
                    coffeeSizeToString = "Medium";
                    break;
                case 1:
                    coffeeSizeToString = "Large";
                    break;

                default:
                    coffeeSizeToString = "Ukuran Kopi";
                    break;
            }

            // Judul struk
            graphics.DrawString("Fadel Azzahra Coffee Shop", fontTitle, brush, startX, startY);
            graphics.DrawString("------------------------------------", fontRegular, brush, startX, startY + offset);

            // Detail pesanan
            offset += 20;
            graphics.DrawString("Jenis Kopi  : " + coffeeTypeOptionToString, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Ukuran Kopi : " + coffeeSizeToString, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Level Gula  : " + coffeeSugar, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Level Es    : " + coffeeIce, fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("Topping     : ", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(0).ToString() == "Checked" ? "✅ " : "❌ ") + "Bubble", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(1).ToString() == "Checked" ? "✅ " : "❌ ") + "Grass Jelly", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(2).ToString() == "Checked" ? "✅ " : "❌ ") + "Nata de coco", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(3).ToString() == "Checked" ? "✅ " : "❌ ") + "Whipped cream", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(4).ToString() == "Checked" ? "✅ " : "❌ ") + "Choco chip", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString((checkedListBox1.GetItemCheckState(5).ToString() == "Checked" ? "✅ " : "❌ ") + "Oreo", fontRegular, brush, startX, startY + offset);
            offset += 20;
            graphics.DrawString("------------------------------------", fontRegular, brush, startX, startY + offset);

            // Total harga
            offset += 20;
            graphics.DrawString("Harga : " + calculateCoffeePrice().ToString("C"), fontTitle, brush, startX, startY + offset);

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