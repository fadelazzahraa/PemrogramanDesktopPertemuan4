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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new();
            pageSetupDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new PointF(10, 10));
            e.Graphics.DrawString(numericUpDown1.Value.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(10, 40));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Document = printDocument1;
        }
    }
}
