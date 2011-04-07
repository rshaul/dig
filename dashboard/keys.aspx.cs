﻿using System;
using Dig;
using System.Collections.Generic;

public partial class keys : LoginPage
{
	protected bool ShowOld { get; private set; }
	protected List<Key> ValidKeys { get; private set; }
	protected List<Key> InvalidKeys { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Updates.Clear(Login.User.Email);

		ShowOld = Request.QueryString["old"] == "true";

		string generate = Request.QueryString["generate"];
		if (generate == "true") {
			KeyStore.Generate(Login.User);
		}

		string v = Request.QueryString["void"];
		if (v == "all") {
			KeyStore.VoidAll(Login.User);
		} else if (!string.IsNullOrEmpty(v)) {
			Key key;
			if (KeyStore.TryGetKey(v, out key) && key.User.Id == Login.User.Id) {
				KeyStore.Void(key);
			}
		}

		List<Key> keys = KeyStore.GetKeysForUser(Login.User);
		ValidKeys = keys.Where(k => k.Valid);
		InvalidKeys = keys.Where(k => !k.Valid);
	}
}