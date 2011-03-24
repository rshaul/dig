<%@ Page Language="C#" CodeFile="keys.aspx.cs" Inherits="keys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Key Chain</h1>

	<div class="sub-nav">
		<a href="<%:Urls.KeyChainGenerate(ShowOld) %>" id="generate">Generate A New Key</a>
	</div>

	<div id="valid-keys">
		<table>
			<% foreach (Key key in ValidKeys) { %>
				<tr>
					<td><span class="code"><%:key.FormatCode() %></span></td>
					<td><a href="<%:Urls.Void(key.Code,ShowOld) %>" class="void">Void</a></td>
				</tr>
			<% } %>
		</table>
	</div>

	<% if (InvalidKeys.Count > 0) { %>
		<div id="invalid-keys">
			<% if (ShowOld) { %>
				<a href="<%:Urls.KeyChain(false) %>">- Hide Old Keys</a>
				<% foreach (Key key in InvalidKeys) { %>
					<div class="key">
						<span class="code"><%:key.FormatCode() %></span>
					</div>
				<% } %>
			<% } else { %>
				<a href="<%:Urls.KeyChain(true) %>">+ Show Old Keys</a>
			<% } %>
		</div>
	<% } %>

</asp:Content>