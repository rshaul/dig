using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class UserStore
	{
		public bool TryGetUser(string email, string hashedPassword, out User user) {
			Db db = new DigDb();
			db.CommandText = @"
				SELECT * FROM users WHERE email = ?email AND password = ?password";
			db.Parameters.Add("email", email);
			db.Parameters.Add("password", hashedPassword);
			return db.TryGetResult(ConvertResult, out user);
		}

		public void Insert(ref User user) {
			Db db = new DigDb();
			db.CommandText = @"
				INSERT INTO users (email,password,fname,lname,birthdate)
				VALUES (?email,?password,?fname,?lname,?birthdate)";
			db.Parameters.Add("email", user.Email);
			db.Parameters.Add("password", user.HashedPassword);
			db.Parameters.Add("fname", user.FirstName);
			db.Parameters.Add("lname", user.LastName);
			db.Parameters.Add("birthdate", user.Birthday);
			db.ExecuteNonQuery();

			// Reload user to get generated ID#
			if (!TryGetUser(user.Email, user.HashedPassword, out user)) {
				throw new Exception("Error saving user, does not exist!");
			}
		}

		static User ConvertResult(DbResult result) {
			User user = new User();
			user.Email = result.Get<string>("email");
			user.HashedPassword = result.Get<string>("password");
			user.FirstName = result.Get<string>("fname");
			user.LastName = result.Get<string>("lname");
			user.Birthday = result.Get<DateTime>("birthdate");
			return user;
		}

		public void Update() {
		}

		public void Delete() {
		}
	}
}