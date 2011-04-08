using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Urls
{
	public static string Dashboard() {
		return "/dashboard/";
	}

	public static string KeyChain() {
		return "/dashboard/keys.aspx";
	}


	public static string AfterLogin() {
		return KeyChain();
	}
}