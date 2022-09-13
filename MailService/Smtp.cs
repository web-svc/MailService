using MailService.Interface;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailService
{
    public class Smtp: ISmtp
    {
        /// <summary>
        /// this function can be used to send an email and it returns boolean. true = mail sent successfully, else exception will be raised and response will be false.
        /// </summary>
        /// <param name="FromAddress">From mail address</param>
        /// <param name="Password">Password should be in encrypted format</param>
        /// <param name="ToAddress">to email addresses, many email addresses can be passed using saperator ';'.</param>
        /// <param name="DisplayName">display name for from email address</param>
        /// <param name="Subject">subject of the email</param>
        /// <param name="Body">body of the email</param>
        /// <param name="CcAddress">cc email addresses, many email addresses can be passed using saperator ';'.</param>
        /// <param name="BccAddress">bcc email addresses, many email addresses can be passed using saperator ';'.</param>
        /// <param name="EmailPriority">priorty of the email</param>
        /// <returns>boolean: true or false</returns>
        public static bool Send(string FromAddress, string Password, string ToAddress, string DisplayName, string Subject, string Body, string SmtpHostName, int PortNumber, string CcAddress = null, string BccAddress = null, MailPriority EmailPriority = MailPriority.Normal)
        {
            var MailMessage = new MailMessage();
            var ToList = ToAddress.Split(';');
            foreach (var email in ToList)
            {
                MailMessage.To.Add(email);
            }
            if (CcAddress != null)
            {
                var cc = CcAddress.Split(';');
                for (var length = 0; length <= ToList.Length - 1; length++)
                {
                    MailMessage.CC.Add(cc[length]);
                }
            }
            if (BccAddress != null)
            {
                var bcc = BccAddress.Split(';');
                for (var length = 0; length <= ToList.Length - 1; length++)
                {
                    MailMessage.CC.Add(bcc[length]);
                }
            }
            MailMessage.From = new MailAddress(FromAddress, DisplayName, System.Text.Encoding.UTF8);
            MailMessage.Subject = Subject;
            MailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            MailMessage.Body = Body;
            MailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            MailMessage.IsBodyHtml = true;
            MailMessage.Priority = EmailPriority;
            var oSmtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(FromAddress, Password),
                Port = PortNumber,
                Host = SmtpHostName
            };
            oSmtpClient.Send(MailMessage);
            return true;
        }

        /// <summary>
        /// this function can be used to send an email and it returns boolean. true = mail sent successfully, else exception will be raised and response will be false.
        /// </summary>
        /// <param name="EmailBody">EmailBody: EmailBody</param>
        /// <returns>boolean: true or false</returns>
        public bool SendMail(IMailBody EmailBody)
        {
            var MailMessage = new MailMessage();
            foreach (var email in EmailBody.ToList)
            {
                MailMessage.To.Add(email);
            }
            foreach (var email in EmailBody.CcList)
            {
                MailMessage.To.Add(email);
            }
            foreach (var email in EmailBody.BccList)
            {
                MailMessage.To.Add(email);
            }
            MailMessage.From = EmailBody.SenderAddress;
            MailMessage.Subject = EmailBody.Subject;
            MailMessage.SubjectEncoding = Encoding.UTF8;
            MailMessage.Body = EmailBody.Body;
            MailMessage.BodyEncoding = Encoding.UTF8;
            MailMessage.IsBodyHtml = EmailBody.IsBodyHtml;
            MailMessage.Priority = EmailBody.EMailPriority;
            var smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(EmailBody.SenderAddress.Address, EmailBody.SmtpClientPassword),
                Port = EmailBody.SmtpClientPort,
                Host = EmailBody.SmtpClientHost
            };
            smtpClient.Send(MailMessage);
            return true;
        }
    }
}
