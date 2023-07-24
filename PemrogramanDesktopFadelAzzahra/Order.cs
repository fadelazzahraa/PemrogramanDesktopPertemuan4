using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemrogramanDesktopFadelAzzahra
{
    internal class Order
    {
        public Guid Id { get; set; }
        public string Pelanggan { get; set; } = string.Empty;
        public string Item { get; set; } = string.Empty;
        public int Jumlah { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime Waktu { get; set; }
    }
}
