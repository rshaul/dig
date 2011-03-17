using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	class KeyGenerator
	{
		const int KeyLength = 25;

		static char[] KeyTable = {
			'2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
			'S', 'T', 'W', 'X', 'Y', 'Z'
		};

		public static string Generate() {
			string value = "";
			for (int i = 0; i < KeyLength; i++) {
				value += KeyTable.GetRandomElement();
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

		bool Exists(string key) {
			Db db = new DigDb();
			db.CommandText = @"
				SELECT * FROM `keys` WHERE `key` = ?key";
			db.Parameters.Add("key", key);
			Key dummy;
			return db.TryGetResult(ConvertResult, out dummy);
		}

		void Insert(Key key) {
			Db db = new DigDb();
			db.CommandText = @"
				INSERT INTO `keys` (`key`,user) VALUES (?key,?user)";
			db.Parameters.Add("key", key.Value);
			db.Parameters.Add("user", key.User.Id);
			db.ExecuteNonQuery();
		}

		public Key Generate(User user) {
			string value;
			do {
				value = KeyGenerator.Generate();
			} while (Exists(value));

			Key key = new Key();
			key.Value = value;
			key.User = user;

			Insert(key);

			return key;
		}

		Key ConvertResult(DbResult result) {
			int id = result.Get<int>("id");
			User user;
			if (!userStore.TryGetUser(id, out user)) {
				throw new Exception("Unknown user");
			}

			Key key = new Key();
			key.User = user;
			key.Value = result.Get<string>("key");
			key.Created = result.Get<DateTime>("created");
			key.Used = result.Get<int>("used") == 1;
			
			return key;
		}
	}
}