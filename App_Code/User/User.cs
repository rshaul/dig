using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string HashedPassword { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }

		public static string Hash(string password) {
			// Password hashing goes here if we want it
			return password;
		}

		public void SetPassword(string password) {
			HashedPassword = Hash(password);
		}
	}
}