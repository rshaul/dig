<%@ Page Language="C#" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Welcome <%=Login.User.FirstName %> <%=Login.User.LastName %>!</h1>
</asp:Content>