using System;
using Dig;

public partial class dashboard_poll : LoginPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		while (!Updates.HasUpdate(Login.User.Email)) {
			System.Threading.Thread.Sleep(100);
		}

		Response.Clear();
		Response.Write("update");
		Response.End();
	}
}