using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dig;

public class AjaxPage : BasePage
{
	protected Login Login { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Login login;
		if (LoginStore.TryGetLogin(out login)) {
			Login = login;
		} else {
			Response.Clear();
			Response.End();
		}
	}
}