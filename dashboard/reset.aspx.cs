using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dashboard_reset : LoginPage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Db db = new DigDb();
		db.CommandText = @"TRUNCATE TABLE `keys`";
		db.ExecuteNonQuery();

		Response.Redirect(Urls.KeyChain());
	}
}