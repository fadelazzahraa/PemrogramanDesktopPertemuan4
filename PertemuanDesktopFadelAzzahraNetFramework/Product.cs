using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemrogramanDesktopFadelAzzahraNetFramework
{
	internal class Product
	{
		private string _name;
		private int _stock;
		private int _price;
		private string _category;

        public Product(String name, int stock, int price, String category)
        {
			this._name = name;
			this._stock = stock;
			this._price = price;
			this._category = category;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Category
        {
            get { return _category; }
            set { _category = value; }
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

		

		

	}
}
