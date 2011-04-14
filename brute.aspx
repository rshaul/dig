<%@ Page Language="C#" CodeFile="brute.aspx.cs" Inherits="brute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
	<h1>Brute Force Us</h1>

	<table id="who">
		<tr>
			<td colspan="2">Who do you want to brute force?</td>
		</tr>
		<tr>
			<td>First Name:</td>
			<td><input type="text" name="fname" id="fname"></td>
		</tr>
		<tr>
			<td>Last Name:</td>
			<td><input type="text" name="lname" id="lname"></td>
		</tr>
		<tr>
			<td></td>
			<td><input type="button" value="Go" id="go" onclick="Go();"></td>
		</tr>
	</table>

	<div id="attempt">
		Brute Force In Progress..<br>
		Attempt #<span id="attempt_number"></span> Key: <span id="attempt_key"></span><br>
		<br>
		Attempts Per Second <span id="attempt_rate"></span><br>
		ETR: <span id="etr"></span> trillion years<br>
		<br>
		<a href="/default.aspx">Give Up</a>
	</div>

	<script type="text/javascript">
	function MakeRandomKey() {
		var key = "";
		var table = [
			'2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R',
			'S', 'T', 'W', 'X', 'Y', 'Z'
		];
		for (var i=0; i < 25; i++) {
			var rnd = Math.floor(Math.random()*table.length);
			key += table[rnd];
			if (i % 5 == 4 && i != 24) key += "-";
		}
		return key;
	}
	var attemptNumber = 0;
	var lastAttemptNumber = 0;
	var fname;
	var lname;
	var total;
	function SetETR(attemptRate) {
		// Assume user has 50 keys in key chain
		var etr = ((total / 51) - attemptNumber) / attemptRate / 60 / 60 / 24 / 365 / 1000000000000;
		$("#etr").text(etr);
	}
	function SetAttemptRate() {
		var attemptRate = attemptNumber - lastAttemptNumber;
		lastAttemptNumber = attemptNumber;
		SetETR(attemptRate);
		$("#attempt_rate").text(attemptRate);
		setTimeout("SetAttemptRate()", 1000);
	}
	function Go() {
		$("#attempt").show();
		fname = $("#fname").val();
		lname = $("#lname").val();
		total = Math.pow(25, 30);
		BruteForce();
		SetAttemptRate();
		$("#who input").attr("disabled", "disabled");
	}
	function BruteForce() {
		var key = MakeRandomKey();
		attemptNumber++;
		$("#attempt_number").text(attemptNumber);
		$("#attempt_key").text(key);
		$.get("/api/check-key.aspx?firstname=" + fname + "&lastname=" + lname + "&key=" + key, CheckResult);
	}
	function CheckResult(result) {
		if (result == "valid") {
			alert("Found one!");
		} else if (result == "invalid") {
			BruteForce();
		} else {
			alert("Error connecting to DIG server");
		}
	}
	</script>
</asp:Content>