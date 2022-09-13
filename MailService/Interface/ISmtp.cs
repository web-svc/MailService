/// <summary>
/// Created by Narender Kumar
/// </summary>
namespace MailService.Interface
{
    public interface ISmtp
    {
        /// <summary>
        /// this function can be used to send an email and it returns boolean. true = mail sent successfully, else exception will be raised and response will be false.
        /// </summary>
        /// <param name="EmailBody">EmailBody: EmailBody</param>
        /// <returns>boolean: true or false</returns>
        bool SendMail(IMailBody EmailBody);
    }
}
