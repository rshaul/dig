using System;
using Dig;

public abstract class ApiPage : BasePage
{
	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);

		Response.Clear();
		Response.Write(GetResponse());
		Response.End();
	}

	public abstract string GetResponse();
}