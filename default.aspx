<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="_default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<h1>Secure Your Identity</h1>

	<div id="blurb">
		with a digital signature using our patented <b>cryptography infinium</b>&trade; technology, so you can rest assured that your identity is safe in the digital sanctuary known as DIG.
	</div>

	<a href="learn.aspx" id="learn-more" class="button">
		<span id="caption">Learn More</span>
		<span id="arrow">&gt;</span>
	</a>

	<a href="register.aspx" id="register-now" class="button">
		<span id="caption">Register Now</span>
		<span id="arrow">&gt;</span>
	</a>

	<script type="text/javascript">
		document.getElementById("email").focus();
	</script>

</asp:Content>

