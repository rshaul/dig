using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_generate : System.Web.UI.Page
{

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		KeyGenerator keygen = new KeyGenerator();

		Response.Clear();
		Response.Write(keygen.Generate());
		Response.End();
	}
}