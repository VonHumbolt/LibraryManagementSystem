using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Email.MailKit
{
    public class MailKitEmailManager
    {
        public void SendEmail(string senderName, string emailFrom, string recipentName, string emailTo, string subject, string emailMessage, 
            string emailForAuthentication, string emailPassword)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress(senderName, emailFrom);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(recipentName, emailTo);
            message.To.Add(to);

            message.Subject= subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailMessage;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate(emailForAuthentication, emailPassword);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
