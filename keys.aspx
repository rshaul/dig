<%@ Page Language="C#" CodeFile="keys.aspx.cs" Inherits="keys" %>
	<% foreach (Key key in Keys) { %>
		<div class="key">
			<% if (key.Valid) { %>
				<span class="valid"><%:key.FormatCode() %></span>
				<a href="keys.aspx?void=<%:key.Value %>" class="void">Void</a>
			<% }  else { %>
				<span class="invalid"><%:key.FormatCode() %></span>
			<% } %>
		</div>
	<% } %>