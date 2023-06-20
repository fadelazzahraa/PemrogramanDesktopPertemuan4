using CsvHelper;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PemrogramanDesktopFadelAzzahra
{
    public partial class FormRiwayatTransaksi : Form
    {
        public FormRiwayatTransaksi()
        {
            InitializeComponent();
        }

        private void FormRiwayatTransaksi_Load(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("../../../order.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<Order>().ToList();
                dataGridView1.DataSource = record;
            }
        }


    }
}
