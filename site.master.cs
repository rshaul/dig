using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site : System.Web.UI.MasterPage
{
	protected string PageName;

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		PageName = System.IO.Path.GetFileNameWithoutExtension(Request.Path);
	}
}
