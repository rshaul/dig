using System;
using Dig;

public class BasePage : System.Web.UI.Page
{
	protected KeyGenerator KeyGenerator { get; private set; }
	protected LoginStore LoginStore { get; private set; }
	protected ICookieStore CookieStore { get; private set; }
	protected UserStore UserStore { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		KeyGenerator = new KeyGenerator();
		UserStore = new UserStore();
		CookieStore = new HttpCookieStore(Request, Response);
		LoginStore = new LoginStore(CookieStore, UserStore);
	}
}