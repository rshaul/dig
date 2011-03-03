using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
	public string Email { get; set; }
	public string Password { get; private set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime Birthday { get; set; }

	public void SetPassword(string password) {
		// Password hashing goes here if we want it
		Password = password;
	}

	public static bool TryGetUser(string email, string password, out User user) {
		Db db = new DigDb();
		db.CommandText = @"
			SELECT * FROM users WHERE email = ?email AND password = ?password";
		db.Parameters.Add("email", email);
		db.Parameters.Add("password", password);
		return db.TryGetResult(ConvertResult, out user);
	}

	public void Insert() {
		Db db = new DigDb();
		db.CommandText = @"
			INSERT INTO users (email,password,firstname,lastname,birthday)
			VALUES (?email,?password,?firstname,?lastname,?birthday)";
		db.Parameters.Add("email", Email);
		db.Parameters.Add("password", Password);
		db.Parameters.Add("firstname", FirstName);
		db.Parameters.Add("lastname", LastName);
		db.Parameters.Add("birthday", Birthday);
		db.ExecuteNonQuery();
	}

	static User ConvertResult(DbResult result) {
		User user = new User();
		user.Email = result.Get<string>("email");
		user.Password = result.Get<string>("password");
		user.FirstName = result.Get<string>("firstname");
		user.LastName = result.Get<string>("lastname");
		user.Birthday = result.Get<DateTime>("birthday");
		return user;
	}

	public void Update() {
	}

	public void Delete() {
	}
}