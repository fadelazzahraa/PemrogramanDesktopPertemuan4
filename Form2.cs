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
    public partial class Form2 : Form
    {
        private string? username;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label1.ForeColor = colorDialog1.Color;
            label1.Text = "Color changed";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // direktori asal
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            // memfilter ekstensi file
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (var file in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            // jika tidak ada tdk dpt disimpan
            // saveFileDialog1.CheckFileExists = true;
            // saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = saveFileDialog1.FileName;
                string content = textBox1.Text;
                File.WriteAllText(saveFileDialog1.FileName, content);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            label2.Font = fontDialog1.Font;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            // memfilter ekstensi file
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(openFileDialog1.FileName); //untuk membaca file
                textBox2.Text = content;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (username != null)
            {
                toolStripStatusLabel1.Text = $"Welcome, {username}!";
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new();
            form1.Show();
        }
    }
}
