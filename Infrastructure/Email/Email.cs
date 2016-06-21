using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Infrastructure.Email
{
    public class Email
    {
        private const string EMAIL_ACCOUNT = "";
        private const string HOST = "smtp.gmail.com";
        private const string PASSWORD = "";
        private const int    PORT = 587;
        

        public static void Send(string to, string subject, string body)
        {
            Send(new List<string>() {to}, subject, body);
        }

        public static void Send(List<string> toList, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient();

            client.Host = HOST;
            client.Port = PORT;
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(EMAIL_ACCOUNT, PASSWORD);

            foreach(string to in toList)
            {
                mail.To.Add(to);
            }

            mail.From = new MailAddress(EMAIL_ACCOUNT);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Send(mail);
        }
    }
}
