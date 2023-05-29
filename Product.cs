using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemrogramanDesktopFadelAzzahra
{
	internal class Product
	{
		private string _name;
		private int _stock;
		private int _price;

        public Product(String name, int stock, int price)
        {
			this._name = name;
			this._stock = stock;
			this._price = price;
        }

        public int Price
		{
			get { return _price; }
			set { _price = value; }
		}


		public int Stock
		{
			get { return _stock; }
			set { _stock = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		

	}
}
