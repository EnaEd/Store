using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Store.BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string mail, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(
                _configuration["RequestEmail:Footer:Message"],
                _configuration["RequestEmail:Footer:SenderMail"]));
            emailMessage.To.Add(new MailboxAddress(string.Empty, mail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(
                    _configuration["RequestEmail:SMTPHostSetting:Host"],
                    int.Parse(_configuration["RequestEmail:SMTPHostSetting:Port"]),
                    bool.Parse(_configuration["RequestEmail:SMTPHostSetting:UseSSL"]));

                await client.AuthenticateAsync(
                    _configuration["RequestEmail:Footer:SenderMail"],
                    _configuration["RequestEmail:Footer:Password"]
                    );

                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
