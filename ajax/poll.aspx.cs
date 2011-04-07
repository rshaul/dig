using System;
using Dig;

public partial class dashboard_poll : LoginPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Update update;

		while (!Updates.TryGetUpdate(Login.User.Email, out update)) {
			System.Threading.Thread.Sleep(100);
		}

		Response.Clear();
		Response.Write(update.Print());
		Response.End();
	}
}