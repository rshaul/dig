using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

	public class HttpCookieStore : ICookieStore
	{
		HttpRequest Request;
		HttpResponse Response;

		public HttpCookieStore(HttpRequest request, HttpResponse response) {
			Request = request;
			Response = response;
		}

		public bool TryGetKeyed(string name, out KeyedCookie output) {
			HttpCookie cookie;
			if (TryGetCookie(name, out cookie)) {
				output = new KeyedCookie(cookie);
				return true;
			}
			output = null;
			return false;
		}

		public bool TryGetFlat(string name, out FlatCookie output) {
			HttpCookie cookie;
			if (TryGetCookie(name, out cookie)) {
				output = new FlatCookie(cookie);
				return true;
			}
			output = null;
			return false;
		}

		bool TryGetCookie(string name, out HttpCookie output) {
			foreach (string c in Request.Cookies) {
				if (c == name) {
					output = Request.Cookies[name];
					return true;
				}
			}
			output = null;
			return false;
		}

		public void Save(Cookie cookie) {
			if (Response.Cookies.AllKeys.Contains(cookie.Name)) {
				// Class was not designed to handle multiple Saves()
				// Need it? _You_ implement it!
				throw new Exception("Cookie has already been saved this session.");
			}
			Response.Cookies.Add(cookie.HttpCookie());
		}

		public void Delete(Cookie cookie) {
			cookie.Clear();
			cookie.SetDuration(-30, Cookie.Unit.Years);
			Save(cookie);
		}
	}
