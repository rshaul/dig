using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class KeyRepository
	{
		string CleanKey(string key) {
			return key.Replace("-", "");
		}

		public void SaveKey(string key, User user) {
			Db db = new DigDb();
			db.CommandText = @"
				INSERT INTO keys (key,user) VALUES (?key,?user)";
			db.Parameters.Add("key", key);
			db.Parameters.Add("user", user.Id);
		}
	}
}