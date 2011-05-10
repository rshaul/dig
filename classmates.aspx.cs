using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class classmates : System.Web.UI.Page
{
	protected bool Sent = false;

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		const string To = "terandle@gmail.com";
		//const string To = "willraus@sbcglobal.net";
		//const string To = "jrodingtonesquire@gmail.com";

		Emailer emailer = new GmailEmailer();

		if (Request.Form.Count > 0) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("New Application");
			sb.AppendLine("---------------");
			sb.AppendLine("Name: " + Request.Form["fname"] + " " + Request.Form["lname"]);
			sb.AppendLine("Email: " + Request.Form["email"]);
			sb.AppendLine("DIG: " + Request.Form["dig"]);
			sb.AppendLine("Class Of: " + Request.Form["year"]);
			emailer.Send("New Classmates Application", sb.ToString(), To);
			Sent = true;
		}
	}
}