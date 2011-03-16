using System;

public partial class login : BasePage
{
	protected override void OnLoad(EventArgs args) {
		base.OnLoad(args);

		if (Request.Form.Count > 0) {
			string e = Request.Form["e"];
			string p = Request.Form["p"];
			User user;
			if (global::User.TryGetUser(e, p, out user)) {
				Login login = new Login(user);
				login.Save();
				Response.Redirect("dashboard.aspx");
			}
		}
	}
}