using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

	public interface ICookieStore
	{
		bool TryGetKeyed(string name, out KeyedCookie output);
		bool TryGetFlat(string name, out FlatCookie output);
		
		void Save(Cookie cookie);
		void Delete(Cookie cookie);
	}
