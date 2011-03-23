using System;
using Dig;

public partial class api_check_login : ApiPage
{
	public override string GetResponse() {
		string login = Request.QueryString["login"];
		string password = Dig.User.Hash(Request.QueryString["password"]);
		User user;
		if (UserStore.TryGetUser(login, password, out user)) {
			return "valid";
		}
		return "invalid";
	}
}