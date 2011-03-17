using System;
using Dig;

public partial class logout : DigPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		LoginStore.Logout();
		Response.Redirect("default.aspx");
	}
}