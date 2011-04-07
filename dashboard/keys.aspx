<%@ Page Language="C#" CodeFile="keys.aspx.cs" Inherits="keys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Key Chain</h1>

	<div class="sub-nav">
		<a href="javascript:Generate();" id="generate">Generate A New Key</a>
	</div>

	<div id="valid-keys">
			<% foreach (Key key in ValidKeys) { %>
				<div class="key" data-key="<%:key.Code %>">
					<span class="code"><%:key.FormatCode() %></span>
					<a href="javascript:Void('<%:key.Code %>');">Void</a>
				</div>
			<% } %>
	</div>

	<h2 id="oldKeys">Old Keys</h2>

	<div id="invalid-keys">
		<% foreach (Key key in InvalidKeys) { %>
			<div class="key" data-key="<%:key.Code %>">
				<span class="code"><%:key.FormatCode() %></span>
			</div>
		<% } %>
	</div>

	<script type="text/javascript">
	function Void(key) {
		$.ajax("/ajax/void.aspx?key=" + key);
		window.location.reload();
	}
	function Generate() {
		$.ajax("/ajax/generate.aspx");
		window.location.reload();
	}
	/*
	while (true) {
		$.get("/ajax/poll.aspx", HandleUpdate);
	}
	*/
	function HandleUpdate(update) {
		var tokens = update.split(' ');
		var action = tokens[0];
		var key = tokens[1];
		if (action == "GENERATE") {
			PrependKey($("#valid-keys"), key, true);
		} else if (action == "VOID") {
			PrependKey($("#invalid-keys"), key, false);
			RemoveKey($("#valid-keys"), key);
		}
	}
	function RemoveKey(from, key) {
		from.find('.key[data-key=' + key + ']').hide();
	}
	function PrependKey(to, key, showVoid) {
		var element = '<div class="key" data-key="' + key + '"><span class="code">' + FormatKey(key) + '</span>';
		if (showVoid) {
			element += '<a href="javascript:Void(\'' + key + '\');">Void</a>';
		}
		element += '</div>';
		to.prepend(element);
	}
	function FormatKey(key) {
		var output = "";
		for (var i=0; i < key.length; i++) {
			output += key[i];
			if (i % 5 == 4 && i != key.length-1) output += "-";
		}
		return output;
	}
	</script>

</asp:Content>