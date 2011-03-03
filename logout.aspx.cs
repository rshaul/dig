using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : LoginPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Login.Logout();
		Response.Redirect("default.aspx");
	}
}