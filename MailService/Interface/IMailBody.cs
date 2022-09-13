namespace MailService.Interface
{
    using System.Collections.Generic;
    using System.Net.Mail;
    public interface IMailBody
    {
        MailAddress SenderAddress { get; set; }
        List<MailAddress> ToList { get; set; }
        List<MailAddress> CcList { get; set; }
        List<MailAddress> BccList { get; set; }
        MailPriority EMailPriority { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        int SmtpClientPort { get; set; }
        string SmtpClientHost { get; set; }
        string SmtpClientPassword { get; set; }
        bool IsBodyHtml { get; set; }
    }
}
