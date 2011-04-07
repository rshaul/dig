using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public abstract class Update
	{
		public string Email { get; set; }
		public string Key { get; set; }
		public abstract string Print();
	}

	public class GenerateUpdate : Update
	{
		public GenerateUpdate(string email, string key) {
			Email = email;
			Key = key;
		}

		public override string Print() {
			return "GENERATE " + Key;
		}
	}

	public class VoidUpdate : Update
	{
		public VoidUpdate(string email, string key) {
			Email = email;
			Key = key;
		}

		public override string Print() {
			return "VOID " + Key;
		}
	}

	public static class Updates
	{
		public static List<Update> updates = new List<Update>();

		public static void AddUpdate(Update update) {
			updates.Add(update);
		}

		public static void Clear(string email) {
			for (int i=0; i < updates.Count; i++) {
				if (updates[i].Email == email) {
					updates.RemoveAt(i);
					i--;
				}
			}
		}

		public static bool TryGetUpdate(string email, out Update update) {
			foreach (Update u in updates) {
				if (u.Email == email) {
					update = u;
					return true;
				}
			}
			update = null;
			return false;
		}
	}
}