using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class generate : BasePage
{
    protected string Username { get; private set; }
	protected string Code { get; private set; }

	const int Width=20;

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		string username = Request["username"];
		string code = Request["code"];

		if (!string.IsNullOrEmpty(username)) {
			Code = Encryptor.Encrypt(username);
		} else if (!string.IsNullOrEmpty(code)) {
			Username = Encryptor.Decrypt(code);
		}
	}
}