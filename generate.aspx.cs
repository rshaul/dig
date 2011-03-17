using System;
using Dig;

public partial class generate : LoginPage
{
    protected string Key { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Key = KeyStore.Generate(Login.User).FormatValue();
	}
}