namespace MailService.Model
{
    using MailService.Interface;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Mail;

    public class MailBody : IMailBody
    {
        [Required]
        public MailAddress SenderAddress { get; set; }
        [Required]
        public List<MailAddress> ToList { get; set; }
        public List<MailAddress> CcList { get; set; }
        public List<MailAddress> BccList { get; set; }
        public MailPriority EMailPriority { get; set; } = MailPriority.Normal;
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int SmtpClientPort { get; set; }
        [Required]
        public string SmtpClientHost { get; set; }
        [Required]
        public string SmtpClientPassword { get; set; }
        public bool IsBodyHtml { get; set; } = true;
    }
}
