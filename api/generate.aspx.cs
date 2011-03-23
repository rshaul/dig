using System;
using Dig;

public partial class api_generate : ApiPage
{
	public override string GetResponse() {
		string email = Request.QueryString["e"];
		string password = Dig.User.Hash(Request.QueryString["p"]);

		User user;
		if (UserStore.TryGetUser(email, password, out user)) {
			return KeyStore.Generate(user).FormatCode();
		} else {
			return "Error: Invalid username/password";
		}
	}
}