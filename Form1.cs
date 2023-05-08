using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;

namespace PemrogramanDesktopPertemuan4
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

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show($"Harga kopi Anda Rp{calculateCoffeePrice().ToString()}. Apakah Anda ingin melanjutkan pemesanan?", "Checkout", buttons);
            if (result == DialogResult.Yes)
            {

                MessageBox.Show("Terima kasih telah memesan!", "Terima kasih!");
            }
            else
            {
                MessageBox.Show("Anda membatalkan pesanan", "Yaahh...");
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPriceOnLabel();
        }
    }
}