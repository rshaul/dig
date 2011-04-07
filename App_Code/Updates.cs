using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public static class Updates
	{
		static List<string> emails = new List<string>();

		public static void AddUpdate(string email) {
			if (!emails.Contains(email)) emails.Add(email);
		}

		public static void Clear(string email) {
			emails.Remove(email);
		}

		public static bool HasUpdate(string email) {
			if (emails.Contains(email)) {
				emails.Remove(email);
				return true;
			}
			return false;
		}
	}
}