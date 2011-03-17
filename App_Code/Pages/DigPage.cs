using System;
using Dig;

public class DigPage : BasePage
{
	protected Login Login { get; private set; }

	protected override void OnPreInit(EventArgs e) {
		base.OnPreInit(e);

		MasterPageFile = "~/site.master";
	}

	BaseMaster BaseMaster { get { return (BaseMaster)Master; } }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Login login;
		if (LoginStore.TryGetLogin(out login)) {
			Login = login;
			BaseMaster.Login = Login;
		}
	}
}