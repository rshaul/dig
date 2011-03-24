<%@ Page Language="C#" CodeFile="generate.aspx.cs" Inherits="generate" %>
<asp:Content ID="Content" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<h1>Your New Key Is...</h1>
	<div id="key">
		<%=Key %>
	</div>

	<div id="back">
		<a href="<%:Urls.KeyChain() %>">Back</a>
	</div>

</asp:Content>