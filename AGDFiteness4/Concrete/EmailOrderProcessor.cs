
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AGDFiteness4.Abstract;
using AGDFiteness4.Models;


namespace AGDFiteness4.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "sportsSite@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Passowrd = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"C:\TempShopping\writeEmail";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippinginfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.FileLocation,
                emailSettings.Passowrd);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.ProductPrice * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity,
                        line.Product.ProductName,
                        subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                      .AppendLine("Ship to:")
                        .AppendLine("shippingInfo.Name")
                          .AppendLine("shippingInfo.Line1")
                            .AppendLine("shippingInfo.Line2 ??")
                              .AppendLine("shippingInfo.Line3 ??")
                                .AppendLine("shippingInfo.City")
                                  .AppendLine("shippingInfo.State")
                                    .AppendLine("shippingInfo.Country")
                                      .AppendLine("shippingInfo.Zip")
                                       .AppendLine("---")
                                        .AppendFormat("Gift wrap: {0}", shippinginfo.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "New order submitted!",
                    body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);

            }
        }

    }

}