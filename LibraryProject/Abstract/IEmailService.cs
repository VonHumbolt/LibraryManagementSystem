using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmailService
    {
        void SendMail(string senderName, string emailFrom, string recipentName, string emailTo, string subject, string emailMessage,
            string emailForAuthentication, string emailPassword);
    }
}
