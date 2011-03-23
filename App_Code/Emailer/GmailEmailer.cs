using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

	public class GmailEmailer : Emailer
	{
		const string User = "terandle@terandle.com";
		const string Pass = "13467985";

		protected override void Send(MailMessage message) {
			SmtpClient smtp = new SmtpClient("smtp.gmail.com");
			smtp.Port = 587;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential(User, Pass);
			smtp.Timeout = 10000;
			smtp.EnableSsl = true;
			smtp.Send(message);
		}
	}
