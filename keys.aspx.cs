using System;
using Dig;
using System.Collections.Generic;

public partial class keys : LoginPage
{
	protected List<Key> Keys { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		string v = Request.QueryString["void"];
		if (v == "all") {
			KeyStore.VoidAll(Login.User);
		} else if (!string.IsNullOrEmpty(v)) {
			Key key;
			if (KeyStore.TryGetKey(v, out key) && key.User.Id == Login.User.Id) {
				KeyStore.Void(key);
			}
		}

		Keys = KeyStore.GetKeysForUser(Login.User);
	}
}