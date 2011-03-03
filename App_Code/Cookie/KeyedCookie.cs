using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

	public class KeyedCookie : Cookie
	{
		public KeyedCookie(string name)
			: base(new HttpCookie(name)) {
		}
		public KeyedCookie(HttpCookie cookie)
			: base(cookie) {
		}

		public NameValueCollection Values {
			get { return cookie.Values; }
			set { SetValues(value); }
		}

		void SetValues(NameValueCollection c) {
			cookie.Values.Clear();
			foreach (string key in c) {
				cookie.Values.Add(key, c[key]);
			}
		}
	}
