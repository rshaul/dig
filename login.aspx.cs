using System;
using Dig;

public partial class login : DigPage
{
	protected override void OnLoad(EventArgs args) {
		base.OnLoad(args);

		if (Request.Form.Count > 0) {
			string e = Request.Form["e"];
			string p = Dig.User.Hash(Request.Form["p"]);

			User user;
			if (UserStore.TryGetUser(e, p, out user)) {
				LoginStore.Login(user);
				Response.Redirect("dashboard.aspx");
			}
		}
	}
}