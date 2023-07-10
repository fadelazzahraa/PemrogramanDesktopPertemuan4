using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDotNet
{
    public partial class Form1 : Form
    {
        private readonly movieEntities _movieEntities;

        private int _index = 0;

        public Form1()
        {
            InitializeComponent();
            _movieEntities = new movieEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            var movieRecord = _movieEntities.tblMovie.ToList();
            dataGridView1.DataSource = movieRecord;

            comboBox1.DataSource = movieRecord;
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newRecord = new tblMovie()
            {
                title = textBox1.Text,
                genre = textBox2.Text
            };
            _movieEntities.tblMovie.Add(newRecord);
            _movieEntities.SaveChanges();
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _index = e.RowIndex + 1;
            label1.Text = "Selected index = " + _index.ToString();
            var valueMovie = _movieEntities.tblMovie.FirstOrDefault(q => q.id == _index);
            textBox3.Text = valueMovie.title;
            textBox4.Text = valueMovie.genre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idtoEdit = _index;
            var editRecord = _movieEntities.tblMovie.FirstOrDefault(q => q.id == idtoEdit);

            if (editRecord != null)
            {
                editRecord.title = textBox3.Text;
                editRecord.genre = textBox4.Text;
                _movieEntities.SaveChanges();
                loadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var idtoDelete = _index;
            var deleteRecord = _movieEntities.tblMovie.FirstOrDefault(q => q.id == idtoDelete);
            if (deleteRecord != null)
            {
                _movieEntities.tblMovie.Remove(deleteRecord);
                _movieEntities.SaveChanges();
                loadData();
            }
        }
    }
}
