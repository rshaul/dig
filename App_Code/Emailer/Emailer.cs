using System;
using System.Net.Mail;
using System.Net;

	public abstract class Emailer
	{
		protected abstract void Send(MailMessage message);

		const string AdminAddress = "terandle@gmail.com";

		const string FromAddress = "terandle@terandle.com";
		const string FromName = "Classmates Application";

		public void SendToAdmin(string subject, string message) {
			Send(subject, message, AdminAddress);
		}

		public void Send(string subject, string message, string to) {
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(FromAddress, FromName);
			mail.To.Add(to);
			mail.Subject = subject;
			mail.Body = message;
			Send(mail);
		}
	}
