using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class LoginPage : DigPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		if (Login == null) {
			Response.Redirect("login.aspx");
		}
	}
}