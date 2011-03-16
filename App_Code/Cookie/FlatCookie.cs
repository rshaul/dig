using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

	public class FlatCookie : Cookie
	{
		public FlatCookie(HttpCookie cookie) : base(cookie) { }

		public FlatCookie(string name, string value) : base(new HttpCookie(name)) {
			cookie.Value = value;
		}

		public string Value {
			get { return cookie.Value; }
			set { cookie.Value = value; }
		}
	}
