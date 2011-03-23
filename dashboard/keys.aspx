<%@ Page Language="C#" CodeFile="keys.aspx.cs" Inherits="keys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Key Chain</h1>

	<div id="keys">
		<% foreach (Key key in Keys) { %>
			<div class="key">
				<% if (key.Valid) { %>
					<span class="valid"><%:key.FormatCode() %></span>
					<a href="keys.aspx?void=<%:key.Code %>" class="void">Void</a>
				<% }  else { %>
					<span class="invalid"><%:key.FormatCode() %></span>
				<% } %>
			</div>
		<% } %>

		<a href="keys.aspx?void=all" id="voidAll">Void All</a>
	</div>

</asp:Content>