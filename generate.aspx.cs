using System;
using Dig;

public partial class generate : LoginPage
{
    protected string DigKey { get; private set; }
	protected string Another { get; private set; }

	string[] Messages = {
		"Another!", "Damn you, more!", "But I want moreeeeee", "More I say!",
		"Again, peasant!"
	};

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		KeyGenerator keygen = new KeyGenerator();
		DigKey = keygen.Generate();

		Another = Rand.om(Messages);
	}
}