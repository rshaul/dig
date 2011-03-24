using System;
using Dig;

public partial class api_generate : ApiPage
{
	public override string GetResponse() {
		string login = Request.QueryString["login"];
		string password = Dig.User.Hash(Request.QueryString["password"]);

		User user;
		if (UserStore.TryGetUser(login, password, out user)) {
			return KeyStore.Generate(user).FormatCode();
		} else {
			return "Error: Invalid login or password";
		}
	}
}