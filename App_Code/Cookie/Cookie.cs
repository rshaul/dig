using System;
using System.Collections.Generic;
using System.Web;
using System.Collections.Specialized;
using System.Collections;

	public abstract class Cookie
	{
		public enum Unit
		{
			Days,
			Months,
			Years
		}

		protected HttpCookie cookie { get; private set; }

		protected Cookie(HttpCookie cookie) {
			this.cookie = cookie;
		}
		
		public string Name {
			get { return cookie.Name; }
		}
		public bool Secure {
			get { return cookie.Secure; }
			set { cookie.Secure = value; }
		}

		public void Clear() {
			cookie.Value = null;
			cookie.Values.Clear();
		}

		public void SetDuration(int value, Unit unit) {
			DateTime expires;
			switch (unit) {
				case Unit.Days:
					expires = DateTime.Now.AddDays(value);
					break;
				case Unit.Months:
					expires = DateTime.Now.AddMonths(value);
					break;
				case Unit.Years:
					expires = DateTime.Now.AddYears(value);
					break;
				default:
					throw new Exception("Unknown unit");
			}
			cookie.Expires = expires;
		}

		public HttpCookie HttpCookie() {
			return cookie;
		}
	}
