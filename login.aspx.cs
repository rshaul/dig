using System;
using Dig;

public partial class login : DigPage
{
	protected override void OnLoad(EventArgs args) {
		base.OnLoad(args);

		if (Request.Form.Count > 0) {
			string email = Request.Form["e"];
			string password = Dig.User.Hash(Request.Form["p"]);

			User user;
			if (UserStore.TryGetUser(email, password, out user)) {
				LoginStore.Login(user);
				Response.Redirect("dashboard.aspx");
			}
		}
	}
}