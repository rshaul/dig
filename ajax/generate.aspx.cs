using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ajax_generate : AjaxPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		if (Login != null) {
			KeyStore.Generate(Login.User);
		}
	}
}