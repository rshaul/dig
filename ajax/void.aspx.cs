using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dig;

public partial class ajax_void : AjaxPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		string code = Request.QueryString["key"];
		if (!string.IsNullOrEmpty(code) && Login != null) {
			Key key;
			if (KeyStore.TryGetKey(code, Login.User.Email, out key)) {
				KeyStore.Void(key);
			}
		}
	}
}