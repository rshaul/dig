<%@ Page Language="C#" CodeFile="generate.aspx.cs" Inherits="generate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<form method="post" action="">
		<table>
			<tr>
				<td>Username:</td>
				<td><input type="text" name="username"  value="<%=Username %>" size="50" /></td>
			</tr>
			<tr>
				<td>Code:</td>
				<td><input type="text" name="code" value="<%=Code %>" size="50" /></td>
			</tr>
		</table>
		<input type="submit" value="Convert" />
	</form>

</asp:Content>

