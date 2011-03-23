<!DOCTYPE html>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classmates.aspx.cs" Inherits="classmates" %>
<html lang="en">
<head>
	<meta charset="utf-8">
    <title>Classmates Register</title>
	<link rel="Stylesheet" href="content/classmates.css" type="text/css" />
</head>
<body>
	<div id="header">
		<img src="content/classmates.png" />
	</div>
	<div id="body">
		<% if (Sent) { %>
			<h1>Thanks for registering!</h1>
		<% } else { %>
			<h1>Register New Account</h1>
			<form action="" method="post">
				<table>
					<tr>
						<td>First Name</td>
						<td><input type="text" name="fname" value="Bill" /></td>
					</tr>
					<tr>
						<td>Last Name</td>
						<td><input type="text" name="lname" value="Murray" /></td>
					</tr>
					<tr>
						<td>Email</td>
						<td><input type="text" name="email" value="billmurray@awesome.com" /></td>
					</tr>
					<tr>
						<td><img src="content/diglock.png" /></td>
						<td>
							<input type="text" name="dig" />
							<a href="/" id="learnmore">What's this?</a>
						</td>
					</tr>
					<tr>
						<td>Class Of</td>
						<td>
							<select name="year">
								<% for (int i=0; i < 100; i++) {  %>
									<option><%=(DateTime.Now.Year - i) %></option>
								<% } %>
							</select>
						</td>
					</tr>
					<tr>
						<td colspan="2">Blah blah blah</td>
					</tr>
					<tr>
						<td colspan="2">Etc etc etc</td>
					</tr>
					<tr>
						<td colspan="2">
							<input type="submit" value="Submit" />
						</td>
					</tr>
				</table>
			</form>
		</div>
	<% } %>
</body>
</html>
