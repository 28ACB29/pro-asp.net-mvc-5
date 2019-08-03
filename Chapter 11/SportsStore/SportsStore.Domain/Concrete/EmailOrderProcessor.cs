﻿using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SportsStore.Domain.Concrete
{

	public class EmailSettings
	{
		public string MailToAddress = "orders@example.com";
		public string MailFromAddress = "sportsstore@example.com";
		public bool UseSsl = true;
		public string Username = "MySmtpUsername";
		public string Password = "MySmtpPassword";
		public string ServerName = "smtp.example.com";
		public int ServerPort = 587;
		public bool WriteAsFile = true;
		public string FileLocation = @"c:\sports_store_emails";
	}

	public class EmailOrderProcessor : IOrderProcessor
	{
		private EmailSettings emailSettings;

		public EmailOrderProcessor(EmailSettings settings)
		{
			this.emailSettings = settings;
		}

		public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
		{

			using(SmtpClient smtpClient = new SmtpClient())
			{

				smtpClient.EnableSsl = this.emailSettings.UseSsl;
				smtpClient.Host = this.emailSettings.ServerName;
				smtpClient.Port = this.emailSettings.ServerPort;
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(this.emailSettings.Username, this.emailSettings.Password);

				if(this.emailSettings.WriteAsFile)
				{
					smtpClient.DeliveryMethod
						= SmtpDeliveryMethod.SpecifiedPickupDirectory;
					smtpClient.PickupDirectoryLocation = this.emailSettings.FileLocation;
					smtpClient.EnableSsl = false;
				}

				StringBuilder body = new StringBuilder()
					.AppendLine("A new order has been submitted")
					.AppendLine("---")
					.AppendLine("Items:");

				foreach(CartLine line in cart.Lines)
				{
					decimal subtotal = line.Product.Price * line.Quantity;
					body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
				}

				body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
					.AppendLine("---")
					.AppendLine("Ship to:")
					.AppendLine(shippingInfo.Name)
					.AppendLine(shippingInfo.Line1)
					.AppendLine(shippingInfo.Line2 ?? "")
					.AppendLine(shippingInfo.Line3 ?? "")
					.AppendLine(shippingInfo.City)
					.AppendLine(shippingInfo.State ?? "")
					.AppendLine(shippingInfo.Country)
					.AppendLine(shippingInfo.Zip)
					.AppendLine("---")
					.AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

				MailMessage mailMessage = new MailMessage(
									   this.emailSettings.MailFromAddress,   // From
									   this.emailSettings.MailToAddress,     // To
									   "New order submitted!",          // Subject
									   body.ToString());                // Body

				if(this.emailSettings.WriteAsFile)
				{
					mailMessage.BodyEncoding = Encoding.ASCII;
				}

				smtpClient.Send(mailMessage);
			}
		}
	}
}
