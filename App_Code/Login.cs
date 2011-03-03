using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Login
{
	public User User { get; private set; }

	public Login(User user) {
		User = user;
	}

	static KeyedCookie GetCookie() {
		const string name = "login";
		HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
		if (cookie != null) {
			return new KeyedCookie(cookie);
		} else {
			return new KeyedCookie(name);
		}
	}

	public static bool TryGetLogin(out Login login) {
		HttpCookieRepository repo = new HttpCookieRepository(HttpContext.Current);
		User user;
		KeyedCookie cookie;
		if (repo.TryGetKeyed("login", out cookie) && User.TryGetUser(cookie.Values["email"], cookie.Values["password"], out user)) {
			login = new Login(user);
			return true;
		}
		login = null;
		return false;
	}

	public void Save() {
		HttpCookieRepository repo = new HttpCookieRepository(HttpContext.Current);
		KeyedCookie cookie;
		if (!repo.TryGetKeyed("login", out cookie)) {
			cookie = new KeyedCookie("login");
		}
		cookie.Values["email"] = User.Email;
		cookie.Values["password"] = User.Password;
		repo.Save(cookie);
	}

	public void Logout() {
		HttpCookieRepository repo = new HttpCookieRepository(HttpContext.Current);
		KeyedCookie cookie;
		if (repo.TryGetKeyed("login", out cookie)) {
			repo.Delete(cookie);
		}
	}
}