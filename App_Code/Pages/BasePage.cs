using System;
using Dig;

/*
 * All Pages Inherit From This
 * 
 * Responsible for dependencies
 */
public class BasePage : System.Web.UI.Page
{
	protected KeyStore KeyStore { get; private set; }
	protected LoginStore LoginStore { get; private set; }
	protected ICookieStore CookieStore { get; private set; }
	protected UserStore UserStore { get; private set; }

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		UserStore = new UserStore();
		KeyStore = new KeyStore(UserStore);
		CookieStore = new HttpCookieStore(Request, Response);
		LoginStore = new LoginStore(CookieStore, UserStore);
	}
}