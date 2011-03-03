using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : BasePage
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
			AssertAreEqual(Password, Confirm, "Password does not match");
			AssertExists(LastName, "Last Name");
			AssertExists(FirstName, "First Name");
			AssertExists(Password, "Password");
			AssertExists(Email, "Email");

			if (!HasError) {
				// Add to database
				User user = new User();
				user.Email = Email;
				user.SetPassword(Password);
				user.FirstName = FirstName;
				user.LastName = LastName;
				user.Birthday = GetBirthday();
				user.Insert();

				// Login and redirect
				Login login = new Login(user);
				login.Save();
				Response.Redirect("dashboard.aspx");
			}
		}
	}

	void AssertAreEqual(string v1, string v2, string error) {
		if (v1 != v2) {
			Error = error;
		}
	}

	void AssertExists(string value, string name) {
		if (string.IsNullOrEmpty(value)) {
			Error = name + " is required";
		}
	}
}