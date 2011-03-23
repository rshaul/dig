using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dig
{
	public class LoginStore
	{
		ICookieStore cookieRepo;
		UserStore userRepo;
	
		public LoginStore(ICookieStore cookieRepo, UserStore userRepo) {
			this.cookieRepo = cookieRepo;
			this.userRepo = userRepo;
		}

		bool TryGetCookie(out KeyedCookie cookie) {
			return cookieRepo.TryGetKeyed("login", out cookie);
		}

		/*
		 * Checks the user's cookies to see if they have login information & verifies them
		 */
		public bool TryGetLogin(out Login login) {
			User user;
			KeyedCookie cookie;
			if (TryGetCookie(out cookie) && userRepo.TryGetUser(cookie.Values["email"], cookie.Values["password"], out user)) {
				login = new Login(user);
				return true;
			}
			login = null;
			return false;
		}

		/*
		 * Creates & saves the login cookie
		 */
		public void Login(User user) {
			KeyedCookie cookie;
			if (!TryGetCookie(out cookie)) {
				cookie = new KeyedCookie("login");
			}
			cookie.Values["email"] = user.Email;
			cookie.Values["password"] = user.HashedPassword;
			cookieRepo.Save(cookie);
		}

		/*
		 * Deletes the login cookie
		 */
		public void Logout() {
			KeyedCookie cookie;
			if (TryGetCookie(out cookie)) {
				cookieRepo.Delete(cookie);
			}
		}
	}
}