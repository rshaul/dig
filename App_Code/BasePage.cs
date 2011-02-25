using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BasePage : System.Web.UI.Page
{
	protected override void OnPreInit(EventArgs e) {
		base.OnPreInit(e);

		MasterPageFile = "~/site.master";
	}
}