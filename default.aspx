<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="_default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<div id="text">
		<h1>Secure Your Identity</h1>

		<div id="blurb">
			with a digital signature using our patented <b>cryptography infinium</b>&trade; technology, so you can rest assured that your identity is safe in the digital sanctuary known as DIG.
		</div>
	</div>

	<div id="movie">
		<iframe title="YouTube video player" width="640" height="510" src="http://www.youtube.com/embed/l6_lUby_-DU?rel=0&showinfo=0" frameborder="0" allowfullscreen></iframe>
	</div>

	<div id="buttons">
		<a href="javascript:ToggleMovie();" id="learn-more" class="button">
			<span id="caption">See How</span>
			<span id="arrow">&gt;</span>
		</a>

		<a href="register.aspx" id="register-now" class="button">
			<span id="caption">Register Now</span>
			<span id="arrow">&gt;</span>
		</a>
	</div>

	<script type="text/javascript">
		document.getElementById("email").focus();

		var movieVisible = false;
		function ToggleMovie() {
			if (movieVisible) {
				$("#text").slideDown(300);
				$("#movie").slideUp(300);
			} else {
				$("#text").slideUp(300);
				$("#movie").slideDown(300);
			}
			movieVisible = !movieVisible;
		}
	</script>

</asp:Content>

