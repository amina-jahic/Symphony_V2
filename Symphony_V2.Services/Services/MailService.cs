using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Symphony_V2.Services.Interfaces;
using Symphony_V2.Services.Models;
using Symphony_V2.Services.Settings;
using System.Threading.Tasks;

namespace Symphony_V2.Services.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail.Replace(";","")));
            email.Subject = "Candidate Questionnaire";
            var builder = new BodyBuilder();
            builder.HtmlBody = $"Dear {mailRequest.UserFirstName} {mailRequest.UserLastName} <br/><br/> We are sending you this message via email because owls are on hunger strike. Thank you again for applying for the junior spell caster position. As a part of our selection process, we send assignments to selected candidates, and you are one of them! <br/><br/>" +
                $"You can access and complete the assessment by clicking on the following {mailRequest.QuestionnaireUrl} and entering pin: {mailRequest.QuestionnairePin} <br/><br/>" +
                "If you have any other questions about the assignment, please don't hesitate to ask! Good luck with the assignment, and I am looking forward to reading your answers,<br/><br/>" +
                "Best Regards";
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
