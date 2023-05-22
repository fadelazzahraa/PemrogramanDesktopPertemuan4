using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PemrogramanDesktopFadelAzzahra
{
    public class User
    {
        public User(string username, string password, bool isadmin)
        {
			_username = username;
			_password = password;
			_isadmin = isadmin;	
        }

        private string _username;
		private string _password;
		private bool _isadmin;

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public bool Admin
		{
			get { return _isadmin; }
			set { _isadmin = value; }
		}

	}
}
