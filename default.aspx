<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="_default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">

	<div id="text">
		<h1>Secure Your Identity</h1>

		<div id="blurb">
			With the advent of the internet, identity theft has a new face, so to speak. Before the internet, you had to have a convincing alias, a good poker face, and an even more convincing photo ID. However, in the digital age, all you need to steal an identity are a couple pieces of hard-to-verify information, like Name and E-mail Address. DIG attempts to combat this new age of identity theft with a meaningful yet simple form of verifiable identification: the DIG code.
		</div>
	</div>

	<div id="movie">
		<iframe title="YouTube video player" width="640" height="510" src="http://www.youtube.com/embed/WzBcR45a-Zc?rel=0&showinfo=0" frameborder="0" allowfullscreen></iframe>
	</div>

	<div id="buttons">
		<a href="javascript:ToggleMovie();" id="learn-more" class="button">
			<span id="caption">See How</span>
			<span id="arrow">+</span>
		</a>

		<a href="register.aspx" id="register-now" class="button">
			<span id="caption">Register Now</span>
			<span id="arrow">&gt;</span>
		</a>
	</div>

	<div id="not-convinced">
		<a href="brute.aspx" id="not-conviced" class="button">
			<span id="caption">Not Conviced?</span>
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
				$("#not-convinced").hide();
			} else {
				$("#text").slideUp(300);
				$("#movie").slideDown(300);
				$("#not-convinced").show();
			}
			movieVisible = !movieVisible;
		}
	</script>

</asp:Content>

