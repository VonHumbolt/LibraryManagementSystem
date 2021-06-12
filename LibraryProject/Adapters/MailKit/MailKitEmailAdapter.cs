using Business.Abstract;
using Core.Utilities.Email.MailKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapters.MailKit
{
    public class MailKitEmailAdapter : IEmailService
    {

        public void SendMail(string senderName, string emailFrom, string recipentName, string emailTo, string subject, string emailMessage,
            string emailForAuthentication, string emailPassword)
        {
            MailKitEmailManager emailManager = new MailKitEmailManager();

            emailManager.SendEmail(senderName, emailFrom, recipentName, emailTo, subject, emailMessage, emailForAuthentication, emailPassword);

        }
    }
}
