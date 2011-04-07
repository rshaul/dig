using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	class CodeGenerator
	{
		const int Length = 25;

		static char[] Table = {
			'2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
			'S', 'T', 'W', 'X', 'Y', 'Z'
		};

		public static string Generate() {
			string value = "";
			for (int i = 0; i < Length; i++) {
				value += Table.GetRandomElement();
			}
			return value;
		}
	}


	public class KeyStore
	{
		UserStore userStore;
		public KeyStore(UserStore userStore) {
			this.userStore = userStore;
		}

		public void VoidAll(User user) {
			Db db = new DigDb();
			db.CommandText = @"
				UPDATE `keys` SET valid = 0 WHERE user = ?user";
			db.Parameters.Add("user", user.Id);
			db.ExecuteNonQuery();
		}

		public void Void(Key key) {
			Db db = new DigDb();
			db.CommandText = @"
				UPDATE `keys` SET valid = 0 WHERE code = ?code";
			db.Parameters.Add("code", key.Code);
			db.ExecuteNonQuery();

			Updates.AddUpdate(key.User.Email);
		}

		bool Exists(string code) {
			Db db = new DigDb();
			db.CommandText = @"
				SELECT * FROM `keys` WHERE code = ?code";
			db.Parameters.Add("code", code);
			return db.HasResults();
		}

		void Insert(string code, User user) {
			Db db = new DigDb();
			db.CommandText = @"
				INSERT INTO `keys` (code,user,valid) VALUES (?code,?user,1)";
			db.Parameters.Add("code", code);
			db.Parameters.Add("user", user.Id);
			db.ExecuteNonQuery();

			Updates.AddUpdate(user.Email);
		}

		public bool TryGetKey(string code, out Key key) {
			Db db = new DigDb();
			db.CommandText = @"
				SELECT * FROM `keys` WHERE code = ?code";
			db.Parameters.Add("code", code);
			return db.TryGetResult(ConvertResult, out key);
		}

		public List<Key> GetKeysForUser(User user) {
			Db db = new DigDb();
			db.CommandText = @"
				SELECT * FROM `keys`
				WHERE user = ?user
				ORDER BY created DESC";
			db.Parameters.Add("user", user.Id);
			return db.GetResults(ConvertResult);
		}

		public bool Verify(string email, string firstname, string lastname, string code) {
			if (code == null) return false;
			code = code.Replace("-", "");

			if (string.IsNullOrEmpty(email)) {
				if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname)) return false;
			}
			if (string.IsNullOrEmpty(firstname) != string.IsNullOrEmpty(lastname)) return false;

			Db db = new DigDb();
			db.CommandText = @"
				UPDATE `keys` k
				INNER JOIN users u ON k.user = u.id
				SET k.valid = 0 WHERE k.code = ?code AND k.valid = 1 ";
			db.Parameters.Add("code", code);

			if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname)) {
				db.CommandText += " AND u.fname = ?fname AND u.lname = ?lname ";
				db.Parameters.Add("fname", firstname);
				db.Parameters.Add("lname", lastname);
			}
			if (!string.IsNullOrEmpty(email)) {
				db.CommandText += " AND u.email = ?email ";
				db.Parameters.Add("email", email);
			}

			bool verified = db.ExecuteNonQuery() > 0;

			if (verified) Updates.AddUpdate(email);

			return verified;
		}

		public Key Generate(User user) {
			string code;
			do {
				code = CodeGenerator.Generate();
			} while (Exists(code));

			Insert(code, user);

			Key key;
			if (TryGetKey(code, out key)) {
				return key;
			} else {
				throw new Exception("Error selecting generated code");
			}
		}

		Key ConvertResult(DbResult result) {
			int id = result.Get<int>("user");
			User user;
			if (!userStore.TryGetUser(id, out user)) {
				throw new Exception("Unknown user");
			}

			Key key = new Key();
			key.User = user;
			key.Code = result.Get<string>("code");
			key.Created = result.Get<DateTime>("created");
			key.Valid = result.Get<int>("valid") == 1;
			
			return key;
		}
	}
}