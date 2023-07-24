using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PertemuanDesktopFadelAzzahraNetFramework
{
    public class FadelAzzahraDBConnection
    {
        public MySqlConnection ConnectDBConnection()
        {
            MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;" +
                "uid=root;" +
                "pwd=;" +
                "port=3368;" +
                "database=prodesk_kuis";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                return conn;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
