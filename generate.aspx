<%@ Page Language="C#" CodeFile="generate.aspx.cs" Inherits="generate" %>
<asp:Content ID="Content2" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<h1>Your New Key Is...</h1>
	<div id="key">
		<%=DigKey %>
	</div>

	<div id="another">
		<a href="generate.aspx"><%=Another %></a>
	</div>

</asp:Content>

