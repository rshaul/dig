using System;
using Dig;

public partial class register : DigPage
{
	protected string Error;
	protected string Email;
	protected string Password;
	protected string Confirm;
	protected string FirstName;
	protected string LastName;

	protected bool HasError {
		get { return !string.IsNullOrEmpty(Error); }
	}

	DateTime GetBirthday() {
		int month = int.Parse(Request.Form["birthday-month"]);
		int day = int.Parse(Request.Form["birthday-day"]);
		int year = int.Parse(Request.Form["birthday-year"]);
		return new DateTime(year, month, day);
	}

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		if (Request.Form.Count > 0) {
			// Registration form has been submitted
			Email = Request.Form["email"];
			Password = Request.Form["password"];
			Confirm = Request.Form["confirm"];
			FirstName = Request.Form["first-name"];
			LastName = Request.Form["last-name"];

			// Error check
			AssertIsEqual(Password, Confirm, "Password does not match");
			AssertExists(LastName, "Last Name is required");
			AssertExists(FirstName, "First Name is required");
			AssertExists(Password, "Password is required");
			AssertExists(Email, "Email is required");

			if (!HasError) {
				// Add to database
				User user = new User();
				user.Email = Email;
				user.SetPassword(Password);
				user.FirstName = FirstName;
				user.LastName = LastName;
				user.Birthday = GetBirthday();

				UserStore.Insert(ref user);

				// Login and redirect
				LoginStore.Login(user);
				Response.Redirect("/dashboard/");
			}
		}
	}

	void AssertIsEqual(string v1, string v2, string error) {
		if (v1 != v2) {
			Error = error;
		}
	}

	void AssertExists(string value, string error) {
		if (string.IsNullOrEmpty(value)) {
			Error = error;
		}
	}
}