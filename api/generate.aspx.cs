using System;
using Dig;

public partial class api_generate : ApiPage
{
	public override string GetResponse() {
		return KeyGenerator.Generate();
	}
}