using System;
using Dig;

public partial class api_generate : ApiPage
{
	public override string GetResponse() {
		string email = Request.QueryString["email"];
		string password = Dig.User.Hash(Request.QueryString["password"]);

		User user;
		if (UserStore.TryGetUser(email, password, out user)) {
			return KeyStore.Generate(user).FormatValue();
		} else {
			return "Error: Invalid login";
		}
	}
}