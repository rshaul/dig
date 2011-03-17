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
			SELECT * FROM userinfo WHERE email = ?email AND password = ?password";
		db.Parameters.Add("email", email);
		db.Parameters.Add("password", password);
		return db.TryGetResult(ConvertResult, out user);
	}

	public void Insert() {
		Db db = new DigDb();
		db.CommandText = @"
			INSERT INTO userinfo (email,password,fname,lname,birthdate)
			VALUES (?email,?password,?fname,?lname,?birthdate)";
		db.Parameters.Add("email", Email);
		db.Parameters.Add("password", Password);
		db.Parameters.Add("fname", FirstName);
		db.Parameters.Add("lname", LastName);
		db.Parameters.Add("birthdate", Birthday);
		db.ExecuteNonQuery();
	}

	static User ConvertResult(DbResult result) {
		User user = new User();
		user.Email = result.Get<string>("email");
		user.Password = result.Get<string>("password");
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