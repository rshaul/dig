using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class Login
	{
		public User User { get; set; }

		public Login(User user) {
			User = user;
		}
	}
}