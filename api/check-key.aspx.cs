using System;
using Dig;

public partial class api_check_key : ApiPage
{
	public override string GetResponse() {
		
		//string login = Request.QueryString["login"];
		//string password = Request.QueryString["password"];

		//User user;
		//if (UserStore.TryGetUser(login, Dig.User.Hash(password), out user)) {
			string firstName = Request.QueryString["firstname"];
			string lastName = Request.QueryString["lastname"];
			string email = Request.QueryString["email"];
			string key = Request.QueryString["key"];

			return KeyStore.Verify(email, firstName, lastName, key) ? "valid" : "invalid";
		//} else {
		//	return "Error: Invalid login or password";
		//}
	}
}