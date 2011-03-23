using System;
using Dig;
using System.Collections.Generic;

public partial class keys : LoginPage
{
	protected List<Key> Keys { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		string v = Request.QueryString["void"];
		if (!string.IsNullOrEmpty(v)) {

		}

		Keys = KeyStore.GetKeysForUser(Login.User);
	}
}