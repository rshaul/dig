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
				INSERT INTO `keys` (code,user) VALUES (?code,?user)";
			db.Parameters.Add("code", code);
			db.Parameters.Add("user", user.Id);
			db.ExecuteNonQuery();
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
				SELECT * FROM `keys` WHERE user = ?user";
			db.Parameters.Add("user", user.Id);
			return db.GetResults(ConvertResult);
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
			int id = result.Get<int>("id");
			User user;
			if (!userStore.TryGetUser(id, out user)) {
				throw new Exception("Unknown user");
			}

			Key key = new Key();
			key.User = user;
			key.Code = result.Get<string>("code");
			//key.Created = result.Get<DateTime>("created");
			key.Valid = result.Get<int>("valid") == 1;
			
			return key;
		}
	}
}