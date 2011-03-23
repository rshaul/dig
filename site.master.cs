using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site : BaseMaster
{
	protected string PageName;

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		string name = Request.Path;
		name = name.Replace(".aspx", "");
		name = name.TrimStart('/');
		name = name.Replace('/', '_');

		PageName = name;
	}
}