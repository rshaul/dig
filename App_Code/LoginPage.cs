using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LoginPage : BasePage
{
	protected Login Login { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Login login;
		if (!Login.TryGetLogin(out login)) {
			Response.Redirect("login.aspx");
		}

		Login = login;
	}
}