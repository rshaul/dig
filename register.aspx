<%@ Page Language="C#" CodeFile="register.aspx.cs" Inherits="register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DynamicBody" Runat="Server">
			<h1>Register</h1>

			<form action="" method="post">
				<div id="register">
					<div class="item">
						<label for="email">Email</label>
						<input type="text" name="email" id="email-reg">
					</div>

					<div class="item">
						<label for="password">Password</label>
						<input type="password" name="password" id="password-reg">
					</div>


					<div class="item">
						<label for="first_name">First Name</label>
						<input type="text" name="first_name" id="first_name">
					</div>


					<div class="item">
						<label for="last_name">Last Name</label>
						<input type="text" name="last_name" id="last_name">
					</div>


					<div class="item">
						<label for="birthday">Birthday</label>
						<select name="birthday_month">
							<option value="1">Jan</option>
							<option value="2">Feb</option>
							<option value="3">Mar</option>
							<option value="4">Apr</option>
							<option value="5">May</option>
							<option value="6">Jun</option>
							<option value="7">Jul</option>
							<option value="8">Aug</option>
							<option value="9">Sep</option>
							<option value="10">Oct</option>
							<option value="11">Nov</option>
							<option value="12">Dec</option>
						</select>
						<select name="birthday_day">
							<% for (int i=1; i <= 31; i++) { %>
								<option><%=i %></option>
							<% } %>
						</select>
						<select name="birthday_year">
							<% for (int i=0; i < 100; i++) {  %>
								<option><%=(DateTime.Now.Year - i) %></option>
							<% } %>
						</select>
					</div>
					<div class="item">
						<input type="submit" value="Submit" id="submit">
					</div>
				</div>
			</form>
</asp:Content>

