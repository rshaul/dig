<%@ Page Language="C#" CodeFile="keys.aspx.cs" Inherits="keys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Key Chain</h1>

	<div id="keys">
		<% foreach (Key key in ValidKeys) { %>
			<div class="valid-key">
				<span><%:key.FormatCode() %></span>
				<a href="keys.aspx?void=<%:key.Code %>" class="void">Void</a>
			</div>
		<% } %>

		<% foreach (Key key in InvalidKeys) { %>
			<div class="invalid-key">
				<span><%:key.FormatCode() %></span>
			</div>
		<% } %>

		<a href="keys.aspx?void=all" id="voidAll">Void All</a>
	</div>

</asp:Content>