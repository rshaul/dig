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
	public static string KeyChain(bool showOld) {
		string old = showOld ? "true" : "false";
		return KeyChain() + "?old=" + old;
	}
	public static string KeyChainGenerate(bool showOld) {
		return KeyChain(showOld) + "&generate=true";
	}
	public static string Void(string code, bool showOld) {
		return KeyChain(showOld) + "&void=" + code;
	}

	public static string Generate() {
		return "/dashboard/generate.aspx";
	}


	public static string AfterLogin() {
		return KeyChain();
	}
}